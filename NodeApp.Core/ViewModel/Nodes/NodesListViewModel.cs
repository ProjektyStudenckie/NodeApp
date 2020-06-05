using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NodeApp.Core
{
    public class NodesListViewModel : ViewModelBase
    {
        #region Public Properties

        public ObservableCollection<NodeContentListViewModel> Items { get; set; }

        #endregion

        #region Public Commands

        public ICommand AddNodeCommand { get; set; }

        #endregion

        #region Constructor

        public NodesListViewModel()
        {
            AddNodeCommand = new RelayCommand(AddNode);
        }

        #endregion

        #region Command Methods

        public void AddNode(object parameter)
        {
            if (Items == null)
                Items = new ObservableCollection<NodeContentListViewModel>();

            Items.Add(new NodeContentListViewModel
            {
                Title = "New Node"
            });
        }

        #endregion

    }
}
