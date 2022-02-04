using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Themes
{
    /// <summary>
    /// Custom image button checkbox definition.
    /// </summary>
    public class ImageCheckBox : CheckBox
    {
        /// <summary>
        /// Static checkbox constructor.
        /// </summary>
        static ImageCheckBox()
        {
            // One time initialization overrides the default style to use our style defined in the
            // "ImageCheckBox.xaml" file instead of the default style from the "CheckBox" class.
            //
            // Note: Without this, the new type of checkbox would continue to use the default
            //       "CheckBox" style unless we specifically pulled the resource dictionary
            //       "ImageCheckBox.xaml" into the window or control where we use the button.
            //
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageCheckBox),
                new FrameworkPropertyMetadata(typeof(ImageCheckBox)));
        }

        /// <summary>
        /// The image that will be displayed when the check box is checked.
        /// </summary>
        public static readonly DependencyProperty CheckedImageProperty =
            DependencyProperty.Register("CheckedImage", typeof(ImageSource), typeof(ImageCheckBox));

        /// <summary>
        /// The image that will be displayed when the check box is not checked.
        /// </summary>
        public static readonly DependencyProperty UnCheckedImageProperty =
            DependencyProperty.Register("UnCheckedImage", typeof(ImageSource), typeof(ImageCheckBox));

        /// <summary>
        /// The image that will be displayed when the check box is in an indeterminate state.
        /// </summary>
        public static readonly DependencyProperty IndeterminateImageProperty =
            DependencyProperty.Register("InderminateImage", typeof(ImageSource), typeof(ImageCheckBox));

        /// <summary>
        /// The color of the fuzzy drop shadow that displays when the mouse hovers over the checkbox.
        /// </summary>
        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register("ShadowColor", typeof(Color), typeof(ImageCheckBox));

        /// <summary>
        /// The image that will be displayed when the check box is checked.
        /// </summary>
        public ImageSource CheckedImage
        {
            get => GetValue(CheckedImageProperty) as ImageSource;
            set { SetValue(CheckedImageProperty, value); }
        }

        /// <summary>
        /// The image that will be displayed when the check box is not checked.
        /// </summary>
        public ImageSource UnCheckedImage
        {
            get => GetValue(UnCheckedImageProperty) as ImageSource;
            set { SetValue(UnCheckedImageProperty, value); }
        }

        /// <summary>
        /// The image that will be displayed when the check box is in an indeterminate state.
        /// </summary>
        public ImageSource IndeterminateImage
        {
            get => GetValue(IndeterminateImageProperty) as ImageSource;
            set { SetValue(IndeterminateImageProperty, value); }
        }

        /// <summary>
        /// The color of the fuzzy drop shadow that displays when the mouse hovers over the button.
        /// </summary>
        public Color ShadowColor
        {
            get => (Color)GetValue(ShadowColorProperty);
            set { SetValue(ShadowColorProperty, value); }
        }
    }
}
