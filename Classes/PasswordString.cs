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
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace ActiveLogger
{
    public delegate void PasswordFoundEventHandler(Object sender, EventArgs e);

    public class PasswordString
    {
        // secret password
        private string password_;

        // current string
        private StringBuilder innerString_;

        // timer that clears the inner string periodically
        private Timer innerTimer_;

        public event PasswordFoundEventHandler OnPasswordFound;

        public PasswordString(string password, int capacity, int maxlength)
        {
            this.password_ = password;

            this.innerString_ = new StringBuilder(capacity, maxlength);

            // 8 seconds period for clearing the inner string buffer
            this.innerTimer_ = new Timer(8, 0);

            this.innerTimer_.OnTargetReached += new OnTargetReachedEventHandler(innerTimer_OnTargetReached);

            this.innerTimer_.Start();
        }

        ~PasswordString()
        {
            this.innerTimer_.Stop();
        }

        void innerTimer_OnTargetReached(object sender, EventArgs e)
        {
            this.Clear();
        }

        public void Append(string s)
        {
            if (this.innerString_.Length >= this.innerString_.MaxCapacity)
                this.Clear();

            this.innerString_.Append(s);

            if (CheckPassword())
                this.PasswordFound(this, new EventArgs());
        }

        public void Clear()
        {
            this.innerString_.Remove(0, this.innerString_.Length);
        }

        protected virtual void PasswordFound(Object sender, EventArgs e)
        {
            if (this.OnPasswordFound != null)
                this.OnPasswordFound(sender, e);

            this.Clear();
        }

        private bool CheckPassword()
        {
            if (this.password_ == this.innerString_.ToString())
                return true;
            else
                return false;
        }

        public string Password
        {
            get
            {
                return this.password_;
            }
            set
            {
                this.password_ = value;
            }
        }

    }
}
