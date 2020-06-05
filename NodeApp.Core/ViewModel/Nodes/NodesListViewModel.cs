using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NodeApp.Core
{
    public class NodesListViewModel : ViewModelBase
    {
        #region Public Properties

        public ObservableCollection<NodeContentListViewModel> Nodes { get; set; }

        public CardViewModel SelectedCard => NodeContentListViewModel.SelectedCard;

        #endregion

        #region Public Commands

        public ICommand AddNodeCommand { get; set; }

        public ICommand RemoveSelectedCardCommand { get; set; }

        #endregion

        #region Constructor

        public NodesListViewModel()
        {
            AddNodeCommand = new RelayCommand(AddNode);
            RemoveSelectedCardCommand = new RelayCommand(RemoveSelectedCard);
            
        }

        #endregion

        #region Command Methods

        public void AddNode(object parameter)
        {
            if (Nodes == null)
                Nodes = new ObservableCollection<NodeContentListViewModel>();

            Nodes.Add(new NodeContentListViewModel
            {
                Title = "New Node"
            });
        }

        public void RemoveSelectedCard(object parameter)
        {
            if (SelectedCard != null)
                for (int i = 0; i < Nodes.Count; i++)
                    if (Nodes[i].Cards.Contains(SelectedCard))
                        Nodes[i].Cards.Remove(SelectedCard);
        }

        #endregion

    }
}
