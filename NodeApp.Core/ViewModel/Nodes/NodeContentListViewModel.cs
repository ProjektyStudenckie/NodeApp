using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace NodeApp.Core
{
    public class NodeContentListViewModel : ViewModelBase
    {
        private static CardViewModel selectedCard;

        #region Public Properties

        public string Title { get; set; }

        public ObservableCollection<CardViewModel> Cards { get; set; }

        public static CardViewModel SelectedCard
        {
            get => selectedCard;
            set
            {
                if (selectedCard == value)
                    return;

                selectedCard = value;

                if (value == null)
                    NodesListViewModel.ClearForm();
                else
                    NodesListViewModel.SelectedCardTitle = selectedCard.Title;

                StaticPropertyChanged?.Invoke(null, SelectedCardPropertyEventArgs);
            }
        }

        private static readonly PropertyChangedEventArgs SelectedCardPropertyEventArgs = new PropertyChangedEventArgs(nameof(SelectedCard));
        public static event PropertyChangedEventHandler StaticPropertyChanged;

        public bool EditMenuVisible { get; set; }

        #endregion

        #region Public Commands

        public ICommand AddCardCommand { get; set; }

        public ICommand DeleteNodeCommand { get; set; }

        public ICommand MoveNodeRightCommand { get; set; }

        public ICommand MoveNodeLeftCommand { get; set; }

        #endregion


        #region Constructor

        public NodeContentListViewModel()
        {
            Cards = new ObservableCollection<CardViewModel>();

            AddCardCommand = new RelayCommand(AddCard);
            DeleteNodeCommand = new RelayCommand(RemoveNode);

            MoveNodeRightCommand = new RelayCommand(MoveNodeRight, 
                (arg) => { return NodesListViewModel.Nodes.Count > 1 &&
                    NodesListViewModel.Nodes.IndexOf(this) < NodesListViewModel.Nodes.Count - 1; });
            MoveNodeLeftCommand = new RelayCommand(MoveNodeLeft,
                (arg) => { return NodesListViewModel.Nodes.Count > 1 && 
                    NodesListViewModel.Nodes.IndexOf(this) >= 1; });
        }

        #endregion


        #region Command Methods

        public void AddCard(object parameter = null)
        {
            if (Cards == null)
                Cards = new ObservableCollection<CardViewModel>();

            Cards.Add(new CardViewModel { Title = "New Card" });
        }

        public void RemoveNode(object parameter = null)
        {
            NodesListViewModel.Nodes.Remove(this);
        }

        public void MoveNodeRight(object parameter = null)
        {
            int oldIndex = NodesListViewModel.Nodes.IndexOf(this);
            NodesListViewModel.Nodes.Move(oldIndex, ++oldIndex);
        }

        public void MoveNodeLeft(object parameter = null)
        {
            int oldIndex = NodesListViewModel.Nodes.IndexOf(this);
            NodesListViewModel.Nodes.Move(oldIndex, --oldIndex);
        }

        #endregion
    }
}
