CommandsCode

This sample is identical to the previous sample in every respect except that instead of creating the
routed commands and the command bindings in XAML, those items are created in the C# code.

What's Different
----------------

* The "RoutedCommand" items are removed from the resources section of the window XAML file. Also,
  the entire "CommandBindings" section has also been removed. We'll still need these but we will
  create them in the code-behind.

* The static class "CustomCommands" has been added. This class contains a static "RoutedCommand"
  for each of the commands we'll use in both the main and edit windows.

      AddScout
      EditScout
      DeleteScout
      AddSale
      SubtractSale
      About
      Ok

* The main window now creates the command bindings instead of the XAML. Each binding is added to
  the window's "CommandBindings" list. Just like in the XAML, the constructor for a command binding
  takes an event handler to execute the command and an optional event handler to check if the
  command can be executed. Since we're specifying these event handlers in code now instead of XAML,
  the formal methods are gone and we specify the code using lambda expressions.

* Like the main window, the command resources and command bindings have been removed from the edit
  window XAML file. The "Ok" command is in the "CustomCommands" class with the other commands. In
  the edit window code-behind, we add the command binding in the window constructor and specify the
  code to be executed using lambda expressions.

