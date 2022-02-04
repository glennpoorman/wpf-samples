TypedDataTemplates

This sample shows how to use typed data templates. By specifying a "TargetType" with no key in a
data template, you are telling WPF to use this template automatically whenever displaying an item
of a given type. In this sample we still track the cookie sales of girl scouts but we break them
into grade levels "Brownie", "Junior", and "Senior". New classes for these different levels are
derived from the class "Scout" and menu items are added so that you can decide which level of scout
you want to add to the list. Visually, you can differentiate between levels in the list as the text
color and font styles used to display the items in the listbox will vary depending on level/type.
We do this by applying data templates that key off the data types of the list items.

What's Different
----------------

* Three new classes ("Brownie", "Junior", and "Senior") have been added deriving from the original
  "Scout" class. These classes don't provide any additional functionality but simply serve to 
  differentiate the types.

* In the main window XAML, we replaced the "Add Scout" menu item with the three items "Add Brownie",
  "Add Junior", and "Add Senior".

* In the main window resources section of the XAML, we added three data templates that are based on
  the data type. Within that window then, any time that an item is added to the list, the item
  type's corresponding data template will be used automatically to display the item. In this case,
  the three templates only differ in the text color and font style of the text block that is used
  to display them.

* The listbox item contains no display member path or data template. Instead we rely on the typed
  data templates to format the list items.

* In the main window code-behind, we replaced the "AddScoutClick" event handling method with the new
  "AddBrownieClick", "AddJuniorClick", and "AddSeniorClick" methods.
