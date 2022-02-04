MVVM

This sample creates a full Model-View-ViewModel implementation of the scouts application. The MVVM
pattern splits the app into the data or models (Scout, Scouts), the UI/data go between or view
models (ScoutViewModel, ScoutsViewModel), and the UI or views (ScoutView, ScoutsView).

What's Different
----------------

* The folders "Utilities", "Models", "ViewModels", and "Views" were created and we will use those
  to better manage the files in our app.

* The classes "NotifyPropertyChanged" and "RelayCommand" were moved into the "Utilities" folder and
  now reside in the "MVVM.Utilities" namespace.

* The "Scout" and "Scouts" classes were moved to the "Models" folder and now reside in the
  "MVVM.Models" namespace. All of the notifications required to update and interact with WPF are
  moved into the view models so these classes are scaled back to basics. All notifications have been
  removed from the "Scout" class and the properties have been changed to auto-properties. The "Scouts"
  class now derives from a simple generic list that no longer needs to be observable. This is a more
  realistic implementation of the MVVM pattern as you need to consider the possibility that your
  models may come from a third party.

* The "ScoutViewModel" class is moved to the "ViewModels" folder and now resides in the
  "MVVM.ViewModels" namespace. The class is mostly unchanged from the previous sample except that
  the scout to operate on is now passed into the constructor. This doesn't seem like much but it
  actually represents a larger change. Previously this view model class was designed to be a static
  resource in the edit dialog. Now the paradigm is changed in that one scout view model object will
  exist for every scout in the main collection. Every time a scout is created then, a corresponding
  scout view model will be created and added to an observable collection of scout view models. That
  collection will essentially wrap the main collection of scouts.

* The "ScoutsViewModel" class is also moved to the "ViewModels" folder and now resides in the
  "MVVM.ViewModels" namespace. Again this class looks very similar to the one from the previous
  sample but there is a fundamental change in how the app works that require some changes here.

  - We still require a main collection of scouts. But in addition, we also need a collection of
    scout view models. This is the collection that will be "observable" and will be bound to the
    main list view.

  - Since the collection bound to the main list view is now a collection of view models, the
    "SelectedItem" property is now a "ScoutViewModel".

  - Similarly, the data type on the "EditRequested" action is also now a "ScoutViewModel".

  - The "AddScout" and "DeleteScout" commands need to work in tandem with the new view models
    collection as well as the scouts collection. So when a scout is added, we add the scout to the
    private scouts collection and also add a view model representing that scout to the public
    collection of view models.

  - The "AddSale" and "SubtractSale" commands now interact with a scout view model instead of
    interacting with the scout directly. The scout view model is designed to be used with the edit
    dialog though so making changes to properties on the view model don't propogate down to the
    scout proper. The "Add Sale" and "Subtract Sale" are supposed to immediately commit there change
    so in order to do that immediately, we go ahead and execute the "Ok" command on the view model.

* A new class "ScoutView" resides in the folder/namespace "MVVM.Views". The view is essentially a
  control designed to facilitate user interaction with a "Scout" by way of the "ScoutViewModel".
  The bulk of the scout view is designed using XAML but, instead of a "Window", the scout view is
  a "UserControl". The WPF user control is a base object that developers can derive from to create
  their own controls. Here we derive from it to create the "ScoutView". If you look at the XAML for
  the scout view, you'll see that we've simply copied what was previously in the "EditDialog". The
  only real difference is that we've removed the static data context. If you recall from the
  "ScoutsViewModel", we will now keep a collection of scout view models for every scout added.
  That means that instead of one static view model (data context) for the scout we want to edit,
  we will pass in a pre-existing view model. In the new "ScoutView.xaml.cs" code behind, the
  "ViewModel" property still exists but now has both "set" and "get" accessors.

* A new class "ScoutsView" resides in the folder/namespace "MVVM.Views". This view is a control
  designed to work with the main scouts collection. Like the "ScoutView", we've copied what was
  previously contained in the XAML for "MainWindow" into "ScoutsView.xaml". The code behind for
  this control is very lean now containing only a "get" accessor for the view model and the
  event handler for a mouse double click in the list view.

* The "EditDialog" XAML now becomes virtually non-existent. An "xmlns" tag was added allowing us to
  reference classes in the "MVVM.Views" namespace. The window itself now contains just a single
  element which is an instance of the "ScoutView". Note that we name the view as we'll need access
  to it in the code behind.

* The code behind "EditDialog.xaml.cs" contains a constructor which is still tasked with setting
  the action to be taken on the view model when a close is requested. Here we use the name of the
  view to get access to the view model and then set the action so that we not only close the window
  when we're finished, but we also remove the action (now required since these view models live on
  in the main collection). Also note that we no longer use a lambda expression to set the action
  here. That is because actions set using lambda expressions cannot be reliably removed using the
  "-=" syntax.

* Like the edit dialog, the main window's XAML is now very lean containing just a single instance
  of a "ScoutsView". The code behind for the main window contains just a single constructor that
  sets up the eveng handling for changes to the main collection and also sets the actions to be
  taken when the view model requests close, about information, or an edit operation.
