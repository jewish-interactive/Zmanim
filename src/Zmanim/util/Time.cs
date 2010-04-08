﻿// * Zmanim Java API
// * Copyright (C) 2004-2010 Eliyahu Hershfeld
// *
// * Converted to C# by AdminJew
// *
// * This program is free software; you can redistribute it and/or modify it under the terms of the
// * GNU General Public License as published by the Free Software Foundation; either version 2 of the
// * License, or (at your option) any later version.
// *
// * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without
// * even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
// * General Public License for more details.
// *
// * You should have received a copy of the GNU General Public License along with this program; if
// * not, write to the Free Software Foundation, Inc. 59 Temple Place - Suite 330, Boston, MA
// * 02111-1307, USA or connect to: http://www.fsf.org/copyleft/gpl.html

using System;

namespace net.sourceforge.zmanim.util
{

    /// <summary>
    /// A class that represents a numeric time. Times that represent a time of day
    /// are stored as <seealso cref="java.util.Date"/>s in this API. The time class is used to
    /// represent numeric time such as the time in hours, minutes, seconds and
    /// milliseconds of a
    /// <seealso cref="net.sourceforge.zmanim.AstronomicalCalendar#getTemporalHour() temporal hour"/>.
    ///
    /// @author &copy; Eliyahu Hershfeld 2004 - 2007
    /// @version 0.9.0 </summary>
    public class Time
    {
        private const int SECOND_MILLIS = 1000;

        private const int MINUTE_MILLIS = SECOND_MILLIS * 60;

        private const int HOUR_MILLIS = MINUTE_MILLIS * 60;

        private int hours = 0;

        private int minutes = 0;

        private int seconds = 0;

        private int milliseconds = 0;

        private bool isNegative = false;

        public Time(int hours, int minutes, int seconds, int milliseconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            this.milliseconds = milliseconds;
        }

        public Time(double millis)
            : this((int)millis)
        {
        }

        public Time(int millis)
        {
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(millis);
            if (millis < 0)
            {
                isNegative = true;
                millis = System.Math.Abs(millis);
            }
            hours = timeSpan.Hours;

            minutes = timeSpan.Minutes;

            seconds = timeSpan.Seconds;

            milliseconds = timeSpan.Milliseconds;
        }

        public virtual bool IsNegative()
        {
            return isNegative;
        }

        public virtual void setIsNegative(bool isNegative)
        {
            this.isNegative = isNegative;
        }


        /// <returns> Returns the hour. </returns>
        public virtual int getHours()
        {
            return hours;
        }


        /// <param name="hours">
        ///            The hours to set. </param>
        public virtual void setHours(int hours)
        {
            this.hours = hours;
        }


        /// <returns> Returns the minutes. </returns>
        public virtual int getMinutes()
        {
            return minutes;
        }


        /// <param name="minutes">
        ///            The minutes to set. </param>
        public virtual void setMinutes(int minutes)
        {
            this.minutes = minutes;
        }


        /// <returns> Returns the seconds. </returns>
        public virtual int getSeconds()
        {
            return seconds;
        }


        /// <param name="seconds">
        ///            The seconds to set. </param>
        public virtual void setSeconds(int seconds)
        {
            this.seconds = seconds;
        }


        /// <returns> Returns the milliseconds. </returns>
        public virtual int getMilliseconds()
        {
            return milliseconds;
        }


        /// <param name="milliseconds">
        ///            The milliseconds to set. </param>
        public virtual void setMilliseconds(int milliseconds)
        {
            this.milliseconds = milliseconds;
        }

        public virtual double getTime()
        {
            return hours * HOUR_MILLIS + minutes * MINUTE_MILLIS + seconds * SECOND_MILLIS + milliseconds;
        }

        public override string ToString()
        {
            return new ZmanimFormatter().format(this);
        }
    }
}