ControlTemplates

This application shows several buttons with their appearance customized to show only the content.
In addition, there is some added visual feedback when the mouse interacts with the buttons.

Control appearance in WPF can be completely re-defined using "ControlTemplate" elements. Every
control has a default control template that controls exactly how a control is rendered and how it
behaves when it is interacted with. This is all customizable though. In this sample, we redefine
the WPF button so that it no longer displays the gray background with the thin border. Instead, we
simply display the button content and nothing else. Additionally, we add a fuzzy drop shadow effect
to the content when the mouse hovers over it along with some added visual feedback when the mouse
button is pressed.

What's different
----------------

* Again we add a "Resources" section to the window. Inside we define two "Style" elements. The first
  is a very simple element designed to be applied to any "Image" in the window setting the stretch
  property to "None" and thus forcing all images to display at their original size. The second
  "Style" element is designed to be applied to all buttons in the window.

* The "Template" and "ControlTemplate" properties are set on all buttons using the new button style.
  This can be done from scratch (if you really know what you're doing) or it can be done by right
  clicking the button in the XAML window and selecting "Edit Style" and "Edit A Copy". The XAML
  editor will then insert a complete copy of the style the button is currently using and you can use
  that as a guide to customize the button.

* For our purposes, we removed the "Border" element which is what gave the button its gray backing
  a thin border. We left the "ContentPresenter" which is an element that simply displays the content
  of a content control (button, radio button, check box, etc).

* We added a series of "Trigger" elements to the control template. These are used to make property
  changes when certain conditions occur. In our case we create three triggers. One for when the
  mouse hovers over the button, another when the mouse is pressed, and a third when the button is
  disabled. To change the property values in the trigger, we use "Setter" elements like we did in
  the previous sample.

* For when a button is disabled or when the mouse is pressed, we the the "Opacity" of the content
  presenter. This causes all of the content to be displayed with a gray see-through look.

* for when the mouse hovers over the button, we add an "Effect" property and make use of the
  "DropShadowEffect" which we use to show a fuzzy gray glow behind the content.

* The code behind contains just two event handlers for button clicks. For the two close buttons,
  the event handler simply closes the application. For the other buttons, the event handler either
  displays the text string or, for images, the name of the image.
