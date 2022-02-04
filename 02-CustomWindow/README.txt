CustomWindow

This application creates and shows a new window with a single "Close" button in the middle that
shuts down the application when clicked.

What's Different
----------------

* Instead of creating stock "Application" and "Window" objects, we define our own application and
  window classes deriving from those stock WPF classes.

* Instead of creating and showing the window in the main entry point, we set an event handler on
  our custom application object for the "AppStartup" event. When the app is run, the event is fired
  at which time our event handler creates and shows the window.

* The window title along with the initial width and height properties are set in our custom window
  constructor.

* The window constructor also contains code to create and place a button in the window. By default,
  a button placed in a window will fill the window. We explicitly set a width and height resulting
  in a fixed size button that always remains in the center of the window. Other methods of sizing
  and positioning controls will be discussed in later samples.

* A "Click" event handler is set on the button that is called when the button is clicked. The
  handler simply calls "Close" on the window. By default in WPF, an application shuts down when
  its last window is closed so by closing the main window, we shut down the application.
