ViewModels

In this sample we add a layer of abstraction in between the UI and the underlying data. This layer
is similar to the scout copy/proxy we introduced in previous samples but instead of just using a
copy of the original data, we create a new class that not only contains the same editable fields
that the original data contained but will also contain the commands designed to operate on that
data. This not only includes a scout but also the scouts collection. We'll refer to these abstraction
layers as "view models" in prep for the coming MVVM (model-view-viewmodel) samples.

What's Different
----------------

* A new base class "NotifyPropertyChanged" is introduced. This class implementations the interface
  "INotifyPropertyChanged" and will be used by any class that requires this functionality. In
  addition, the "Scout" class now derives from "NotifyPropertyChanged" and no longer contains the
  "PropertyChanged" event handler or the "Notify" method directly as those have been moved to the
  new base class.

* The "ScoutsViewModel" class is introduced to add a layer of abstraction between the main window
  and the scouts collection. Both the collection and the view model still send off notifications
  of property changes. The list view in the main window still keys off the collection itself but
  the commands are now properties on the view model and the view model is set as the data context
  on the window.

* The "ScoutViewModel" class is introduced to add a layer of abstraction between the edit dialog
  and the individual scout selected to be edited. The command used in the edit dialog is now a
  property on the view model. In addition, the view model contains a "Name" and "Sold" property.
  Those properties act as proxy between the window and the scout allowing the user to make edits
  but not to make those edits permanent until such time that the changes are saved.

* The main window XAML has regained the static data context although now the data context is the
  "ScoutsViewModel" object.

* The edit window XAML has regained the static data context which is now the "ScoutViewModel" object.
  The binding in the textboxes has been changed back to simply "Name" and "Sold" and those are now
  properties on the view model.

* The "ScoutsViewModel" now contains all of the main window commands. Three of the commands in the
  main window (edit scout, about, and exit) still require interaction with the UI though and as a
  rule we'd like to keep an UI-specific code out of the view model. To do this, we added three
  events to the view model. "EditRequested", "AboutRequested", and "CloseRequested" will be fired by
  the commands "EditScout", "About", and "Exit" to tell the owning window that these operations
  need to be executed by code that has UI knowledge. The owning window is then left with the
  responsibility to register handlers for these events and take care of these requests.

* The "ScoutViewModel" now contains "Name" and "Sold" properties that will act as a proxy between
  the window and the scout. The textboxes in the window will be bound to those properties and
  changes won't be saved back to the original scout until the "Ok" command is executed. The "Ok"
  command has also been moved to the view model. Like the main window, we want to keep UI-specific
  code out of the view model. The "Ok" command can go ahead and save the changes made to the scout
  but to close the dialog, we needed to define a "CloseRequested" command and have the "Ok" command
  handler fire off that event. The owning window is then left with the responsibility to register
  a handler for the event and take care of closing the dialog.

* The main window code-behind is now very lean again. The constructor has extra code to add event
  handlers for the new "EditRequested", "AboutRequested", and "CloseRequested" events. The first
  brings up the edit dialog with the selected scout (passed as a parameter). The second brings up
  the about dialog. The last closes the window shutting down the application.

* The double click handler is still part of the main window code-behind.

* The edit dialog code-behind is now very lean as well. The "ScoutProxy" is gone and aside from the
  initialization, the constructor adds an event handler for the "CloseRequested" event which sets
  "DialogResult" to true essentially closing the dialog.
