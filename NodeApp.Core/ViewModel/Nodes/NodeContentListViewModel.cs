using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NodeApp.Core
{
    public class NodeContentListViewModel : ViewModelBase
    {
        #region Public Properties

        public string Title { get; set; }

        public ObservableCollection<CardViewModel> Cards { get; set; }

        public static CardViewModel SelectedCard { get; set; } = null;

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
            if (Cards == null)
                Cards = new ObservableCollection<CardViewModel>();

            Cards.Add(new CardViewModel
            {
                Title = "New Card...",
                Labels = new ObservableCollection<CardLabel>
                {
                   new CardLabel
                   {
                       BackgroundRGBColor = "359",
                       ForegroundRGBColor = "fff",
                       Text = "Loool"
                   },
                   new CardLabel
                   {
                       BackgroundRGBColor = "359",
                       ForegroundRGBColor = "fff",
                       Text = "Loool"
                   },
                   new CardLabel
                   {
                       BackgroundRGBColor = "359",
                       ForegroundRGBColor = "fff",
                       Text = "Loooool"
                   },
                   new CardLabel
                   {
                       BackgroundRGBColor = "359",
                       ForegroundRGBColor = "fff",
                       Text = "Loool"
                   },
                   new CardLabel
                   {
                       BackgroundRGBColor = "359",
                       ForegroundRGBColor = "fff",
                       Text = "Loooool"
                   },
                   new CardLabel
                   {
                       BackgroundRGBColor = "359",
                       ForegroundRGBColor = "fff",
                       Text = "Loool"
                   },
                   new CardLabel
                   {
                       BackgroundRGBColor = "359",
                       ForegroundRGBColor = "fff",
                       Text = "Loool"
                   }
                }
            });
        }


        public void EditNode(object parameter = null)
        {
            EditMenuVisible ^= true;
        }

        

        #endregion
    }
}
