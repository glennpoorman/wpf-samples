using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ValueConverters
{
    /// <summary>
    /// Converter for grade level to boolean conversion.
    /// </summary>
    public class LevelToBoolConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value from the source data to the target (UI).
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>The converted value.</returns>
        /// <remarks>
        /// The idea behind this converter is that it be used to check/uncheck a radio button
        /// depending on the value of an enum that a control is bound to. We assume that the input
        /// value is an enum type and the value is the current value in the data context. Then the
        /// parameter value is a hard coded string matching one of the possible enum values and we
        /// return true if the parameter matches the current value and false if it does not. So if
        /// we bind "IsChecked" on a specific radio button to an enum value, we are saying "check
        /// this button if the value matches this parameter ... otherwise uncheck it".
        /// </remarks>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Fetch the parameter string and exit if there isn't one or if it isn't a string.
            //
            // The static value "DependencyProperty.UnsetValue" is used to denote that a dependency
            // property exists but that its value was not set by the property system or the app.
            // This value is generally used in value converters to signal that the conversion could
            // not take place; usually because of some bad data.
            //
            string parameterString = parameter as string;
            if (parameterString == null)
            {
                return DependencyProperty.UnsetValue;
            }

            // Make sure the parameter value is actually a possible enum value.
            //
            if (Enum.IsDefined(value.GetType(), parameter) == false)
            {
                return DependencyProperty.UnsetValue;
            }

            // Fetch the actual enum value corresponding to the parameter string.
            //
            object parameterValue = Enum.Parse(value.GetType(), parameterString);

            // Return true if the values match and false if they don't.
            //
            return parameterValue.Equals(value);
        }

        /// <summary>
        /// Converts a value from the target (UI) back to the source data.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>The converted value.</returns>
        /// <remarks>
        /// Here the backward conversion is used to set the enum value in the data context when a
        /// radio button's checked status has changed. In other words, if a radio button's checked
        /// status becomes "true", then we set the enum value on the data context to whatever the
        /// parameter value is.
        /// </remarks>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Fetch the parameter string and exit if there isn't one or if it isn't a string.
            //
            string parameterString = parameter as string;
            if (parameterString == null)
            {
                return DependencyProperty.UnsetValue;
            }

            // Make sure the input value is a boolean.
            //
            if (value.GetType() == typeof(bool))
            {
                // Fetch the target boolean value.
                //
                bool useValue = (bool)value;

                // If the incoming value is true, parse and return the enum value from the
                // parameter string. Note that we don't do anything for a "false" value as we can
                // assume that the converter call for one of the other radio buttons will take care
                // of setting the value on the data context.
                //
                if (useValue)
                {
                    return Enum.Parse(targetType, parameterString);
                }
            }

            return DependencyProperty.UnsetValue;
        }
    }
}
