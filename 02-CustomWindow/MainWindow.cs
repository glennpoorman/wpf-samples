using System;
using System.Windows;
using System.Windows.Controls;

namespace CustomWindow
{
    /// <summary>
    /// The application main window class.
    /// </summary>
    /// <remarks>
    /// We derive this class from the WPF Window class.
    /// </remarks>
    public class MainWindow : Window
    {
        /// <summary>
        /// Main window class constructor.
        /// </summary>
        public MainWindow()
        {
            // We can set any number of properties on the window here in the constructor. In this
            // case, we'll set the window title and we'll also set the window's initial width and
            // height.
            //
            Title = "CustomWindow";
            Width = 525;
            Height = 350;

            // Create a button object (System.Windows.Controls.Button) and set the button content
            // property as well as the width and height properties.
            //
            // In this case the button content is a simple text string but WPF does not limit what
            // you can put here (as we'll look at in later samples).
            //
            // As far as size goes, WPF controls or framework elements fill the space of their parent
            // by default. If we didn't set any size or position here, the button would take up the
            // entirety of the window. As you'll see in coming samples, there are several different
            // ways that controls can be positioned and sized and many depend on the type of the
            // parent element. In this sample, we'll explicitly set the width and height of the
            // button. With no additional positioning information, WPF will keep the button positioned
            // in the center of the window even as the window is resized.
            //
            Button button = new Button()
            {
                Content = "Close",
                Width = 200,
                Height = 25
            };

            // To define the behavior of the button when clicked, we can add an event handler
            // (implemented below) for the button "Click" event.
            //
            button.Click += ButtonClick;

            // Add the button to the window.
            //
            // Note that the window can only contain a single content element. If we wanted to add
            // more than just a single button, we would need to use a more complex WPF container
            // element. We'll look at some these container elements in later samples.
            //
            Content = button;
        }

        /// <summary>
        /// Button click event handler shuts down the application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void ButtonClick(Object sender, RoutedEventArgs e)
        {
            // By default, the application will shut down when the last open window is closed. In
            // this case, this is the only open window so calling close on it will shut down the
            // application.
            //
            Close();
        }
    }
}
