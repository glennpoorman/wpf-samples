XAMLWindow

Like the previous sample, this application creates and shows a new window with a single "Close"
button in the middle that shuts down the application when clicked.

What's Different
----------------

* This sample introduces XAML which stands for extensible application markup language and is
  generally pronounced "zamel" (like "camel"). The application is specified using XAML in the
  "App.xaml" file. Here the class is specified as well as the XAML file defining the main window
  that will be created and shown when the application is run. This leaves the actual code in the
  C# application class definition (referred to as the "code-behind" and contained in "App.xaml.cs")
  very lean and simple.

* Like the application, much of the window is specified using XAML in the "MainWindow.xaml" file.
  Here we specify the window class name, the window title and the initial width and height. The
  button that shows up in the center of the window is also specified in the window's XAML file as
  well as the button content and the name of the event handler to call when the button is clicked.

* The code-behind for the window (the C# class defined in "MainWindow.xaml.cs") is now much leaner
  and simpler. The constructor simply calls the WPF defined "InitializeComponent" to initialize
  all of the elements specified in the XAML. The button event handler is still defined in the
  code-behind.
