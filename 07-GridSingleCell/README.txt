GridSingleCell

This application creates a new window. The window contains samples of several different types of
child elements arranged in a container element. Clicking the check boxes will display a message
stating which check box was clicked. The "Close" button shuts down the application.

This sample uses the "Grid" container element. The grid is a very powerful container allowing
layouts in the form of columns and rows. Within those grid cells, elements can be positioned and
sized relatively to the cell using alignment and margin properties.

When creating a WPF window, the default Developer Studio behavior is to insert a single "Grid"
element into the XAML file with no row or column specifiers which defaults the grid to a single
cell. Even within that single cell, the relative positioning using alignment and margins offers
quite a bit of flexibility.

This sample uses a single cell grid along with those alignments and margins to create a window very
similar to the previous sample. Read through the XAML comments carefully and then, when running the
program, note what happens to the various controls when you resize the dialog.

What's Different
----------------

* Instead of a "Canvas" element, the controls are contained within a single cell "Grid" element.

* For positioning, we make heavy use of the "Margin", "HorizontalAlignment", and "VerticalAlignment"
  properties. Use of these properties allows for some nice automatic resizing of elements when the
  user resizes the containing window.

* The group box revisits the "Padding" property to pad the interior of the box giving the child
  elements some breathing room without having to add any margins to the individual elements.
