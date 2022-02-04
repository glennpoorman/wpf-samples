using System.ComponentModel;

namespace ThreeStateCheck
{
    /// <summary>
    /// CheckBox manager class definition.
    /// </summary>
    /// <remarks>
    /// This class is kind of a dumb class to bind to but we're using it as a simple way to
    /// demonstrate how three state checkboxes work and how to do the data binding. The main
    /// window contains three main checkboxes and their "IsChecked" properties are bound to
    /// "bool" properties on this class. The last property is true if all of the other three
    /// properties are true, false if the other three are false, and in an indeterminate state
    /// if the other three are a mixed bag. In order to represent that state, that particular
    /// property is a nullable bool (bool?) and a return value of null tells the check box that
    /// its current checked state is indeterminate.
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
        /// As described already, this particular property is a nullable bool in order to show a
        /// possible third state to the check box. In this case, if the other three properties are
        /// not either all true or all false, this property returns null telling the the caller
        /// that the current state is indeterminate. When binding a checkbox "IsChecked" property
        /// to a nullable bool, a return of null will put that checkbox into an indeterminate state.
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
            // is true. Otherwise they are all set to false. Note that we don't do anything special
            // for an incoming null value. The checkbox in the XAML is not specifically set to be
            // a three state checkbox. That means the user can never cycle through the third state
            // and therefore a value of null will never come in this way.
            //
            set
            {
                IsFirstBoxChecked = IsSecondBoxChecked = IsThirdBoxChecked = (value == true) ? true : false;
            }
        }
    }
}
