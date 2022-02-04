StaticContext

This sample shows how the data context for a XAML element can be instanced and set right in the XAML
as opposed to explicitly creating and setting it in the code-behind. The sample itself is identical
to the "DataBinding" sample except for the method in which we set the data context.

What's Different
----------------

* An additional "xmlns" element is added to the window spec in the XAML.

      xmlns:local="clr-namespace:StaticContext"

  The additional line creates a key called "local" that can be used in the XAML to reference items
  defined in the "StaticContext" namespace. The namespace is our app's namespace while the string
  "local" can be anything you want.

* The long form of the "DataContext" property is referenced right in the XAML.

      <Window.DataContext>
          <local:Scout/>
      </Window.DataContext>

  Using the "local" key we just defined, we are essentially setting the data context on the window
  right in the XAML creating a static instance of the class "StaticContext.Scout".

* In the window code-behind, the code that previously created a single copy of a "Scout" for the
  app to operate on has been removed as we've already set the context in the XAML.

* We still need to reference the scout instance in the code-behind though so a property is created
  to fetch the data context and cast it to a "Scout".

      public Scout Scout
      {
          get => (Scout)DataContext;
      }

  We could have simply referenced the scout as shown above with the cast all through our code but
  creating the property and referencing it that way will make the code read a little nicer.

* All of the code that previously referenced the "scout" member has been changed to reference the
  new "Scout" property.
