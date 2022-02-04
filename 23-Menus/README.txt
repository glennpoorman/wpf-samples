Menus

This sample returns to our girl scout cookie tracking application and introduces the idea of the
"main menu". The behavior of the app is essentially the same as the last sample that tracked cookie
sales but instead of using buttons to shut down the application or to bring up the about dialog, a
main menu has been added and the menu selections can be used to perform those tasks as well as
adding and/or subtracting sales from the scout's total.

What's Different
----------------

* We've added a "DockPanel" to be the main container. This was done so that we can dock a menu to
  the "Top" of the panel. The "StackPanel" from the previous sample is then placed so as to take up
  the remaining space in the dock panel.

* We introduce a "Menu" element docking it to the top of the dock panel. Menu items are added to
  the menu containing text, event handler and enabled/disabled properties just like a button. Note
  that like the "-" button, the menu contains a "Subtract Sale" menu item whose "IsEnabled"
  property is bound to the "Sold" property of the data context.

* The event handlers for the menu item click events are the same as the event handlers from the
  button click events in the previous sample so there is no change at all in the code-behind.
