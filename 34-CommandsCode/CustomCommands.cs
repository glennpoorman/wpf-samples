using System.Windows.Input;

namespace CommandsCode
{
    /// <summary>
    /// Static class holds custom routed commands for this application.
    /// </summary>
    public static class CustomCommands
    {
        /// <summary>
        /// Command adds a new scout to the collection.
        /// </summary>
        public static readonly RoutedCommand AddScout = new RoutedCommand();

        /// <summary>
        /// Command interacts with the user to allow editing of the currently selected scout.
        /// </summary>
        public static readonly RoutedCommand EditScout = new RoutedCommand();

        /// <summary>
        /// Command deletes the currently selected scout.
        /// </summary>
        public static readonly RoutedCommand DeleteScout = new RoutedCommand();

        /// <summary>
        /// Command adds one sale to the tally of the currently selected scout.
        /// </summary>
        public static readonly RoutedCommand AddSale = new RoutedCommand();

        /// <summary>
        /// Command subtracts one sale from the tally of the currently selected scout.
        /// </summary>
        public static readonly RoutedCommand SubtractSale = new RoutedCommand();

        /// <summary>
        /// Command displays information about this application.
        /// </summary>
        public static readonly RoutedCommand About = new RoutedCommand();

        /// <summary>
        /// Command saves changes when editing a scout.
        /// </summary>
        public static readonly RoutedCommand Ok = new RoutedCommand();
    }
}
