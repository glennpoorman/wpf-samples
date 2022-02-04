DockPanel

This application creates a new window containing several buttons in various positions and a list
box in the center. When most of the buttons are clicked, the text from the button is added to the
list box. The button labeled "Clear List" clears the list box. The button labeled "Close" shuts
down the application.

This sample shows how to use a "DockPanel" element. The dock panel is another form of container
that can contain any number of other UI elements. In the dock panel, the elements can be "docked"
to the top, bottom, left or right and their final position and size is dependent on the order in
which the elements were specified. This sample displays a new window when run. The window contains
seven buttons all docked to various sides of the panel. The last UI element specified is the list
box showing that, in a dock panel, the last element specified will fill in the remaining space of
the dock panel.

What's Different
----------------

* The main content in the window is a "DockPanel".

* Each of the buttons placed within the dock panel have their "DockPanel.Dock" property used to
  tell the button where to dock. Please note (as is documented in the XAML) that exactly how these
  buttons are placed is not only dependent on the docking but also on the order in which they were
  specified.

* A list box UI element is placed in the window. This element takes up the remaining dock panel
  space not used by the buttons. Also note that the list box is named using the "Name" property.
  This specifies a variable name that can be referenced in the code-behind to access methods and
  properties on the list box directly. Lastly, note that a "MouseDoubleClick" event handler is set
  on the list box to be called when a double click occurs anywhere within the list box.

* The code-behind contains a button click event handler shared by all but two of the buttons which
  will add the clicked button's text content to the list box. Note that the list box is referenced
  using the name given via the "Name" property in the XAML.

* The code-behind contains a button click event handler for the "Clear List" button that will clear
  the list box. Again the list box is referenced using the name given via the "Name" property in
  the XAML.

* The code-behind contains an event handler for the mouse double click event in the listbox. This
  event is fired even if the list is empty so we have to check for a valid selection. If we have
  one, we'll display a short message stating which string was selected.
