using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NodeApp.Core
{
    public class NodeContentListViewModel : ViewModelBase
    {
        #region Public Properties

        public string Title { get; set; }

        public ObservableCollection<NodeListItemViewModel> Items { get; set; }

        public bool EditMenuVisible { get; set; }

        #endregion

        #region Public Commands

        public ICommand AddCardCommand { get; set; }

        public ICommand EditNodeCommand { get; set; }

        #endregion

        #region Constructor

        public NodeContentListViewModel()
        {
            AddCardCommand = new RelayCommand(AddCard);
            EditNodeCommand = new RelayCommand(EditNode);
        }

        #endregion

        #region Command Methods

        public void AddCard(object parameter = null)
        {
            if (Items == null)
                Items = new ObservableCollection<NodeListItemViewModel>();

            Items.Add(new NodeListItemViewModel
            {
                Title = "New Card..."
            });
        }

        public void EditNode(object parameter = null)
        {
            EditMenuVisible ^= true;
        }

        #endregion
    }
}
