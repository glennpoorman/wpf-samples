DependencyProperties

This application is very similar to the "ControlTemplates" sample except that we've simplified
our control over the button appearance by creating some additional properties we can set right
on the button.

In this sample we derive our own button class from the WPF button class. Our new class is designed
to always show an image and optionally show additional button content just to the right of the
image. The new class contains the two newly defined properties "Source" which allows us to specify
the image as a button property, and "ShadowColor" which allows us to specify the color of the fuzzy
drop shadow that appears when the mouse hovers over the button. Additionally, all of this is wrapped
up nice and neat in its own C# and XAML file and is pulled into the main window XAML as a resource
dictionary.

What's different
----------------

* We want to add some additional properties to our button. In order to do this, we first need a new
  control deriving from "Button" so we create the new class "ImageButton". In the new class, we are
  going to define three dependency properties that are as follows:

      Source      - the image that will be displayed in the button.
      ShadowColor - the color of the drop shadow when we hover the mouse over the button.
      Orientation - the orientation of the image/content (vertical or horizontal).

  Defining a dependency property is a two step process. First you need to register the new property
  with the dependency property system and save it as a static member of the new button class.

      public static readonly DependencyProperty SourceProperty =
          DependencyProperty.Register("Source", typeof(ImageSource), typeof(ImageButton));

  Note in the call to register that the name we specify ("Source") is the name we'll use in XAML to
  reference the new property. Additional parameters are the data type of the property along with the
  data type of the control containing the property.

  Additionally we also need to create C# properties so that the new dependency property can be
  reference via code. These C# properties can simply be wrappers over the "GetValue" and "SetValue"
  methods that interact with the dependency property system.

      public ImageSource Source
      {
          get { return (ImageSource)GetValue(SourceProperty); }
          set { SetValue(SourceProperty, value); }
      }

* The button style definition from the previous sample has been pulled out of the main window's XAML
  file and moved into its own file "ImageButton.xaml". The new file defines a "ResourceDictionary"
  which is a XAML item that serves as a repository for reusable resources. In this case, the only
  resource is our button style. Note that in both the style and control template definition, we've
  changed the "TargetType" property that was previously set to "{x:Type Button}" to now refer to
  the new control "{x:Type local:ImageButton}".

  The control template definition for the new button is very much like the previous sample with a
  few key differences.

  - The actual definition of the control appearance previously contained just the content presenter.
    In this new button, we put in a stack panel. That stack panel then contains a single image
    followed by the content presenter.

  - Note that the "Orientation" of the stack panel uses template binding to bind the value to one of
    our new dependency properties. Similarly, the "Source" property on the image also uses template
    binding to bind to another of our new dependency properties. What this means is that setting the
    orientation on the "ImageButton" when you place it in the XAML translates to setting the
    orientation on the underlying stack panel. Same for the image source.

  - The triggers section is mostly the same except that instead of setting properties on the content
    presenter, the properties are set on the stack panel. Also note that we again use template
    binding only this time we are binding the color of the drop shadow effect to another of our new
    dependency properties "ShadowColor".

* The main window XAML now simply pulls the button style in from the new resource dictionary we just
  defined.

      <Window.Resources>
          <ResourceDictionary Source="ImageBuggon.xaml"/>
      </Window.Resources>

* Now the button placements in the main window XAML use our new control and its new properties.

      <local:ImageButton Source="Resources/add-icon.png" ShadowColor="#7A8291" .../>

* Run the app and note a few of the enhancements:

  - Each button can contain either an image, regular button content, or both. The app shows all of
    these examples.

  - Buttons that contain both an image and content can be oriented such that the content appears
    either below the button or to the right of it. The bottom row of buttons shows both of these
    examples.

  - The shadow that appeared behind the buttons in the previous sample was always gray. In this
    sample, I was able to specify the color of the button image to use as the shadow color. This
    makes the whole appearance just a little nicer and a little more smooth.
