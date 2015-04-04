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
using System.Data;
using System.IO;
using System.Collections;

namespace ActiveLogger
{
    /// <summary>
    /// user setting are stored via this object
    /// it is a simple serializable dictionary
    /// </summary>
    [Serializable]
    public class Settings : ICollection, ICloneable
    {
        private Hashtable curSettings_;

        public Settings()
        {
            this.curSettings_ = new Hashtable();

            // load the default settings
            LoadDefaultSettings();
        }

        public Settings(ICollection Collection)
        {
            this.curSettings_ = new Hashtable();

            foreach (SettingPropery p in Collection)
                this.curSettings_.Add(p.Name, p.Value);
        }

        public object this[string propertyName]
        {
            get
            {
                return this.curSettings_[propertyName];
            }
            set
            {
                this.curSettings_[propertyName] = value;
            }
        }

        public object this[SettingPropery prop]
        {
            get
            {
                return this[prop.Name];
            }
            set
            {
                this[prop.Name] = value;
            }
        }

        public void Add(SettingPropery prop)
        {
            this.curSettings_.Add(prop.Name, prop.Value);
        }

        public void Remove(SettingPropery prop)
        {
            this.curSettings_.Remove(prop.Name);
        }

        public void Clear()
        {
            this.curSettings_.Clear();
        }

        public bool Contains(SettingPropery prop)
        {
            return this.curSettings_.Contains(prop.Name);
        }

        public bool Contains(string properyName)
        {
            return this.curSettings_.Contains(properyName);
        }

        public void LoadDefaultSettings()
        {
            // Clear all before
            this.Clear();

            //this.Add(
        }

        #region ICloneable Members

        public object Clone()
        {
            return curSettings_.Clone();
        }

        #endregion

        #region ICollection Members

        public void CopyTo(Array array, int index)
        {
            this.curSettings_.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return this.curSettings_.Count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return this.curSettings_.IsSynchronized;
            }
        }

        public object SyncRoot
        {
            get
            {
                return this;
            }
        }

        #endregion

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return this.curSettings_.GetEnumerator();
        }

        #endregion
    }

    [Serializable]
    public class SettingPropery
    {
        private string properyName_;
        private object properyValue_;

        public SettingPropery(string Name)
        {
            this.properyName_ = Name;
            this.properyValue_ = null;
        }

        public SettingPropery(string Name, object Value)
        {
            this.properyName_ = Name;
            this.properyValue_ = Value;
        }

        public string Name
        {
            get
            {
                return properyName_;
            }
            set
            {
                this.properyName_ = value;
            }
        }

        public object Value
        {
            get
            {
                return properyValue_;
            }
            set
            {
                this.properyValue_ = value;
            }
        }
    }
}
