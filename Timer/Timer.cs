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
using System.Text;
using System.Threading;

namespace ActiveLogger
{
    public delegate void OnTargetReachedEventHandler(Object sender, EventArgs e);

    /// <summary>
    /// Timer class
    /// </summary>
    public class Timer
    {
        private TimerState timerState_;

        private Thread innerThread_;

        private int orgTarget_;
        private int orgCurrent_;

        private int innerTarget_;
        private int innerCurrent_;

        public event OnTargetReachedEventHandler OnTargetReached;

        /// <summary>
        /// Ticks every 5 seconds
        /// </summary>
        public Timer() : this(5, 0){}

        /// <summary>
        /// Timer
        /// </summary>
        /// <param name="target">Target time in seconds</param>
        /// <param name="start">Initial start value in seconds</param>
        public Timer(int target, int start)
        {
            this.innerTarget_ = this.orgTarget_ = target;
            this.innerCurrent_ = this.orgCurrent_ = start;

            this.timerState_ = TimerState.STOPPED;
        }

        ~Timer()
        {
            Stop();
        }

        public int Target
        {
            get
            {
                return this.innerTarget_;
            }
            set
            {
                this.innerTarget_ = value;
            }
        }

        public int Current
        {
            get
            {
                return this.innerCurrent_;
            }
            set
            {
                if(value<this.Target)
                    this.innerCurrent_ = value;
            }
        }

        public TimerState TimerState
        {
            get
            {
                return this.timerState_;
            }
        }

        public void Start()
        {
            this.timerState_ = TimerState.STARTED;

            // create a new thread
            this.innerThread_ = new Thread(new ThreadStart(Count));
            this.innerThread_.IsBackground = true;
            this.innerThread_.Start();
        }

        public void Pause()
        {
            this.timerState_ = TimerState.PAUSED;
        }

        public void Stop()
        {
            this.timerState_ = TimerState.STOPPED;

            this.innerTarget_ = this.orgTarget_;
            this.innerCurrent_ = this.orgCurrent_;

            try
            { 
                this.innerThread_.Abort(); 
            }
            catch 
            {
                /*NOP*/
            }
        }

        private void Count()
        {
            while (true)
            {
                if (this.timerState_ == TimerState.STARTED)
                {
                    for (int i = 0; i < this.Target*2; i++) 
                        Thread.Sleep(100);

                    this.innerCurrent_++;

                    if (this.Current >= this.Target)
                        this.TargetReached(this, new EventArgs());
                }
            }
        }

        protected virtual void TargetReached(Object sender, EventArgs e)
        {
            if (this.OnTargetReached != null)
                this.OnTargetReached(sender, e);

            this.Current = 0;
        }
    }

    public enum TimerState
    {
        STOPPED = 0,
        PAUSED = 0,
        STARTED = 0
    }
}
