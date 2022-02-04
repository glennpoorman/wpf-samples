GridMultiCell

This application, again, creates a new window. The window contains samples of several different
types of child elements arranged in a container element. Clicking the check boxes  will display
a message stating which check box was clicked. The "Close" button shuts down the application.

This sample shows how to use a multi-cell "Grid" defining a grid with three rowns and three columns
and arranging the elements into the various grid cells. An additional grid with just a single row
and three columns is created inside of the group box and is used to place the three check boxes.

Grid rows and columns have a lot of flexibility as far as sizing. Here we keep things simple and
use the defaults resulting in a 3x3 grid of equally sized cells. While running this program, play
with resizing the window and watch what happens to the cells.

What's Different
----------------

* Right after the grid spec is started, we use the "Grid.RowDefinitions" and the
  "Grid.ColumnDefinitions" properties to specify that the grid contains three rows and three
  columns.

* Elements are placed into the various grid cells using the "Grid.Row" and "Grid.Column"
  properties. Note that these are zero based.

* Some elements span multiple columns and this is set using the "Grid.ColumnSpan" property. There
  is also a "Grid.RowSpan" property that can be used to make elements span multiple rows. That
  property isn't used in this sample though.

* A "Help" button is added for no other reason than to show additional samples of spreading
  controls across grid cells.
