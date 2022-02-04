ThreeStateCheck

This sample displays a group of three checkboxes that can either be checked or unchecked. A fourth
checkbox can be used to check or uncheck all of the other three at once. The fourth checkbox also
shows the current state of the other three. The purpose of this sample is to show that all WPF
checkboxes can potentially be three state checkboxes and how to work with the the third state.

What's Different
----------------

* Introduced a custom "CheckBoxManager" class in order to bind the checkboxes to something. Most
  of the class is fairly dumb. There is a "bool" property for each of the first three checkboxes
  and the "IsChecked" property of each checkbox is bound to the corresponding property on the data
  context.

* In order to represent three states, the fourth property on the data context is a nullable bool
  (bool?). Binding the "IsChecked" property of a checkbox to a nullable bool means that a true/false
  value behaves just like with a normal checkbox but returning a null tells the checkbox that it
  should show an indeterminate (third) state.

* Note in the XAML that we didn't have to do anything special in the code behind. All WPF checkboxes
  can show a third state. This can be done by binding the "IsChecked" property to a nullable bool
  property on the data context or even by setting the "IsChecked" property explicitly using the
  syntax:

      ... IsChecked="{x:Null}" ...

* Note that the WPF checkbox also contains a property called "IsThreeState" that we didn't use here
  and defaults to false. Setting that property true means that the user can cycle through all three
  states when clicking the checkbox. There is rarely an occasion where this would be useful though.
  Think about this sample. What would it mean for the user to click into an "indeterminate" state?
