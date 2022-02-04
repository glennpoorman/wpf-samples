using System;

// The System.Windows namespace is the top level namespace for WPF.
//
using System.Windows;

namespace StockWindow
{
    /// <summary>
    /// Main application class definition.
    /// </summary>
    /// <remarks>
    /// Like any other program written in C#, there has to be at least one class definition to hold
    /// the static main entry point.
    /// </remarks>
    public class StockWindow
    {
        /// <summary>
        /// The application's static main entry point.
        /// </summary>
        /// <remarks>
        /// The STAThread attribute indicates that the COM threading model for an application is
        /// single-threaded apartment (STA). This is required for WPF applications.
        /// </remarks>
        [STAThread]
        static void Main()
        {
            // Create a stock WPF "Application" object.
            //
            Application app = new Application();

            // Create a stock WPF "Window" object setting its title, width, and height properties.
            // Note that the window is not displayed at this time.
            //
            Window window = new Window()
            {
                Title = "StockWindow",
                Width = 525,
                Height = 350
            };

            // Call the "Show" method on the window. This method displays the window and
            // immediately returns without waiting for the window to close. In this particular
            // case, the window won't actually display until the application is run and the
            // message loop starts running.
            //
            window.Show();

            // Run the app. The window will display and the app will run until such time that
            // the app is shutdown. There are different ways this can happen. By default, the
            // application is shutdown when the last window is closed. That means that clicking
            // the "x" in the upper right corner of the window will shutdown the app.
            //
            _ = app.Run();
        }
    }
}
