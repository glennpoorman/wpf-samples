ContextMenus

This sample adds a simple context menu to the individual list items that allows the user to execute
commands on individual scouts.

What's Different
----------------

* The "ContextMenu" element is introduced. Several XAML elements allow for the addition of a context
  menu. Like several other types of elements, this can be done right in the element definition or as
  a static resource. In our case we are putting the context menu on a "ListViewItem" so we to do it
  as a static resource.

* In the data binding for the menu items, we use the "RelativeSource" property again but introduce
  the "FindAncestor" mode. This essentially walks up the UI element tree looking for an ancestor
  using some criteria. Here we specify we want to locate the closest ancestor whose type is
  "ListView". Once we get it, we bind to the "DataContext.CommandName" property. Honestly it's not
  clear to me why we had to do this. Simply binding to the command name didn't work and I found this
  solution after an extensive Google search but I still don't understand why I needed it.

* In the style for "ListViewItem", we add a "Setter" to set the "ContextMenu" property using the
  static resource we just created.

* No other changes were made. The menu items bind to commands that already existed and were designed
  to operate on the currently selected scout.
