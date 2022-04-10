using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace MultiBinding
{
    /// <summary>
    /// Clock class definition.
    /// </summary>
    class Clock : INotifyPropertyChanged
    {
        /// <summary>
        /// "PropertyChanged" event is part of the "INotifyPropertyChanged" implementation.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Timer tick event handler updates our time data.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        /// <remarks>
        /// We'll set this method as an event handler on a timer created in the clock constructor.
        /// The method will be called once every second. Internally we hold a count of hours,
        /// minutes, and seconds. Ours is a 12-hour clock so the hours count can only be 1-12
        /// and we additionally hold onto a string that denotes AM or PM.
        /// </remarks>
        private void UpdateTime(object sender, EventArgs e)
        {
            // Start by getting the current hours, minutes, and seconds count from the sytem.
            //
            Hours = DateTime.Now.Hour;
            Minutes = DateTime.Now.Minute;
            Seconds = DateTime.Now.Second;

            // The hours count is 24-hour count but ours is a 12-hour clock so we need to adjust
            // the hours and set our Am/Pm string accordingly.
            //
            if (Hours >= 12)
            {
                AmPm = "PM";
                if (Hours > 12)
                {
                    Hours -= 12;
                }
            }
            else
            {
                AmPm = "AM";
                if (Hours == 0)
                {
                    Hours = 12;
                }
            }

            // Send out notifications that all of properties have changed.
            //
            // Note the trick we use here. In the previous samples, we fired off property changed
            // events for individual properties. In this method we've updated all of our properties
            // and we would like to send out a notification that all of our properties have
            // changed. We could send out individual notifications like we did in previous samples
            // for each of the properties on this object. An easier way to do this though is to
            // send out one property changed event and pass in an empty or null string for the
            // property name. This tells WPF that all of the properties in this object have
            // changed.
            //
            // Of course, we know that the minutes (for example) don't change every second and the
            // hours change less than that. In a better world we would likely optimize this. This
            // is good enough for such a simple sample though.
            //
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        /// <summary>
        /// Clock constructor.
        /// </summary>
        public Clock()
        {
            // Make one call to our event handler on construction to make sure this clock wakes
            // up with the current time.
            //
            UpdateTime(null, null);

            // Now set a timer to call our event handler once every second to update this clock
            // to the current time.
            //
            DispatcherTimer dispatcherTimer = new();
            dispatcherTimer.Tick += UpdateTime;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        /// <summary>
        /// The hour component of the current clock.
        /// </summary>
        public int Hours { private set;  get; }

        /// <summary>
        /// The minute component of the current clock.
        /// </summary>
        public int Minutes { private set;  get; }

        /// <summary>
        /// The second component of the current clock.
        /// </summary>
        public int Seconds { private set;  get; }

        /// <summary>
        /// The "AM/PM" string from the current clock.
        /// </summary>
        public string AmPm { private set; get; }
    }
}
