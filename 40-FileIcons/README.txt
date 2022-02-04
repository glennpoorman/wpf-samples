FileIcons

This sample tweaks the "TreeViewBinding" sample so that in addition to implementing a full folder
browser, we also extract the icons for any and all files we display. Like the previous sample, the
applicaiton provides a "Browse" button that allows the user to select a folder at which time the
application displays the contents of that folder in a tree view. In the previous sample, however,
we only displayed icons on folders but files were displayed with only their name. Here we extract
the file icon as well making the tree view display much more attractive.

What's Different
----------------

* A new utility called "FileImageManager" has been added. Extracting an icon from a file and then
  converting that icon into a bitmap is pretty straightforward and only involves two function calls.
  It can be expensive though if you're processing a large number of items so this static class keeps
  a running dictionary of file suffixes and their corresponding bitmap images. This way we only do
  the expensive image processing the very first time we encounter a particular file suffix and then
  add that image to the dictionary. Subsequent calls on files with the same suffix will then simply
  do a lookup and return.

* The "BaseViewModel" class has been added containing items shared between both the file and the
  folder view models. The base view model contains the full path name of a file or folder, the file
  name minus the path, and an "IsOpen" property (doesn't make much sense for files but it was more
  convenient to put it here).

* The "FolderViewModel" now derives from "BaseViewModel" and its child collection is now a
  collection of type "BaseViewModel".

* The "FileViewModel" now derives from "BaseViewModel". The file view model contains a "FileIcon"
  property. The property is set in the constructor by calling the new "FileImageManager" utility.

* The "FolderTreeViewModel" child collection is now of type "BaseViewModel".

* In "FolderTreeView.xaml", the data template for "FileViewModel" is now a horizontally oriented
  stack panel containing an image for the file icon as well as the text block for the file name.
