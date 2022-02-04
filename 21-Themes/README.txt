Themes

This sample appears virtually identical to the "DependencyProperties" sample except that we add
additional custom controls and simplify the use of these controls by using the WPF themes mechanism.
By using this mechanism, we provide the default style for new controls automatically without the
need to explicitly reference any additional resource dictionaries.

The short version of how this all works is that when building a WPF application, WPF will look for
a file called "Generic.xaml" in a folder just under the assembly called "Themes". If it finds it,
then any resources contained in or referenced by that file will be automatically loaded and globally
available.

What's different
----------------

* New custom controls "ImageCheckBox" and "MenuButton" have been added to the project. That means
  four new files are added (.xaml and .cs for each control).

  - "ImageCheckBox" is a checkbox that allows us to specify the image used instead of the standard
    check to show when the checkbox is checked, unchecked, or in an indeterminate state.

  - "MenuButton" is a control that looks like a simple "ComboBox". When the box is clicked, however,
    a context menu appears contain items that can be selected/executed.

  Like the "ImageButton" class, the .XAML files contain the style used to define the new controls
  while the .CS file contains the dependency properties that can be set on the new control. The
  .CS file for the "MenuButton" also contains additional behavior for when the button is clicked.

* The project contains a folder called "Themes" and that folder contains the file "Generic.xaml".
  If that file exists, WPF will load the file automatically thus loading any resources defined in
  or referenced by that file. In our case, we use the "MergedDictionaries" property in the resource
  dictionary defined in "Generic.xaml" to reference the resource dictionaries that define our custom
  controls. In other words, "Generic.xaml" references "ImageButton.xaml", "ImageCheckBox.xaml",
  and "MenuButton.xaml".

      <ResourceDictionary ...
          <ResourceDictionary.MergedDictionaries>
              <ResourceDictionary Source="pack://application:,,,/Themes;component/ImageButton.xaml"/>
              <ResourceDictionary Source="pack://application:,,,/Themes;component/ImageCheckBox.xaml"/>
              <ResourceDictionary Source="pack://application:,,,/Themes;component/MenuButton.xaml"/>
          </ResourceDictionary.MergedDictionaries>
      </ResourceDictionary>

* All of the custom controls contain a static constructor which contains code to override the
  default style with the style pulled in via "Generic.xaml".

      static public ImageButton()
      {
          DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton),
              new FrameworkPropertyMetadata(typeof(ImageButton)));
      }

* In "MainWindow.xaml", the "ResourceDictionary" element that previously pulled in the XAML for the
  image button has been removed as the styles defining the image button and the new image checkbox
  are now pulled in automatically via the themes mechanism.

* We added an additional style in the window resources section to override some items on the image
  button just for this window.

      <Window.Resources>
          <Style TargetType="{x:Type local:ImageButton}">
              <Setter Property="Width" Value="80"/>
              <Setter Property="Height" Value="80"/>
              <Setter Property="FontSize" Value="16"/>
          </Style>
      </Window.Resources>

* Like in the earlier "ThreeStateCheck" sample, we created a "CheckBoxManager" class identical to
  the one in that sample and added it as a data context on the main window.

* The contents of the window itself are essentially a combination of the "ThreeStateCheck" checkbox
  sample and the custom image buttons sample "DependencyProperties. The main difference here is that
  the checkbox sample uses the new "ImageCheckBox" instead of the standard WPF checkbox. Additionally
  a simple "MenuButton" sample is added.
