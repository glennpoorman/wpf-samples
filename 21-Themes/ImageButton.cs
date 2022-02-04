using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Themes
{
    /// <summary>
    /// Custom image button class definition.
    /// </summary>
    public class ImageButton : Button
    {
        /// <summary>
        /// Static button constructor.
        /// </summary>
        static ImageButton()
        {
            // One time initialization overrides the default style to use our style defined in the
            // "ImageButton.xaml" file instead of the default style from the "Button" class.
            //
            // Note: Without this, the new type of button would continue to use the default "Button"
            //       style unless we specifically pulled the resource dictionary "ImageButton.xaml"
            //       into the window or control where we use the button.
            //
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton),
                new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

        /// <summary>
        /// The image that will be displayed.
        /// </summary>
        /// <remarks>
        /// This the registration/creation of the static depedency property. When the property
        /// is referenced in WPF (using the name "Source"), it is referenced through the WPF
        /// dependency property mechanism which contains all registered properties.
        /// </remarks>
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(ImageSource), typeof(ImageButton));

        /// <summary>
        /// The color of the fuzzy drop shadow that displays when the mouse hovers over the button.
        /// </summary>
        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register("ShadowColor", typeof(Color), typeof(ImageButton));

        /// <summary>
        /// The orientation of the image/content ("Horizontal" or "Vertical").
        /// </summary>
        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(ImageButton));

        /// <summary>
        /// The image that will be displayed.
        /// </summary>
        public ImageSource Source
        {
            get => (ImageSource)GetValue(SourceProperty);
            set { SetValue(SourceProperty, value); }
        }

        /// <summary>
        /// The color of the fuzzy drop shadow that displays when the mouse hovers over the button.
        /// </summary>
        public Color ShadowColor
        {
            get => (Color)GetValue(ShadowColorProperty);
            set { SetValue(ShadowColorProperty, value); }
        }

        /// <summary>
        /// The orientation of the image/content ("Horizontal" or "Vertical").
        /// </summary>
        public Orientation Orientation
        {
            get => (Orientation)GetValue(OrientationProperty);
            set { SetValue(OrientationProperty, value); }
        }
    }
}
