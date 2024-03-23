using System;
using System.Windows;

namespace CustomWindow
{
    /// <summary>
    /// Main application class definition.
    /// </summary>
    /// <remarks>
    /// Note that we derive from the WPF application class and that this class also serves to
    /// contain the static main entry point.
    /// </remarks>
    public class App : Application
    {
        /// <summary>
        /// The application's static main entry point.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            // Create an instance of the custom application class (this class).
            //
            App app = new();

            // Add a handler for the application "Startup" event. This handler (implemented below)
            // will be called when the application is run.
            //
            app.Startup += app.AppStartup;

            // Run the application (which will call our event handler).
            //
            _ = app.Run();
        }

        /// <summary>
        /// The application "Startup" event handler is where we will create and show the main window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void AppStartup(Object sender, StartupEventArgs e)
        {
            MainWindow window = new();
            window.Show();
        }
    }
}
