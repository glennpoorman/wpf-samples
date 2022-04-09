using System.Windows;

namespace XAMLWindow
{
    /// <summary>
    /// The application main window class.
    /// </summary>
    /// <remarks>
    /// The main window class still derives from the WPF Window class. Like the application class,
    /// a good chunk of the code from the previous sample is no longer needed as the window is
    /// mostly defined in the XAML. In addition to window properties such as the width and height,
    /// the button from the previous sample is also defined and placed via the XAML spec.
    ///
    /// IMPORTANT: Also note that, like the application class, this class is defined as a partial.
    ///            This is required as additional code for this class will be generated at build
    ///            time from the XAML. Failure to define this class as a partial will result in a
    ///            build error.
    /// </remarks>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Main window class constructor.
        /// </summary>
        public MainWindow()
        {
            // The main window constructor must call "InitializeComponent" (a method generated from
            // the XAML) which sets up the window and any other window content specified in the XAML.
            //
            InitializeComponent();
        }

        /// <summary>
        /// Button click event handler shuts down the application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        /// <remarks>
        /// Note that this event handler was hooked up to the button in the XAML spec.
        /// </remarks>
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
