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
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ActiveLogger
{		

	/// <summary>
	/// Win32 Key Codes
	/// </summary>
	public class KeyCodes
	{
		/// <summary>
		/// Modifier Key Codes
		/// </summary>
		public enum Modifier : uint
		{
			MOD_ALT = 1,
			MOD_CONTROL = 2,
            MOD_SHIFT = 4,
            MOD_WIN = 8
		}

		/// <summary>
		/// Virtual Key Codes
		/// </summary>
		public enum VirtualKey : uint
		{
            VK_A = 65,
            VK_B = 66,
            VK_C = 67,
            VK_D = 68,
            VK_E = 69,
            VK_F = 70,
            VK_G = 71,
            VK_H = 72,
            VK_I = 73,
			VK_J = 74,
			VK_K = 75,
			VK_L = 76,
            VK_M = 77,
            VK_N = 78,
            VK_O = 79,
            VK_P = 80,
            VK_Q = 81,
            VK_R = 82,
            VK_S = 83,
            VK_T = 84,
            VK_U = 85,
            VK_V = 86,
            VK_W = 87,
            VK_X = 88,
            VK_Y = 89,
            VK_Z = 90
		}
	}

	/// <summary>
	/// HotKey Object used to describe/identify a hot key
	/// </summary>
	[Serializable()]
	public class HotKey
	{
		/// <summary>
		/// Private Fields
		/// </summary>
		private int m_id;
		private KeyCodes.Modifier m_modifiers;
		private KeyCodes.VirtualKey m_virtkey;
		
		/// <summary>
		/// HotKey Constructor
		/// </summary>
		/// <param name="ID">HotKey Identifier</param>
		/// <param name="Modifiers">HotKey Modifiers</param>
		/// <param name="VirtualKey"></param>
		public HotKey(int ID, KeyCodes.Modifier Modifiers, KeyCodes.VirtualKey VirtualKey)
		{
			m_id = ID;
			m_modifiers = Modifiers;
			m_virtkey = VirtualKey;
		}
		//property accessors
		public int ID
		{
			get
			{
				return m_id;
			}
			set
			{
				m_id = value;
			}
		}
		public KeyCodes.Modifier Modifiers
		{
			get
			{
				return m_modifiers;
			}
			set
			{
				m_modifiers = value;
			}
		}
		public KeyCodes.VirtualKey VirtualKey
		{
			get
			{
				return m_virtkey;
			}
			set
			{
				m_virtkey = value;
			}
		}
	}
	
	/// <summary>
	/// HotKeyFilter Object used to register, unregister, and process HotKey messages
	/// </summary>
	[Serializable()]
	public class HotKeyFilter : IMessageFilter, ISerializable, IEnumerable
	{
		[DllImport("user32.dll")] private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
		[DllImport("user32.dll")] private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fdModifiers, uint vk);
		
		public delegate void HotKeyHandler(object sender, IntPtr WParam);
		public event HotKeyHandler HotKeyEvent;

		private const int WM_HOTKEY = 786;

		private ArrayList KeyList; //stores all the registered hotkeys
		
		private int m_position = -1; //holds current index for IEnumerable

		//Holds reference to calling form
		private Form m_parent;

		/// <summary>
		/// Parent Property
		/// Used to indicate the form that will be recieving HotKey messages
		/// </summary>
		public Form Parent
		{
			set
			{
				m_parent = value;
			}
			get
			{
				return m_parent;
			}
		}

		/// <summary>
		/// Returns the HotKey located at the specified index
		/// </summary>
		/// <param name="index">Zero-based index of the desired hotkey</param>
		/// <returns>HotKey Object</returns>
		public HotKey HotKey(int index)
		{
			return (HotKey)KeyList[index];
		}

		/// <summary>
		/// Default Class Constructor
		/// </summary>
		public HotKeyFilter()
		{
			KeyList = new ArrayList();
		}
		
		/// <summary>
		/// Class Constructor for Deserialization
		/// </summary>
		/// <param name="info"></param>
		/// <param name="ctxt"></param>
		public HotKeyFilter(SerializationInfo info, StreamingContext ctxt)
		{
			KeyList = (ArrayList)info.GetValue("KeyList",typeof(ArrayList));
		}
		
		/// <summary>
		/// Implements ISerializable GetObjectData function
		/// </summary>
		/// <param name="info"></param>
		/// <param name="ctxt"></param>
		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("KeyList",KeyList,KeyList.GetType());			
		}

		/// <summary>
		/// Filters Window Messages
		/// </summary>
		/// <param name="msg">Windows Message</param>
		/// <returns>bool</returns>
		public bool PreFilterMessage(ref Message msg)
		{
			if (msg.Msg == WM_HOTKEY)
			{
				if(HotKeyEvent != null)
				{
					HotKeyEvent(this,msg.WParam);
					return(true);
				}
			}
			return(false);
		}

		/// <summary>
		/// Reregisters all current HotKeys
		/// </summary>
		public void RestoreKeys()
		{
			foreach(HotKey hKey in KeyList)
			{
				RegisterHotKey(m_parent.Handle,hKey.ID,(uint)hKey.Modifiers,(uint)hKey.VirtualKey);
			}
		}

		/// <summary>
		/// Registers a given HotKey
		/// </summary>
		/// <param name="hKey">Instantiated HotKey Object</param>
		public void Add(HotKey hKey)
		{
			if(RegisterHotKey(m_parent.Handle,hKey.ID,(uint)hKey.Modifiers,(uint)hKey.VirtualKey))
                KeyList.Add(hKey);
		}

		/// <summary>
		/// Unregisters all current HotKeys
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void ReleaseKeys(object sender, System.ComponentModel.CancelEventArgs e)
		{
			foreach(HotKey hKey in KeyList)
				UnregisterHotKey(m_parent.Handle,hKey.ID);
		}

		/// <summary>
		/// Unregisters all current HotKeys
		/// </summary>
		public void ReleaseKeys()
		{
			foreach(HotKey hKey in KeyList)
				UnregisterHotKey(m_parent.Handle,hKey.ID);
			KeyList = new ArrayList();
		}

		/// <summary>
		/// Returns an enumerator for this collection
		/// </summary>
		/// <returns>IEnumerator Interface</returns>
		public IEnumerator GetEnumerator()
		{
			return (IEnumerator)this;
		}

		/// <summary>
		/// Implements IEnumerable index progression
		/// </summary>
		/// <returns></returns>
		public bool MoveNext()
		{
			m_position++;
			if (m_position < KeyList.Count)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Implements IEnumerable index reset
		/// </summary>
		public void Reset()
		{
			m_position = -1;
		}

		/// <summary>
		/// Implements IEnumerable current index value
		/// </summary>
		public object Current
		{
			get
			{
				return KeyList[m_position];
			}
		}
	}
}
