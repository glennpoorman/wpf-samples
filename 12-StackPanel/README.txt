StackPanel

This application creates a new window containing several different types of child elements arranged
into a container element. Click the check boxes and radio buttons will display a message stating
which control was clicked. The "Close" button shuts down the application.

This sample shows how to use the "StackPanel" element. The stack panel is a container element that
allows child elements to automatically be arranged in a line that is oriented either horizontally
(left to right) or vertically (top to bottom). The sample displays a new window when run. The window
contains a static text block, a textbox, a group box with three checkboxes, a group box with three
radio buttons, and finally a "Close" button that all stack vertically from top to bottom. Each of
the group boxes contain a stack panel oriented horizontally. The first stack panel contains three
checkboxes stacked from left to right and the second contains three radio buttons also stacked from
left to right. At the bottom of the stack is a "Close" button. The button content consists of another
stack panel oriented horizontally. That panel contains an image representing a close icon followed by
the string "Close".

What's Different
----------------

* The main content in the window is a "StackPanel".

* The elements (a text block, textbox, two group boxes, and a button) are stacked from top to
  bottom without the need for any additional positioning information except for some margins to
  put some space between elements.

* Each group box contains a horizontally oriented stack panel containing a handful of child
  elements. Each of those group boxes use the "Padding" property to give the contents some space.

* The "RadioButton" control is used. In this sample only three buttons are used and they belong to
  a single group by default. The first is checked by default using the "IsChecked" property. When
  multiple groups of radio buttons are used in the same window, they can be grouped using the
  "GroupName" property.

* The "Close" button contains a horizontally oriented stack panel. The two items in that panel are
  an icon image followed by the string "Close".
