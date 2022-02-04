using System.Collections.Generic;

namespace MVVM.Models
{
    /// <summary>
    /// Scouts collection class.
    /// </summary>
    /// <remarks>
    /// Note that the notifications used to keep WPF elements up to date now reside entirely in the
    /// view model classes which means the scouts collection can simply derive from a generic list
    /// and no longer needs to be observable.
    /// </remarks>
    public class Scouts : List<Scout> { }
}
