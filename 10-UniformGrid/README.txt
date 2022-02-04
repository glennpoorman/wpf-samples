UniformGrid

This application, again, creates a new window. The window contains samples of several different
types of child elements arranged in a container element. Clicking the check boxes will display
a message stating which check box was clicked. The "Close" button shuts down the application.

This sample shows how to use the "UniformGrid". The uniform grid is a simplified version of the
regular grid. In a uniform grid, all cells are the same size and are created automatically as
child elements are placed. By default, the uniform grid decides how the rows and columns are
arranged. The cells are created on the fly and the grid does its best to keep the grid square.
By using the "Rows" and "Columns" properties on the grid itself, you can hint to the grid how
you want the cells arranged. For example, placing four items in a uniform grid without any
additional properties will result in a 2x2 grid. If you, for example, were to set the "Rows"
property to 1 and the "Columns" property to 4, then placing four items in the grid would result
in a 1x4 grid.

Also note that a uniform grid cell can only contain a single item (although that item can be a
container element).

What's Different
----------------

* We use a "UniformGrid" element and specify that the grid contain three rows and one column.

* Since a uniform grid cell can only contain one element, we can't have our text label and
  textbox in the same cell unless we use a container. Here we use a group box. Since the group
  box header serves as our label, the group box only need contain the textbox as content.

* Inside the group box that contains our three check boxes, we place a 1x3 uniform grid. Each
  check box then goes into one of the three cells.
