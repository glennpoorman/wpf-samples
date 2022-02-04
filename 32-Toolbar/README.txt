Toolbar

This sample introduces a toolbar to the scout cookie tracking app. The toolbar buttons execute the
same commands as the menu items. Making this work was simply a matter of adding a toolbar spec to
the XAML as well as a handful of images files to display in the toolbar buttons.

What's Different
----------------

* A toolbar tray spec was added to the XAML to layout the toolbar. The toolbar is docked just under
  the menu and the individual toolbar buttons are set to execute the same commands as the menu items.

* Image files were added to the project for each of the toolbar buttons. Those image files are
  referenced in the XAML.

* Unlike toolbar objects in Windows or MFC, disabling toolbar buttons in WPF does NOT result in the
  image used in the button appearing disabled. In other words, WPF provides no visual feedback in a
  toolbar image when the button it belongs to is disabled. In this sample, we introduce a "Style" in
  the XAML that we apply to our toobar button images that are associated with buttons that might be
  disabled. Styles give us the ability to apply visual properties to groups of elements. When
  defining styles, you can simply set specific things (i.e. set the font of all text boxes to "24pt
  Arial"). You can also use triggers. A trigger is way to say ... here is a property I want to apply
  to something but only if a specific condition is true. In this case, we look at the "IsEnabled"
  property on the image and say, if that property is false, set the opacity of the image to 0.3
  making it look faded and disabled. Otherwise leave the opacity as is. 

* Note that adding a toolbar to this sample required no changes in the code-behind.
