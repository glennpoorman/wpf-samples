using System.ComponentModel;

namespace Themes
{
    /// <summary>
    /// CheckBox manager class definition.
    /// </summary>
    /// <remarks>
    /// This class is the same checkbox manager class from the "ThreeStateCheck" sample and serves
    /// exactly the same purpose. The only difference in this sample is our use of the custom
    /// checkbox.
    /// </remarks>
    class CheckBoxManager : INotifyPropertyChanged
    {
        /// <summary>
        /// "PropertyChanged" event is part of the "INotifyPropertyChanged" implementation.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Utility used to fire off a property changed event.
        /// </summary>
        /// <param name="property">The name of the property that has changed.</param>
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        /// <summary>
        /// Property is true if first checkbox is checked.
        /// </summary>
        private bool isFirstBoxChecked;

        /// <summary>
        /// Property is true if first checkbox is checked.
        /// </summary>
        public bool IsFirstBoxChecked
        {
            get => isFirstBoxChecked;
            set { isFirstBoxChecked = value; OnPropertyChanged("IsFirstBoxChecked"); OnPropertyChanged("AreAllBoxesChecked"); }
        }

        /// <summary>
        /// Property is true if second checkbox is checked.
        /// </summary>
        private bool isSecondBoxChecked;

        /// <summary>
        /// Property is true if second checkbox is checked.
        /// </summary>
        public bool IsSecondBoxChecked
        {
            get => isSecondBoxChecked;
            set { isSecondBoxChecked = value; OnPropertyChanged("IsSecondBoxChecked"); OnPropertyChanged("AreAllBoxesChecked"); }
        }

        /// <summary>
        /// Property is true if third checkbox is checked.
        /// </summary>
        private bool isThirdBoxChecked;

        /// <summary>
        /// Property is true if third checkbox is checked.
        /// </summary>
        public bool IsThirdBoxChecked
        {
            get => isThirdBoxChecked;
            set { isThirdBoxChecked = value; OnPropertyChanged("IsThirdBoxChecked"); OnPropertyChanged("AreAllBoxesChecked"); }
        }

        /// <summary>
        /// Property is true if all three boxes are checked.
        /// </summary>
        /// <remarks>
        /// Again the nullable bool allows for a third state for the checkbox.
        /// </remarks>
        public bool? AreAllBoxesChecked
        {
            // Get accessor returns true if all of the other properties are true, false if the
            // other three are all false, or null if the other three don't match.
            //
            get
            {
                if (isFirstBoxChecked && isSecondBoxChecked && isThirdBoxChecked)
                {
                    return true;
                }
                else if (!isFirstBoxChecked && !isSecondBoxChecked && !isThirdBoxChecked)
                {
                    return false;
                }
                else
                {
                    return null;
                }
            }

            // The set accessor sets all of the other three properties to true if the input value
            // is true. Otherwise they are all set to false.
            //
            set
            {
                IsFirstBoxChecked = IsSecondBoxChecked = IsThirdBoxChecked = (value == true) ? true : false;
            }
        }
    }
}
