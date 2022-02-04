Styles

This sample is identical to "StackTemplate" except that the properties applied to the check boxes
and the radio buttons have been moved into a single "Style" item and that style item is then
applied to the check boxes and radio buttons. This allows the appearance of those items to be
defined in one place and would allow us to change the appearance of all those items by simply
modifying the style element.

What's Different
----------------

* In the XAML we introduce the "Resources" section. This is where reusable items can be defined for
  later use. Any XAML element can contain resources and those resources can be used by that element
  or any of its children.

* The "Style" element is used to create a group of property value assignments. The "Setter" element
  is used to set property values and the "EventSetter" is used to set event handlers. Two different
  ways to define a style are shown. The first uses the "x:Key" tag to give the style a name that
  can be reference later. The second uses the "TargetType" tag to specify that this style be applied
  to all elements in the window of that type.

* In our check box elements, we introduce the "Style" tag name to specify the style to be used for
  the check box element and reference one of our pre-defined style resources by name.
