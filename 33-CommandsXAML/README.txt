CommandsXAML

This sample removes UI element event handlers and replaces them with commands. The command is a WPF
construct that separates the idea of the command from the UI. On the surface, the command appears to
have little difference and doesn't really save work (in most cases it adds a little work). But the
command allows us to separate the work out of the UI code and it can also be triggered from many
different places (menu selections, toolbars, keyboard activity, just about any place).

Behaviorally this sample is no different from the previous.

What's Different
----------------

* In the main window XAML file, we introduce several <RoutedCommand> objects in the static resources
  section. These resources are given names and represent the various operations we want to handle.

      AddScout
      EditScout
      DeleteScout
      AddSale
      SubtractSale
      About

* Also in the main window XAML, we add command bindings for each command. These objects bind the
  commands to the event handlers that will execute them. Each command binding must set the "Execute"
  property setting the event handler that will execute the command. Optionally the "CanExecute"
  property can be set with an event handler that will make sure the command can be executed. The
  return value of that event handler will enable/disable any controls associated with the command.

  Note the additional binding for the "Close" command. WPF provides definitions for several commands
  which means we don't have to. So while there was no definition for a "Close" command in the
  resources section, we create a binding to bind an event handler to WPF's "ApplicationCommands.Close"
  object.

* All references to the "Click" and "IsEnabled" properties in the menu items and toolbar buttons
  have been removed and replaced with "Command" properties. The commands defined here in the XAML
  are referenced by key name.

      Command="{StaticResource AddScout}"

  A command defined in code (such as WPF's "Close" command), the command is referenced directly.

      Command="ApplicationCommands.Close"

* The functions to handle click events are replaced by functions to handle the commands. The code
  in these functions are the same, but the function signature is slightly different.

* Some commands are also bound to functions that specify whether or not a command can be executed.
  These functions simply return true or false. If false is returned, it means the command cannot
  execute and any UI elements using this command are disabled. If the function returns true, the
  command is free to execute.

* WPF doesn't provide a way to set a command on the double click event (something many people
  consider an oversight) so we still need the event handler for the double click in the list view.

* Similar to the main window, the edit window XAML defines a single routed command named "Ok". A
  single command binding binds the "Ok" command with an event handler that will save any changes
  made to the scout and then close the window. An additional event handler is specified in the
  binding that will make sure the scout is named before enabling the "Ok" button.
