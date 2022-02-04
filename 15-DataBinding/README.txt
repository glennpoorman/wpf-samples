DataBinding

This sample continues the tracking of girl scout cookie sales and starts to introduce some of the
things that make WPF cool. Visually and behaviorially, this sample is identical to the "MFCLike"
sample. Here we introduce the notion of "data binding" however. Using data binding, UI elements
can be "bound" to properties of your data elements. By default this is a two way binding which
means changes to your data are reflected in the UI and changes in the UI are reflected in your
data. This is one of the key features of WPF and will clean up the code significantly.

To watch it work, run the program. Note that as you click "Add Sale", the number in the "Sold"
textbox increases. Note that if you change that number by hand and then hit the "Add Sale" button
again, it increments from the number you typed in. On the surface this doesn't mean much until you
look at the code and find out that all of the plumbing from the previous sample that kept things
up to date has been removed and now we're letting WPF do all the work.

What's Different
----------------

* The "Scout" class has been modified quite a bit. For data binding to work, the "Scout" class
  must implement the "INotifyPropertyChanged" interface defined in System.ComponentModel.
  Implementing that interface means that the "Scout" class has to contain a "PropertyChanged"
  event.

* The "set" property accessors on "Scout" are now modified to fire off a "PropertyChanged" event
  whenever the property is changed. This will cause the data binding to occur when initiated from
  the data side.

* In the main window XAML, note that the "Text" properties on the text boxes are now set using the
  synax:

      Text="{Binding PropertyName}"

  where "PropertyName" is the name of the property we want to bind the text box to. Note that
  there is no specification of an object to bind to or even the type of object. All we're saying
  here is that whatever object we set as the data context must contain a property with the same
  name.

* Also note that we use data binding to bind the "IsEnabled" property of the subtract button to
  the "Sold" property on the scout instance.

      IsEnabled="{Binding Sold}"

  This way the enabling/disabling of this button that we devoted a fair amount of code to in the
  previous sample happens automatically based on whether or not that "Sold" property is non-zero.

* Since we are using data binding for all of our UI updating, we can remove the "Name" properties
  from the text boxes and the subtract button.

* Note that the code-behind is much leaner than in the previous sample. In the constructor, we
  have to set a data context to bind to. We'll use the single instance of the scout as the data
  context and set it on the window. Note that the way binding works is "routed". In other words,
  WPF first looks at the UI element where the binding occurred to see if there is a data context
  (i.e. the text box). If there isn't a data context, WPF moves up the tree until it finds one or
  runs out of elements. In our case, we've set the context on the window which indirectly parents
  both text boxes and the subtract button. That means this one call covers both text boxes and the
  button. We could have just as easily set the scout instance as the data context on the text box
  and the subtract button but that would have required three more lines of code and would also
  require that those elements remain named.

* The binding has allowed us to remove the "LostFocus" event handlers entirely and made the event
  handlers for the two buttons simple one-liners.

* Note that on text boxes, data binding occurs when the text box loses focus. This behavior can be
  changed but we'll cover that in a later sample.
