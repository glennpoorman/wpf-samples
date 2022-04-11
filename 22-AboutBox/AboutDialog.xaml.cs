using System;
using System.Reflection;
using System.Windows;

namespace AboutBox
{
    /// <summary>
    /// About window class definition.
    /// </summary>
    /// <remarks>
    /// Much of this code was lifted from the about boxes that are auto-generated when creating
    /// a Windows Forms app. Note that for these properties to work, the corresponding values
    /// must be filled in in the project properties "Package" tab.
    /// </remarks>
    public partial class AboutDialog : Window
    {
        /// <summary>
        /// About window constructor.
        /// </summary>
        /// <param name="owner">The owning window.</param>
        public AboutDialog(Window owner)
        {
            InitializeComponent();

            // Setting an owner for a dialog is handy as, in our case, it will cause the dialog to
            // center itself in the owning window.
            //
            Owner = owner;
        }

        /// <summary>
        /// Assembly title property.
        /// </summary>
        /// <remarks>
        /// The property is fetched from the the executing assembly information explicitly filled
        /// out in the app properties "Assembly Information" dialog.
        /// </remarks>
        public static string AssemblyTitle
        {
            get
            {
                AssemblyTitleAttribute attr = GetAssemblyAttributes<AssemblyTitleAttribute>();
                return (attr == null) ? string.Empty : attr.Title;
            }
        }

        /// <summary>
        /// Assembly description property.
        /// </summary>
        /// <remarks>
        /// The property is fetched from the the executing assembly information explicitly filled
        /// out in the app properties "Assembly Information" dialog.
        /// </remarks>
        public static string AssemblyDescription
        {
            get
            {
                AssemblyDescriptionAttribute attr = GetAssemblyAttributes<AssemblyDescriptionAttribute>();
                return (attr == null) ? string.Empty : attr.Description;
            }
        }

        /// <summary>
        /// Assembly version property.
        /// </summary>
        /// <remarks>
        /// The property is fetched from the the executing assembly information explicitly filled
        /// out in the app properties "Assembly Information" dialog.
        /// </remarks>
        public static string AssemblyVersion
        {
            get => "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        /// <summary>
        /// Assembly copyright property.
        /// </summary>
        /// <remarks>
        /// The property is fetched from the the executing assembly information explicitly filled
        /// out in the app properties "Assembly Information" dialog.
        /// </remarks>
        public static string AssemblyCopyright
        {
            get
            {
                AssemblyCopyrightAttribute attr = GetAssemblyAttributes<AssemblyCopyrightAttribute>();
                return (attr == null) ? string.Empty : attr.Copyright;
            }
        }

        /// <summary>
        /// Utility function fetches a specific type of attribute from the executing assembly.
        /// </summary>
        /// <typeparam name="T">The attribute type to query for.</typeparam>
        /// <returns>The attribute value.</returns>
        private static T GetAssemblyAttributes<T>() where T : Attribute
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(T), true);
            return (attributes == null || attributes.Length == 0) ? null : (T)attributes[0];
        }
    }
}
