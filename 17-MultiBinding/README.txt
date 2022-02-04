MultiBinding

In this sample, we display a digital clock. This is done using data binding again. Here we
introduce the idea of a multi-binding which allows us to bind several source items into a single
target item (in this case, several properties from the data context into a single text block).

Note that the code-behind for the window in this sample contains no code other that what was
generated automatically. Virtually all of the work here is done in the XAML with just a small
amount of code in the data context (clock) object. Furthermore, once the sample has been built,
note that the clock actually runs in the XAML editor.

What's Different
----------------

* Introduced a custom "Clock" class. This class uses a timer and the system time to keep itself
  update to the current time every second.

* The clock derives from INotifyPropertyChanged and every second when the clock is updated to the
  current time, a notification is sent out that all of the clock properties have changed. Instead
  of sending out this notification for each property though, we send one notification passing in a
  null string for the property name. In WPF, this means that every property in the object has
  changed and should be updated.

* In the XAML, we introduce the "Background" and "Foreground" properties on the window changing the
  window background to black and the text/foreground color to white.

* We place a single text block in the window and use the long hand syntax to set the text property.

      <TextBlock.Text>...</TextBlock.Text>

  Note that we also introduce the "FontSize" property to increase the size of our displayed text.

* We introduce the "MultiBinding" object. This allows us to bind multiple sources to a single
  target. In this case, multiple clock properties to a single text block.

* The multi-binding has a "StringFormat" property that lets us specify the format of the textblock
  string using syntax that is very similar to standard C# string formatting.

      StringFormat="{}{0:D2}:{1:D2}:{2:D2} {3}"

  We first escape the string using "{}". After that, we specify that the string will contain four
  items. The first three will be 2-digit integers separated by semicolons. The last one is a string
  and is separated from the rest of the string with a space.

* The four items in the multi-binding are specified as the multi-binding content using four
  individual "Binding" objects. Each binding object binds to one of the different properties on
  our clock.
