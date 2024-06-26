﻿using FileIcons.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FileIcons.ViewModels
{
    /// <summary>
    /// Delegate for folder browsing.
    /// </summary>
    /// <param name="selectedPath">The currently selected path (in/out).</param>
    /// <returns>True if a folder was selected. False if cancelled.</returns>
    public delegate bool BrowseDelegate(ref string selectedPath);

    /// <summary>
    /// Main view model for the entire folder tree.
    /// </summary>
    public class FolderTreeViewModel : NotifyPropertyChanged
    {
        /// <summary>
        /// Currently selected path to browse.
        /// </summary>
        private string currentPath;

        /// <summary>
        /// Currently selected path to browse.
        /// </summary>
        public string CurrentPath
        {
            get => currentPath;
            set
            {
                currentPath = value;
                OnPropertyChanged("CurrentPath");
                RebuildChildList();
            }
        }

        /// <summary>
        /// Collection of child view models (files/folders).
        /// </summary>
        public ObservableCollection<BaseViewModel> Children { get; } = new ObservableCollection<BaseViewModel>();

        /// <summary>
        /// Command puts up UI to browse for a folder.
        /// </summary>
        public ICommand Browse { get; }

        /// <summary>
        /// Command displays information about this application.
        /// </summary>
        public ICommand About { get; }

        /// <summary>
        /// Command shuts down the application.
        /// </summary>
        public ICommand Exit { get; }

        /// <summary>
        /// Event will be fired requesting that UI be presented for browsing a folder.
        /// </summary>
        public event BrowseDelegate BrowseRequested;

        /// <summary>
        /// Event will be fired requesting that the UI display application information.
        /// </summary>
        public event Action AboutRequested;

        /// <summary>
        /// Event will be fired requesting the application to close.
        /// </summary>
        public event Action CloseRequested;

        /// <summary>
        /// View model constructor.
        /// </summary>
        public FolderTreeViewModel()
        {
            // Create the "Browse" command. The handler code fires an event requesting that UI be
            // be presented to allow for browsing a folder and returns the resulting selection.
            //
            Browse = new RelayCommand(
                (p) =>
                {
                    string selectedPath = CurrentPath;
                    if (BrowseRequested?.Invoke(ref selectedPath) == true)
                    {
                        CurrentPath = selectedPath;
                    }
                }
            );

            // Create the "About" command. The handler code fires an event that application info
            // was requested and allows the event handlers to display this information accordingly.
            //
            About = new RelayCommand((p) => AboutRequested?.Invoke());

            // Create the "Exit" command. The handler code fires an event that a close was
            // requested and allows the event handlers to shut down the application accordingly.
            //
            Exit = new RelayCommand((p) => CloseRequested?.Invoke());
        }

        /// <summary>
        /// Rebuilds the child tree based on the currently selected path.
        /// </summary>
        private void RebuildChildList()
        {
            // Put up a wait cursor as high level folder could take a while.
            //
            using WaitCursor waitCursor = new();

            // Clear out the old child list.
            //
            Children.Clear();

            // Create a single folder view model representing the selected path. The rest of
            // the traversal will happen inside of any child folders that we come upon.
            //
            Children.Add(new FolderViewModel(CurrentPath) { IsOpen = true });
        }
    }
}
