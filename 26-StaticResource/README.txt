StaticResource

This sample is identical to the "DataTemplate" sample except that here we define the data template
as a static reusable window resource.

What's Different
----------------

* In the XAML instead of defining the data template right in the listbox spec, we define the data
  template as a static window resource and give it a key name. In the listbox spec, we then simply
  reference that definition using the property "ItemTemplate" and the key name. This allows us to
  define a resource such as a data template once and then reference that definition as many times
  as we'd like via the key name. These resources can also be defined in an external XAML file
  (called a resource dictionary) and included into the window XAML. This way static resources can
  be defined once and shared among multiple windows.
