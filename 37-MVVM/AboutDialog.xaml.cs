﻿using System;
using System.Reflection;
using System.Windows;

namespace MVVM
{
    /// <summary>
    /// About window class definition.
    /// </summary>
    public partial class AboutDialog : Window
    {
        /// <summary>
        /// About window constructor.
        /// </summary>
        /// <param name="owner">The owning window.</param>
        public AboutDialog(Window owner)
        {
            InitializeComponent();

            // Set the window owner.
            //
            Owner = owner;
        }

        /// <summary>
        /// Assembly title property.
        /// </summary>
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
        public static string AssemblyVersion =>
            "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>
        /// Assembly copyright property.
        /// </summary>
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
