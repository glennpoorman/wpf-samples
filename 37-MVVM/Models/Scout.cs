namespace MVVM.Models
{
    /// <summary>
    /// Scout class definition.
    /// </summary>
    /// <remarks>
    /// In this sample, the notifications required to keep WPF elements up to date now reside
    /// entirely in the view model classes which takes this class down to the bare minimum.
    /// </remarks>
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
