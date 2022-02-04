namespace ContextMenus.Models
{
    /// <summary>
    /// Scout class definition.
    /// </summary>
    public class Scout
    {
        /// <summary>
        /// Scout name property.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Number of cookie boxes sold property.
        /// </summary>
        public uint Sold { get; set; }

        /// <summary>
        /// Grade level property.
        /// </summary>
        public GradeLevel GradeLevel { get; set; }
    }
}
