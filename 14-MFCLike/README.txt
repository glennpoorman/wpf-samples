MFCLike

In this sample we're going to plug in some data and code up some interaction between data and UI.
The application itself will track one girl scout and the number of cookie boxes she has sold
(seemed like as good an idea as any). This same theme will be repeated many times in the coming
samples.

We'll start off by using the very basic WPF and XAML UI layout and handling the interaction in a
very MFC-Like fashion. That means a lot of code in the code-behind to handle events and to copy
data around. You could look at this as an example of how NOT to write WPF code but it makes a good
starting point in which to introduce some of the more interesting WPF features.

The sample itself displays a new window. Contained in that window is a text box containing a scout
name and the number of boxes of cookies the scout has sold (initially zero). The scout's name and
the number of boxes can be edited via the two text boxes. Additionally, the number of boxes can be
incremented and/or decremented using the "+" and "-" buttons that appear next to the "Sold" textbox
in the main window.

What's Different
----------------

* We introduce another new element "<Separator>". In the main window XAML, we place a text block at
  the top describing what the application does. Just after that we place a "<Separator>" element.
  The seperator element is simply a control used to separate groups of items by drawing a horizontal
  or a vertical line. We'll see this element again later on when we talk about menus.

* We assign event handlers to respond to "LostFocus" events on the text boxes. These events fire
  when a text box that had focus loses focus. In our sample, we take this to mean that the user
  has done something and is now "finished".

* The "IsEnabled" property is referenced in the XAML on the "-" button. In our simple app, it
  doesn't make sense to subtract from a scout that has no sales so we want this button to wake
  up disabled.

* This sample introduces a class to represent our scout data. The class is very simple containing
  just two properties for the scout name and the number of cookie boxes sold.

* The code-behind for the main window is kind of a mess. There is a single scout instance that the
  application will operate on and the constructor initializes the text boxes using the data from
  that scout instance.

* The "+" and "-" event handlers increment or decrement the "Sold" property on the scout instance
  directly and then copy the result to the text box. In addition, the subtract button is enabled
  and disabled depending on the number of boxes sold.

* The "LostFocus" event handler for the name box copies the string from the text box into the
  scout instance but only if the text box is not empty.

* The "LostFocus" event handler for the number of boxes sold performs all manner of plumbing. The
  text from that box has to be converted into an integer so that the data on the scout instance
  can be updated. We need to make sure that the format is such that this can be done. Additionally,
  we have to make sure that the resulting integer is not less than zero. Lastly, we have to enable
  or disable the subtract button depending on the final value of the boxes sold property.
