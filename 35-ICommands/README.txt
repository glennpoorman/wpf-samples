ICommands

In this sample we implement our own command objects instead of using the WPF routed command objects.
Behaviorally the sample is the same as the previous samples but there are quite a few changes under
the hood. We implement our own command objects, hang them as properties off the window, and then set
the window as its own data context.

What's Different
----------------

* The "RelayCommand" class is introduced. This class implements the "ICommand" interface which means
  we can use instances of this class in the "Command" property of our UI elements in the XAML.

* The static data context has been removed from both the main window and the edit window. Instead
  we set the windows to be their own data context and we do this in the window constructors.

* The "CustomCommands" static class from the previous sample has been removed. Instead, instances of
  the new "RelayCommand" are created in the windows to handle the command required by those windows
  and are exposed as properties. The code to create those commands is very much like the code used
  to create command bindings in the previous sample using lambda expressions.

* In the XAML for the main window, the "Command" property on the various menu items and toolbar
  buttons is no longer set to a static resource but instead are bound to the command properties
  on the window.

* On the edit window, we also bind the "Ok" command to a command property on the window. We also
  change the binding for the textboxes. Since the window is now the data context, we need to
  reference the scout proxy property directly and then the properties of that scout like in the
  following line.

      Text="{Binding ScoutProxy.Name}"
