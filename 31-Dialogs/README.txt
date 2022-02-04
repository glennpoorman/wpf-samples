Dialogs

This sample introduces the idea of an "edit" dialog for an individual scout. Mostly the behavior is
the same as the previous samples. The main window has a list of scouts and the menu can be used to
add scouts, delete scouts and modify their sales tally.

Here however, we've removed the text boxes that allowed the currently selected scout to be edited
and instead introduce an edit dialog. The edit dialog can be shown on the currently selected scout
by selecting the new "Edit Scout" menu item or by double clicking a scout in the list view.

What's Different
----------------

* We introduce the "EditDialog" (a XAML and cs file). At the top of the XAML, we use the
  "FocusManager.FocusedElement" to set the focus to specific UI element when the dialog is first
  shown. In this case, the "Name" text box.

* The edit dialog code-behind will contain two instances of a scout. One will be the original scout
  that was selected to be edited and the second will be a copy/proxy of that scout which will also
  be the window's data context. WPF doesn't provide a way to roll back changes to a data context if
  the user wants to cancel editing. So when the edit window first wakes up, we'll copy data from the
  originally selected scout into the scout proxy. It's that proxy that will be edited while the
  dialog remains open. If the user selects "Ok", then we'll copy data from the data context back
  into the originally selected scout. If they select "Cancel", we'll simply discard the data context
  leaving the originally selected scout alone.

* The data binding for the two text boxes use the "UpdateSourceTrigger" property. By default, text
  boxes do their data binding when they lose focus. In this sample, we want the binding to happen
  whenever there is a text change event so that we can enable/disable the "Ok" button while the
  user is typing. So we change the trigger from the "LostFocus" default to "PropertyChanged."

      Text="{Binding Path=Name, UpdateSourceTrigger=PropertyChanged}"

* We added an "IsValid" property to the "Scout" class and bound the "Ok" button in the edit window
  to that property. That way we can disable the button if the user has not provided enough data.

* The code-behind for the edit dialog implements an event handler for the "Ok" button click. This
  event handler copies the data from the data context back into the originally selected scout and
  then sets the window "DialogResult" property to true. Setting that property will cause the
  "ShowDialog" call that originally brought up the window to return true and will also cause the
  dialog to close without us having to do it explicitly.

* In the main window XAML, we added an "Edit Scout" item to the menu that will be used to bring up
  the new edit dialog on the currently selected scout.

* The name and sold textboxes as well as the "+" and "-" buttons from the previous samples have
  been removed from the main window since now we will edit the scout via the dialog.

* A mouse double click event handler was added to the list view. We will use that event to bring up
  the edit dialog on the currently selected scout.

* In the event handler for the "Edit Scout" menu selection and for the mouse double click event, we
  bring up the edit dialog on the currently selected scout. To do this modally, we create the dialog
  and call "ShowDialog".
