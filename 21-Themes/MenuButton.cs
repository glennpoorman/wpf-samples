using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media;

namespace Themes
{
    /// <summary>
    /// Menu button control definition.
    /// </summary>
    /// <remarks>
    /// Control looks like a simple uneditable combo box. Clicking the box brings up a contex menu.
    /// 
    /// The "ContentProperty" attribute indicates which property is considered the content property
    /// or in other words, which property is populated by the elements specified in between the
    /// opening and closing tags in the XAML.
    /// 
    ///     <MenuButton Content="Button Text">
    ///         <MenuItem Header="One" Command="{Binding OneCommand}"/>
    ///         <MenuItem Header="Two" Command="{Binding TwoCommand}"/>
    ///         <MenuItem Header="Three" Command="{Binding ThreeCommand}"/>
    ///     </MenuButton>
    /// </remarks>
    [ContentProperty("Items")]
    [DefaultProperty("Items")]
    public class MenuButton : Button
    {
        /// <summary>
        /// Static menu button constructor.
        /// </summary>
        static MenuButton()
        {
            // One time initialization overrides the default style to use our style defined in the
            // "MenuButton.xaml" file instead of the default style from the "Button" class.
            //
            // Note: Without this, the new type of button would continue to use the default "Button"
            //       style unless we specifically pulled the resource dictionary "MenuButton.xaml"
            //       into the window or control where we use the button.
            //
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuButton), new FrameworkPropertyMetadata(typeof(MenuButton)));
        }

        /// <summary>
        /// Indicates whether the button context menu is currently open or closed.
        /// </summary>
        public static readonly DependencyProperty IsContextMenuOpenProperty = DependencyProperty.Register("IsContextMenuOpen", typeof(bool), typeof(MenuButton));

        /// <summary>
        /// The brush used to color the caret at the far right of the button.
        /// </summary>
        public static readonly DependencyProperty CaretBrushProperty = DependencyProperty.Register("CaretBrush", typeof(Brush), typeof(MenuButton));

        /// <summary>
        /// The brush used to color the button background when highlighted on mouse over.
        /// </summary>
        public static readonly DependencyProperty HighlightBrushProperty = DependencyProperty.Register("HighlightBrush", typeof(Brush), typeof(MenuButton));

        /// <summary>
        /// Indicates whether the button context menu is currently open or closed.
        /// </summary>
        public bool IsContextMenuOpen
        {
            get { return (bool)GetValue(IsContextMenuOpenProperty); }
            set { SetValue(IsContextMenuOpenProperty, value); }
        }

        /// <summary>
        /// The brush used to color the caret at the far right of the button.
        /// </summary>
        public Brush CaretBrush
        {
            get { return (Brush)GetValue(CaretBrushProperty); }
            set { SetValue(CaretBrushProperty, value); }
        }

        /// <summary>
        /// The brush used to color the button background when highlighted on mouse over.
        /// </summary>
        public Brush HighlightBrush
        {
            get { return (Brush)GetValue(HighlightBrushProperty); }
            set { SetValue(HighlightBrushProperty, value); }
        }

        /// <summary>
        /// Called when the button is clicked. If the button contains a context menu, then the
        /// button click simply toggles the context menu open/close status.
        /// </summary>
        protected override void OnClick()
        {
            if (!ContextMenu.HasItems)
                return;

            ContextMenu.IsOpen = !IsContextMenuOpen;
        }

        /// <summary>
        /// Items property returns the collection of child items.
        /// </summary>
        public ItemCollection Items
        {
            get
            {
                EnsureContextMenuIsValid();
                return ContextMenu.Items;
            }
        }

        /// <summary>
        /// Make sure the button contains a context menu and setup the menu so that opening and closing
        /// toggles the "IsContextMenuOpen" property.
        /// </summary>
        private void EnsureContextMenuIsValid()
        {
            if (ContextMenu == null)
            {
                ContextMenu = new ContextMenu();
                ContextMenu.PlacementTarget = this;
                ContextMenu.Placement = PlacementMode.Bottom;
                ContextMenu.Opened += ((sender, routedEventArgs) => IsContextMenuOpen = true);
                ContextMenu.Closed += ((sender, routedEventArgs) => IsContextMenuOpen = false);
            }
        }
    }
}
