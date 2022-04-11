using System;
using System.Windows.Input;

namespace TreeViewBinding.Utilities
{
    /// <summary>
    /// Wait cursor utility class.
    /// </summary>
    /// <remarks>
    /// This class derives from "IDisposable" and is design so that merely instantiating an object
    /// of this type will turn your current cursor into a wait cursor. The original cursor will be
    /// restored when "Dispose" is called (either directly or via a "using").
    /// </remarks>
    public class WaitCursor : IDisposable
    {
        /// <summary>
        /// The original cursor in place when this object was instanced.
        /// </summary>
        private readonly Cursor oldCursor;

        /// <summary>
        /// Cursor constructor installs the wait cursor.
        /// </summary>
        public WaitCursor()
        {
            // Save the current cursor.
            //
            oldCursor = Mouse.OverrideCursor;

            // Set the wait cursor to be the current cursor.
            //
            Mouse.OverrideCursor = Cursors.Wait;
        }

        /// <summary>
        /// Restore the original cursor.
        /// </summary>
        public void Dispose()
        {
            Mouse.OverrideCursor = oldCursor;
            GC.SuppressFinalize(this);
        }
    }
}
