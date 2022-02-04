using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FileIcons.Utilities
{
    /// <summary>
    /// Static class used to get the file icon image from a given file.
    /// </summary>
    /// <remarks>
    /// The code to actually extract the icon from a file and then convert it to an "ImageSource"
    /// is fairly simple but somewhat slow. When a very large folder is selected, the time it takes
    /// to create all of the images and display the items in the tree is considerably slower than
    /// in the previous sample and very noticeable. So this manager maintains a dictionary mapping
    /// file suffixes to images. That way for file types that have already been processed, we can
    /// just do a quick lookup and return an existing file image instead of creating a new one for
    /// every file.
    /// </remarks>
    public static class FileImageManager
    {
        /// <summary>
        /// Dictionary maps file suffixes to image source.
        /// </summary>
        private static Dictionary<string, ImageSource> theMap = new Dictionary<string, ImageSource>();

        /// <summary>
        /// Return the file image source corresponding to the given file.
        /// </summary>
        /// <param name="fullName">The name of the file to return the image for.</param>
        /// <returns>The file image.</returns>
        public static ImageSource GetImageSource(string fullName)
        {
            // Fetch the file extension.
            //
            string fileExt = Path.GetExtension(fullName);

            // For icons, the file icon is always a tiny version of the icon itself so we can't
            // just store one image for this file type. We have to create the image for every file.
            //
            if (fileExt == ".ico")
            {
                return CreateImageSource(fullName);
            }

            // Check the map for the file suffix and return the image if we find it.
            //
            if (theMap.ContainsKey(fileExt))
            {
                return theMap[fileExt];
            }

            // First time in for this file type. Create the image, store it in the map along with
            // the file suffix, and then return the image.
            //
            ImageSource fileImage = CreateImageSource(fullName);
            theMap.Add(fileExt, fileImage);
            return fileImage;
        }

        /// <summary>
        /// Create the image source based on the given file.
        /// </summary>
        /// <param name="fullName">The name of the file to create the image for.</param>
        /// <returns>The file image.</returns>
        private static ImageSource CreateImageSource(string fullName)
        {
            // Extract the icon from the file based on the file name.
            //
            Icon theIcon = Icon.ExtractAssociatedIcon(fullName);

            // Convert the icon into an image source and return it.
            //
            return Imaging.CreateBitmapSourceFromHIcon(theIcon.Handle, Int32Rect.Empty,
                BitmapSizeOptions.FromWidthAndHeight(16, 16));
        }
    }
}
