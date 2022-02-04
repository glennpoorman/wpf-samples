ComboBinding

This sample shows how to bind a combo box to an enum. The sample itself behaves very much like the
"ValueConverters" sample except that instead of radio buttons, we control the scout type using a
combo box.

What's Different
----------------

* The "GradeLevel" enum has been expanded to include all of the grade levels currently defined in
  the real girl scouts organization. In the previous samples we kept the number to three just to
  keep from cluttering up our window too much but with a combo box that is no longer an issue.

* Since we are no longer using radio buttons, the "LevelToBoolConverter" class has been removed
  entirely. Similarly, the "LevelToStyleConverter" has also been removed just to simplify a bit.

* The code for the "LevelToColorConverter" has been modified to take into account the new values
  added to the "GradeLevel" enum.

* In the resources section of the main window XAML, we introduce an "ObjectDataProvider". These
  objects can be used to wrap and create an object to be used as a binding source. In the combo
  box we're going to use, we're going to want to bind the "ItemsSource" property to a collection
  of possible values. We could create an observable collection by hand and expose it as a property
  but that would be kind of ugly and would require upkeep if the enum changes. Using the object data
  provider, we can provide WPF with a call to be made when the binding takes place. In our XAML,
  we specify a keyname (like we do for any resource), and type of object we want to call a method
  on, the method name itself, and the parameters.

      <ObjectDataProvider x:Key="gradeLevelValues" ObjectType="{x:Type sys:Enum}"
                          MethodName="GetValues">
          <ObjectDataProvider.MethodParameters>
              <x:Type TypeName="local:GradeLevel"/>
          </ObjectDataProvider.MethodParameters>
      </ObjectDataProvider>

  What we've done above was to essentially tell WPF to make the following call when doing the data
  binding:

      Array values = Enum.GetValues(typeof(GradeLevel));

  This is, of course, only one simple example of the flexibility of the object data provider.

* In the group box for grade levels, we've removed the radio buttons and replaced them with a single
  combo box.

      <ComboBox ItemsSource="{Binding Source={StaticResource gradeLevelValues}}"
                SelectedItem="{Binding GradeLevel}" IsEnabled="{Binding Count}"/>

  The "SelectedItem" and "IsEnabled" bindings for straight forward. The "ItemsSource" binding uses
  the object data provider we defined as a resource to fetch all of the possible values from the
  "GradeLevel" enum.
