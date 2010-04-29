﻿using System;
using PublicDomain;
using Zmanim.Extensions;

namespace Zmanim.TimeZone
{
    public class OlsonTimeZone : ITimeZone
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OlsonTimeZone"/> class.
        /// </summary>
        public OlsonTimeZone() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OlsonTimeZone"/> class.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        public OlsonTimeZone(TzTimeZone timeZone)
        {
            this.TimeZone = timeZone;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OlsonTimeZone"/> class.
        /// </summary>
        /// <param name="timeZoneName">Name of the time zone.</param>
        public OlsonTimeZone(string timeZoneName)
        {
            TimeZone = TzTimeZone.GetTimeZone(timeZoneName);
        }

        /// <summary>
        /// Gets or sets the time zone.
        /// </summary>
        /// <value>The time zone.</value>
        public TzTimeZone TimeZone { get; set; }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// UTCs the offset.
        /// If Daylight Saving Time is in effect at the specified date,
        /// the offset value is adjusted with the amount of daylight saving.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public int UtcOffset(DateTime dateTime)
        {
            return (int)TimeZone.GetUtcOffset(dateTime).TotalMilliseconds;
        }

        /// <summary>
        /// Ins the daylight time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public bool inDaylightTime(DateTime dateTime)
        {
            return TimeZone.IsDaylightSavingTime(dateTime);
        }

        /// <summary>
        /// Gets the ID of this time zone.
        /// </summary>
        /// <returns>the ID of this time zone.</returns>
        public string getID()
        {
            return getDisplayName();
        }

        /// <summary>
        /// Returns a name of this time zone suitable for presentation to the user in the default locale.
        /// This method returns the long name, not including daylight savings.
        /// If the display name is not available for the locale, then this method returns a string in the normalized custom ID format.
        /// </summary>
        /// <returns></returns>
        public string getDisplayName()
        {
            return TimeZone.StandardName;
        }

        /// <summary>
        /// Returns the offset of this time zone from UTC at the specified date.
        /// If Daylight Saving Time is in effect at the specified date,
        /// the offset value is adjusted with the amount of daylight saving.
        /// </summary>
        /// <param name="timeFromEpoch">the date represented in milliseconds since January 1, 1970 00:00:00 GMT</param>
        /// <returns>
        /// the amount of time in milliseconds to add to UTC to get local time.
        /// </returns>
        public int getOffset(long timeFromEpoch)
        {
            return UtcOffset(timeFromEpoch.ToDateTime());
        }
    }
}