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
        public static readonly RoutedCommand AddScout = new();

        /// <summary>
        /// Command interacts with the user to allow editing of the currently selected scout.
        /// </summary>
        public static readonly RoutedCommand EditScout = new();

        /// <summary>
        /// Command deletes the currently selected scout.
        /// </summary>
        public static readonly RoutedCommand DeleteScout = new();

        /// <summary>
        /// Command adds one sale to the tally of the currently selected scout.
        /// </summary>
        public static readonly RoutedCommand AddSale = new();

        /// <summary>
        /// Command subtracts one sale from the tally of the currently selected scout.
        /// </summary>
        public static readonly RoutedCommand SubtractSale = new();

        /// <summary>
        /// Command displays information about this application.
        /// </summary>
        public static readonly RoutedCommand About = new();

        /// <summary>
        /// Command saves changes when editing a scout.
        /// </summary>
        public static readonly RoutedCommand Ok = new();
    }
}
