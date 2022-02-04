using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ValueConverters
{
    /// <summary>
    /// Converter is used to convert grade level values to font styles.
    /// </summary>
    public class LevelToStyleConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value from the source data to the target (UI).
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>The converted value.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Initialize the output object. The static value "DependencyProperty.UnsetValue" is
            // used to denote that a dependency property exists but that its value was not set by
            // the property system or the app. This value is generally used in value converters to
            // signal that the conversion could not take place; usually because of some bad data.
            //
            object outputStyle = DependencyProperty.UnsetValue;

            // The "value" parameter is the value that is to be converted. In this case that value
            // is supposed to be a "GradeLevel" so before doing anything, make sure that's actually
            // what we have.
            //
            if (value.GetType() == typeof(GradeLevel))
            {
                // Fetch the grade level value.
                //
                GradeLevel level = (GradeLevel)value;

                // Depending on the value, return a brush. In this case we simply use one of the
                // static brushes already existing.
                //
                if (level == GradeLevel.Brownie)
                {
                    outputStyle = FontStyles.Normal;
                }
                else if (level == GradeLevel.Junior)
                {
                    outputStyle = FontStyles.Italic;
                }
                else if (level == GradeLevel.Senior)
                {
                    outputStyle = FontStyles.Oblique;
                }
            }

            // Return the brush.
            //
            return outputStyle;
        }

        /// <summary>
        /// Converts a value from the target (UI) back to the source data.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>The converted value.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // This is one of many cases where conversion back (from style to grade level) simply
            // isn't necessary. The grade level can be changed either via the UI or through code
            // and we have to be able to convert from grade level to font style for display purposes.
            // There is no scenario, however, where a font style can be changed by any other means
            // that would require a conversion back to a grade level. For that reason, we can simply
            // throw an exception here.
            //
            // NOTE: If you really wanted the exercise, you could look at the implementation of
            //       "Convert" and simply reverse everything taking into account that a "FontStyle"
            //       is coming in and a "GradeLevel" is supposed to go out.
            //
            throw new NotImplementedException();
        }
    }
}
