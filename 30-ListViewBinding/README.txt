ListViewBinding

This sample has mostly the same functionality as previous sample except that we remove the listbox
and data template from the main window and use a list view element instead. The list view expands
on the list box idea allowing us much more control over how the list items are displayed. In this
case, we specify that each item will be broken into two columns. The columns in the view itself
contain labeled headers for "Name" and "Boxes Sold" describing to the user exactly what they're
looking at.

What's Different
----------------

* The only change in this sample is in the main window XAML file. The listbox and data template
  are removed and a "ListView" is specified instead.

* The listview requires formatting. In this case we put a "GridView" within the listview. The grid
  view has three columns each with their own text header "Name", "Boxes Sold", and "Level".

* The "DisplayMemberBinding" property on each column is used to tell WPF which property from the
  data context to display in the given column.

* The window resource section contains a style for "ListViewItem" setting the foreground color using
  the same "LevelToColorConverter" from the previous sample. The "ListViewItem" is a WPF object
  representing one item in a list view.

* NOTE: This sample runs as intended with ONLY a change to the XAML. No other code changes were
        required.
