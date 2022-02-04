DataTemplate

This sample has mostly the same functionality as "ListBinding". In that sample, each item in the
list was bound to the scout's "Name" property and so the name is what was displayed in the list.
We can put more information into each item in the list though by using a data template to specify
exactly how each list item is displayed. In our data template, we'll use a multi-binding in order
to bind both the "Name" and "Sold" properties to a single text block separated by a dash. This
gives us a bit more information right in the list.

What's Different
----------------

* In the XAML, our listbox item has a "ItemTemplate". That item contains a "DataTemplate" that
  specifies a single text block. The text block uses a multi-binding to bind both the "Name" and
  "Sold" properties of the scout to the single line of text.
