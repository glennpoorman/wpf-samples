TreeViewBinding

This sample steps away from the Scouts application and instead implements a simple folder browser
design to show how to use data binding to populate a WFP "TreeView" control.

The application simply provides a "Browse" button which allows the user to select a folder. In the
main window's tree view, the contents of that folder are display (both files and sub-folders). Any
sub-folder can then be clicked and expanded to show its contents until the entire tree is shown.

What's Different
----------------

* A new utility "WaitCursor" was added. This is a utility class that derives from "IDisposable".
  The class constructor saves the currently active cursor and installs the Windows wait cursor. The
  "Dispose" method then resets the cursor. The utility was design this was so that it can simply be
  instiated in a "using" and the cursor will reset when it goes out of scope.

* We use the MVVM pattern for this application. Note that we do not have a "Models" folder though.
  In this app, the file system is our model.

* The "ViewModels" folder contains a file view model "FileViewModel" and a "FolderViewModel". This
  is a very simple case where the file has only its name as a property and the folder has its name
  plus a collection of child folders/files. So hear the file view model also serves as the base
  class for the folder view model.

* The "ViewModels" folder also contains the "FolderTreeViewModel". This view model represents the
  main window of our app showing the tree view, the currently selected path, and the "Browse",
  "About", and "Close" buttons.

* Just like in previous samples, the view model contains delegates for "About" and "Close" so that
  we can defer to the calling UI code to present UI for these operations. Similarly the view model
  also contains a delegate for "Browse". We had to define this delegate as the pre-existing "Action"
  and "Func" delegates don't allow for "out" or "ref" parameters (which we need in this case).

* Note that this sample also starts using the null conditional operator "?." for invoking delegates
  which is new in C# 6 and removes the need to null check delegates before using them.

* The main window code uses the "FolderBrowserDialog" defined in "Windows.Forms" to allow the user
  to browse for a folder.

* The "FolderTreeView" user control defines the tree view. This control is quite a bit more complex
  than, for example, a list view. The initial definition is very similar.

      <TreeView ItemsSource="{Binding Children}">

  Binding "ItemsSource" here, however, only sets up the top most linear list. How each item in the
  list is displayed requires a data template. For leaf nodes (such as files), we can use the same
  data template we've shown in previous samples. Here we define a data template for the file view
  model in the tree view's resources section.

      <DataTemplate Datatype="{x:Type viewmodels:FileViewModel}">
          <TextBlock Text="{Binding Name}"/>
      </DataTemplate>

  So here we've defined that for files, we should simply display the name. Since the folder view
  model derives from the file view model, this would work for folders as well. But if we stopped
  here, we would only have a single linear list. We need an additional data template just for
  folders. Since folders contain children, we can't simply use a regular data template. Here we
  need a "HierarchicalDataTemplate". Again in the tree view resource section we start the data
  template definition.

      <HierarchicalDataTemplate DataType="{x:Type viewmodels.FolderViewModel"
                                ItemsSource="{Binding Children">

  Already we've specified that this item is a non-leaf node in the tree and can contain children.
  In addition, we want to show a folder icon for folders so we beef up the display a bit as well.

      <StackPanel Orientation="Horizontal">
          <Image x:Name="folderImg" Source="../Resources/folder_closed.png"/>
          <TextBlock Margin="4,0,0,0" Text="{Binding Name}"/>
      </StackPanel>

  Next we want to set up a data trigger so that when the user clicks a folder in order to show its
  children, we change the folder closed icon to a folder open icon.

      <HierarchicalDataTemplate.Triggers>
          <DataTrigger Binding="{Binding RelativeSource={RelativeSource AncestorType=TreeViewItem},
                                         Path=IsExpanded}" Value="True">
              <Setter TargetName="folderImg" Property="Source" Value="../Resources/folder_open.png"/>
          </DataTrigger>
      </HierarchicalDataTemplate.Triggers>

  Lastly we modify the style on the individual tree view items in order to bind the "IsExpanded"
  property to a property on our view model (data context).

      <TreeView.ItemContainerStyle>
          <Style TargetType="{x:Type TreeViewItem}">
              <Setter Property="IsExpanded" Value="{Binding IsOpen}"/>
          </Style>
      </TreeView.ItemContainerStyle>
