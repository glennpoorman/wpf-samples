using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ICommands
{
    /// <summary>
    /// Converter is used to convert grade level values to colors.
    /// </summary>
    public class LevelToColorConverter : IValueConverter
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
            // Initialize the output object.
            //
            object outputBrush = DependencyProperty.UnsetValue;

            // Make sure the value is a "GradeLevel".
            //
            if (value.GetType() == typeof(GradeLevel))
            {
                // Fetch the grade level value and set the brush accordingly.
                //
                GradeLevel level = (GradeLevel)value;
                switch (level)
                {
                    case GradeLevel.Daisy:
                        outputBrush = Brushes.Blue;
                        break;
                    case GradeLevel.Brownie:
                        outputBrush = Brushes.Brown;
                        break;
                    case GradeLevel.Junior:
                        outputBrush = Brushes.Purple;
                        break;
                    case GradeLevel.Cadette:
                        outputBrush = Brushes.Red;
                        break;
                    case GradeLevel.Senior:
                        outputBrush = Brushes.Orange;
                        break;
                    case GradeLevel.Ambassador:
                        outputBrush = Brushes.Goldenrod;
                        break;
                }
            }

            // Return the brush.
            //
            return outputBrush;
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
            // No back conversion necessary.
            //
            throw new NotImplementedException();
        }
    }
}
