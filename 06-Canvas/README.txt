Canvas

This application creates a new window. The window contains samples of several different types of
child elements arranged in a container element. Clicking the check boxes will display a message
stating which check box was clicked. The "Close" button shuts down the application.

This sample introduces the notion of a container element. Earlier we mentioned that a window can
only contain one content element. Up to now, we've only set a single button as the window content.
If you want more than one item in your window, you can use a container element as the window content
and place additional elements within that container. If you're a Win32 and/or MFC programmer
(accustomed to creating dialog resources in RC files), the "Canvas" element will be the most
familiar. The WPF canvas element ia a container that allows absolute positioning of child elements.

Note how poorly this container behaves when the window is resized.

What's Different
----------------

* "MinHeight" and "MinWidth" properties are added to the "Window" specification in the XAML file.
  These properties restrict how small the user can make the window using the mouse. There are also
  "MaxHeight" and "MaxWidth" properties available but we don't use those here.

* Instead of a single button, the window contains a "Canvas" element. Within the canvas element,
  several child elements (controls) are positioned. The elements are positioned absolutely within
  their parent canvas using the "Canvas.Top" and "Canvas.Left" properties.

* The "TextBlock" and "TextBox" controls are used in this sample. The text block is a static text
  control while the textbox is like a standard Windows edit box.

* The "GroupBox" is also used in this sample. WPF group boxes are very similar to Win32 group
  boxes. Like a window or button though, a group box can only contain a single content element.
  We want to put three check boxes within the group box so we create an additional canvas as the
  group box content.

* Three "CheckBox" elements are positioned in the group box canvas using the "Canvas.Top" and
  "Canvas.Left" properties. In the case of these check boxes, those properties position the boxes
  relative to the inner canvas (as you would expect).

* The three check boxes all have the same event handler "CheckBoxClick" set on them to handle a
  mouse click event. Pressing any of those buttons simply displays the button text. The event
  handler uses the input "sender" parameter to determine the state of the check box and to
  determine the check box content and displays a message displaying both.
