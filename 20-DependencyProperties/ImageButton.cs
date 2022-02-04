using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DependencyProperties
{
    /// <summary>
    /// Custom image button class definition.
    /// </summary>
    /// <remarks>
    /// The image button derives from the WPF button and is designed to display an image and to
    /// optionally display the button content to the right or below that image. This is mostly done
    /// using the style and control template in "ImageButton.xaml" but the class contains some
    /// additional dependency properties needed to control some aspects of the button display.
    /// </remarks>
    public class ImageButton : Button
    {
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
        /// <remarks>
        /// This is the property that is reference via code. If you have a reference to an image
        /// button and reference the "Source" property, you'll hit these accessors which simply
        /// act as pass throughs to the registered dependency properties.
        /// </remarks>
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
