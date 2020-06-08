using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NodeApp.Core
{
    public class CardViewModel : ViewModelBase
    {
        #region Public Properties
        
        public string Title { get; set; }

        public ObservableCollection<CardLabel> Labels { get; set; }

        #endregion


        #region Public Commands

        public ICommand DeleteCardCommand { get; set; }

        public ICommand MoveCardRightCommand { get; set; }
        public ICommand MoveCardLeftCommand { get; set; }

        public ICommand MoveCardUpCommand { get; set; }
        public ICommand MoveCardDownCommand { get; set; }

        #endregion


        #region Constructor

        public CardViewModel()
        {
            Labels = new ObservableCollection<CardLabel>();

            DeleteCardCommand = new RelayCommand(DeleteCard);

            MoveCardRightCommand = new RelayCommand(MoveCardRight, (arg) => NodesListViewModel.CanMoveCardRight(this));
            MoveCardLeftCommand = new RelayCommand(MoveCardLeft, (arg) => NodesListViewModel.CanMoveCardLeft(this));

            MoveCardUpCommand = new RelayCommand(MoveCardUp, (arg) => NodesListViewModel.CanMoveCardUp(this));
            MoveCardDownCommand = new RelayCommand(MoveCardDown, (arg) => NodesListViewModel.CanMoveCardDown(this));
        }

        #endregion


        #region Command Methods

        public void DeleteCard(object parameter = null)
        {
            NodesListViewModel.DeleteCard(this);
        }

        public void MoveCardRight(object parameter = null)
        {
            NodesListViewModel.MoveCardRight(this);
        }

        public void MoveCardLeft(object parameter = null)
        {
            NodesListViewModel.MoveCardLeft(this);
        }

        public void MoveCardUp(object parameter = null)
        {
            NodesListViewModel.MoveCardUp(this);
        }

        public void MoveCardDown(object parameter = null)
        {
            NodesListViewModel.MoveCardDown(this);
        }

        #endregion
    }
}
