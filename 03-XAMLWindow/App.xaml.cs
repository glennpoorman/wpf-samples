using System;
using System.Windows;

namespace XAMLWindow
{
    /// <summary>
    /// Main application class definition.
    /// </summary>
    /// <remarks>
    /// The application class still derives from the WPF Application class. All of the startup code
    /// from the previous sample is no longer needed though as we specified in the XAML that the
    /// window defined in "MainWindow.xaml" is to open automatically at startup.
    /// 
    /// IMPORTANT: Also note that this class is now defined as a partial. This is required as
    ///            additional code for this class will be generated at build time from the XAML.
    ///            Failure to define this class as a partial will result in a build error.
    /// </remarks>
    public partial class App : Application
    {
    }
}
