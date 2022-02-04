ValueConverters

This sample shows how to bind the property of a XAML element to the property of a data context when
the two properties are not the same data type. For some binding, WPF will handle this automatically.
Consider how many times we've already bound the "IsEnabled" property of a control to the "Count"
property of a collection. In those cases, WPF has converted between a number and a boolean for us
automatically. In other cases though, the conversion is too complex. Especially when the only person
who could possibly know the desired outcome is the developer.

This sample, like the previous sample, works with different grade levels of scouts. Unlike the
previous sample that derived "Brownie", "Junior", and "Senior" classes from the "Scout" class and
then colored the text in the listbox based on data type, this sample has just the one class "Scout"
and adds a property to denote the grade level. The grade level itself is an enum. So in order to
bind, for example, the foreground color of a text block to the level property of the scout, we need
to know how to convert the value of the enum into a color. We also need a converter to convert the
value fo the level enum into a font style.

The trickiest part though is the radio buttons. In order to allow the user to designate the grade
level of a scout, we've added three radio buttons to the window each representing a grade level.
The "IsChecked" property of each radio button is bound to the grade level property of the scout.
How does this work though when "IsChecked" is just a boolean?

For radio buttons, we not only write a converter to convert between the grade level value and a
boolean, but we also pass the converter a parameter. Consider the "Brownie" button as an example
then. We'll bind "IsChecked" to the grade level of the scout and also pass in "Brownie" as a
parameter. The converter will query the data context, compare its level value to the parameter
"Brownie", and return true if they are equal and false if they are not. Similarly, when a user
checks a radio button via the UI, the same converter will set the level value of the data context
to the input parameter "Brownie".

A bit confusing for sure. Look at the comments in the XAML and especially the C# code for the
converters.

What's Different
----------------

* We've added a file "GradeLevel.cs" which contains an enum with the values "Brownie", "Junior",
  and "Senior". These values correspond to grade levels.

* We're back to just one scout class "Scout" but that class contains an additional property
  "GradeLevel" whose type is the new enum we defined in "GradeLevel.cs".

* Three converters have been added. The first two are designed to convert between the new grade
  level enum and another data type. In one case the data type is a color/brush and in the other
  case the data type is a font style. To do this, a new class is defined deriving from the WPF
  interface "IValueConverter". That interface contains two methods. One to convert from one type
  to another (in our case "Convert" converts from grade level to color or font style), and the
  other to convert back "ConvertBack".

  For our two simplest cases, we only implement "Convert" and leave the default implementation of
  "ConvertBack" simply throwing an exception. That's because this particular conversion is for a
  one way binding. In other words, a user can change the grade level which results in a conversion
  being triggered for display purposes but a user cannot change the color or font style directly.

  The "Convert" method checks our input to make sure its value and then runs through a simple set
  of "if" statements to return a color/brush based on the value of the grade level.

* The third converter is a bit trickier. As described above, here we're getting the grade level
  value from the data context and returning true or false depending on whether it matches an input
  parameter. This is a common conversion that takes place when binding radio buttons to an enum.
  Each button binds to the grade level and asks "is this your value?" and checks itself if the
  answer is yes and leaves itself unchecked if the answer is no. For our "Convert" function, we
  make sure we have a parameter, make sure the parameter is one of the values of the enum, and
  then return true if the parameter matches the current value.

  The "ConvertBack" method is a little more cryptic. This is the method that is called when the user
  clicks a radio button and we want to push the value back into the data context. Here we're only
  interested in doing something if the incoming value is "true" meaning that this particular radio
  button was just checked. In that case we simply set the parameter value as the new enum value on
  the data context. If the button was unchecked, we do nothing assuming the converter on the radio
  button that was checked will handle it.

* In the XAML, we need to create instances of our three new converters in the resources section of
  the window and give them key names that we can reference later.

      <local:LevelToColorConverter x:Key="levelToColorConverter"/>
      <local:LevelToStyleConverter x:Key="levelToStyleConverter"/>
      <local:LevelToBoolConverter x:Key="levelToBoolConverter"/>

  The first two are used in the data template and are used to set the foreground brush and the font
  style on the text block. The converters are used by simply expanding on the data binding syntac.

      <TextBlock
         Foreground="{Binding Path=GradeLevel, Converter={StaticResource levelToColorConverter}"
         FontStyle="{Binding Path=GradeLevel, Converter={StaticResource levelToStyleConverter}">

  Note that both the foreground brush and font style are binding to the same property on the data
  context but they are using different converters and the foreground requires a "Brush" and the
  font style requires a "FontStyle". When the binding occurs, our converters will be called.

* Also in the XAML, we added a group box with the header "Grade Level" that contains one radio
  button for each possible grade level. For each button, the "IsChecked" property is bound to the
  "GradeLevel" property on the data context but uses a value converter. In addition, this value
  converter requires a parameter so we pass that parameter in here.

  Taking the "Brownie" button as an example, the data binding for "IsChecked" looks as follows:

      IsChecked="{Binding Path=GradeLevvel,
                  Converter={StaticResource levelToBoolConverter},
                  ConverterParameter=Brownie}

  So when the conversion takes place, the converter will check the current value of the "GradeLevel"
  property on the data context and see if it equals "Brownie". If it does, "true" will be returned
  thus checking the radio button. If the value is not "Brownie", false will be returned unchecking
  the radio button.

* NOTE NOTE NOTE

  If you take a close look at the code for "LevelToBoolConverter", you'll note that there is no
  mention at all of the "GradeLevel" enum type. In fact, the converter was written very generically
  in such a way that it can be used with any enum.
