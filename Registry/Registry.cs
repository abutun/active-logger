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
using Microsoft.Win32;


namespace ActiveLogger
{
	/// <summary>
	/// Summary description for clsRegistry.
	/// </summary>
	public class ActiveRegistry
	{
		public string strRegError; //this variable contains the error message (null when no error occured)


		public ActiveRegistry() //class constructor
		{
		}

		/// <summary>
		/// Retrieves the specified String value. Returns a System.String object
		/// </summary>
		public string GetStringValue (RegistryKey hiveKey, string strSubKey, string strValue)
		{
			object objData = null;
			RegistryKey subKey = null;
			
			try
			{
				subKey = hiveKey.OpenSubKey (strSubKey);
				if ( subKey==null ) 
				{
					strRegError = "Cannot open the specified sub-key";
					return null;
				}
				objData = subKey.GetValue (strValue);
				if ( objData==null ) 
				{
					strRegError = "Cannot open the specified value";
					return null;
				}
				subKey.Close();
				hiveKey.Close();
			} 
			catch (Exception exc)
			{
				strRegError = exc.Message;
				return null;
			}
			
			strRegError = null;
			return objData.ToString();
		}

		/// <summary>
		/// Sets/creates the specified String value
		/// </summary>
		public bool SetStringValue (RegistryKey hiveKey, string strSubKey, string strValue, string strData)
		{
			RegistryKey subKey = null;
			
			try
			{
				subKey = hiveKey.CreateSubKey (strSubKey);
				if ( subKey==null ) 
				{
					strRegError = "Cannot create/open the specified sub-key";
					return false;
				}
				subKey.SetValue (strValue, strData);
				subKey.Close();
				hiveKey.Close();
			} 
			catch (Exception exc)
			{
				strRegError = exc.Message;
				return false;
			}
			
			strRegError = null;
			return true;
		}

		/// <summary>
		/// Creates a new subkey or opens an existing subkey
		/// </summary>
		public bool CreateSubKey (RegistryKey hiveKey, string strSubKey)
		{
			RegistryKey subKey = null;
			
			try
			{
				subKey = hiveKey.CreateSubKey (strSubKey);
				if ( subKey==null ) 
				{
					strRegError = "Cannot create the specified sub-key";
					return false;
				}
				subKey.Close();
				hiveKey.Close();
			} 
			catch (Exception exc)
			{
				strRegError = exc.Message;
				return false;
			}
			
			strRegError = null;
			return true;
		}

		/// <summary>
		/// Deletes a subkey and any child subkeys recursively
		/// </summary>
		public bool DeleteSubKeyTree (RegistryKey hiveKey, string strSubKey)
		{
			try
			{
				hiveKey.DeleteSubKeyTree (strSubKey);
				hiveKey.Close();
			} 
			catch (Exception exc)
			{
				strRegError = exc.Message;
				return false;
			}
			
			strRegError = null;
			return true;
		}

		/// <summary>
		/// Deletes the specified value from this (current) key
		/// </summary>
		public bool DeleteValue (RegistryKey hiveKey, string strSubKey, string strValue)
		{
			RegistryKey subKey = null;
			try
			{
				subKey = hiveKey.OpenSubKey (strSubKey, true);
				if ( subKey==null )
				{
					strRegError = "Cannot open the specified sub-key";
					return false;
				}
				subKey.DeleteValue (strValue);
				subKey.Close();
				hiveKey.Close();
			} 
			catch (Exception exc)
			{
				strRegError = exc.Message;
				return false;
			}
			
			strRegError = null;
			return true;
		}
	}

}
