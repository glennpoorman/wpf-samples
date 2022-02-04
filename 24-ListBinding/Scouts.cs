using System.Collections.ObjectModel;

namespace ListBinding
{
    /// <summary>
    /// Scouts collection class.
    /// </summary>
    /// <remarks>
    /// This class simply derives from the observable collection class. The base class will fire
    /// notifications any time the collection is modified. This is the behavior that will make the
    /// list binding work.
    /// </remarks>
    public class Scouts : ObservableCollection<Scout> { }
}
