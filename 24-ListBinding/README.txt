ListBinding

In this sample, we expand the functionality of the girl scout cookie tracking system. Instead of
keeping track of cookie sales for a single scout, we can keep track of sales for a whole troop.

In addition to the text boxes from the previous sample, we also add a listbox that can keep track
of any number of scouts. Using some new menu items, scouts can be added and removed from the list.
Any scout selected in the list will have her name and number of boxes sold put into the text boxes
where they can be edited. Name edits will be reflected back in the list.

Using WPF's data binding and using a collection, these enhancements are done with very little added
code.

What's Different
----------------

* We introduced a "Scouts" class which is a collection of scouts. The class derives from
  "ObservableCollection<T>". That class implements both the "INotifyCollectionChanged" and
  "INotifyPropertyChanged" interfaces which makes it usable for data binding and also for binding
  to a list element.

* In this sample the collection is being used as the data context. We determine the enabling or
  disabling of several menu items and our text boxes by binding "IsEnabled" to the "Count" property
  on the collection.

* The "Subtract Sale" menu item needs to bind to the "Count" propery on the collection but also
  needs to continue to bind to the "Sold" property on the selected scout. We introduce
  "PriorityBinding" on that menu item which allows us to bind to both of those properties.

* We introduce a listbox element in the XAML. The list box binds to and uses the collection as its
  source of data. The "IsSynchronizedWithCurrentItem" method makes sure that the binding for the
  list is always synched to the currently selected item.

  What does that mean?

  It means that when UI elements are bound to a data context that happens to be a collection, the
  binding will first see if the collection itself contains the property name you are trying to bind
  to. If it does not, then instead of quietly failing, the binding will then check the currently
  selected item in the list for that property name (see detailed notes in the XAML).

* We introduce the use of the "ICollectionView" interface which acts as a layer on top of a bound
  collection. This interface can be used to determine things like the currently selected item or to
  move the current selection around.
