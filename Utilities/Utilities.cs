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
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ActiveLogger
{
    public class Utilities
    {
        private static Settings Settings_;

        /// <summary>
        /// settings for the current user
        /// </summary>
        public static Settings Settings
        {
            get
            {
                return Settings_;
            }
        }

        public static void SafeCheckDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public static bool LoadSettings()
        {
            Settings_ = new Settings();

            string filePath = Application.UserAppDataPath + "\\actset.bin";

            if (File.Exists(filePath))
            {
                try
                {
                    Settings_ = (Settings)Serializer.Deserialize(filePath);

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
                return false;
        }

        public static bool SaveSettings()
        {
            string filePath = Application.UserAppDataPath + "\\actset.bin";

            try
            {
                Serializer.Serialize(Settings_, filePath);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool CheckRegisteryKeys()
        {
            ActiveRegistry actReg = new ActiveRegistry();

            if ((actReg.GetStringValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", Constants.defaultHLMKey)
                                     != null) || (actReg.GetStringValue(Registry.CurrentUser, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", Constants.defaultHCUKey)) != null)
                return true;
            else
                return false;
        }

        public static bool SetRegisteryKeys()
        {
            ActiveRegistry actReg = new ActiveRegistry();

            string stringValue = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\DerinWeb\ActiveLogger\ActiveLogger.exe -b";

            if (actReg.SetStringValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", Constants.defaultHLMKey, stringValue))
                return true;
            else
            {
                if (actReg.SetStringValue(Registry.CurrentUser, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", Constants.defaultHCUKey, stringValue))
                    return true;
                else
                    return false;
            }
        }

        public static void DeleteRegisteryKeys()
        {
            ActiveRegistry actReg = new ActiveRegistry();

            actReg.DeleteSubKeyTree(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\" + Constants.defaultHLMKey);
            actReg.DeleteSubKeyTree(Registry.CurrentUser, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\" + Constants.defaultHCUKey);
        }
    }
}