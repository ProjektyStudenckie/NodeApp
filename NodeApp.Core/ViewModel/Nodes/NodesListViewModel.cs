using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace NodeApp.Core
{
    public class NodesListViewModel : ViewModelBase
    {
        private static string selectedCardTitle;

        #region Public Properties

        public static ObservableCollection<NodeContentListViewModel> Nodes { get; set; }

        public static CardViewModel SelectedCard => NodeContentListViewModel.SelectedCard;


        public static string SelectedCardTitle
        {
            get => selectedCardTitle;
            set
            {
                if (selectedCardTitle == value)
                    return;

                selectedCardTitle = value;

                StaticPropertyChanged?.Invoke(null, SelectedCardTitlePropertyEventArgs);
            }
        }


        #endregion

        private static readonly PropertyChangedEventArgs SelectedCardTitlePropertyEventArgs = new PropertyChangedEventArgs(nameof(SelectedCardTitle));
        public static event PropertyChangedEventHandler StaticPropertyChanged;

        #region Public Commands

        public ICommand AddNodeCommand { get; set; }

        public ICommand RemoveSelectedCardCommand { get; set; }

        public ICommand UpdateCardCommand { get; set; }

        #endregion

        #region Constructor

        public NodesListViewModel()
        {
            Nodes = new ObservableCollection<NodeContentListViewModel>();

            AddNodeCommand = new RelayCommand(AddNode);
            RemoveSelectedCardCommand = new RelayCommand(RemoveSelectedCard);
            UpdateCardCommand = new RelayCommand(UpdateSelectedCard);
        }

        #endregion

        #region Command Methods

        public void AddNode(object parameter)
        {
            Nodes.Add(new NodeContentListViewModel
            {
                Title = "New Node"
            });
        }

        public static void RemoveSelectedCard(object parameter)
        {
            if (SelectedCard != null)
                for (int i = 0; i < Nodes.Count; i++)
                    if (Nodes[i].Cards.Contains(SelectedCard))
                        Nodes[i].Cards.Remove(SelectedCard);
        }

        public static void DeleteCard(CardViewModel card)
        {
            for (int i = 0; i < Nodes.Count; i++)
                if (Nodes[i].Cards.Contains(card))
                    Nodes[i].Cards.Remove(card);
        }

        public static void MoveCardRight(CardViewModel card)
        {

            for (int i = 0; i < Nodes.Count; i++)
                if (Nodes[i].Cards.Contains(card))
                {
                    Nodes[i].Cards.Remove(card);
                    Nodes[i + 1].Cards.Add(card);
                    break;
                }
        }

        public static void MoveCardLeft(CardViewModel card)
        {
            for (int i = 0; i < Nodes.Count; i++)
                if (Nodes[i].Cards.Contains(card))
                {
                    Nodes[i].Cards.Remove(card);
                    Nodes[i - 1].Cards.Add(card);
                    break;
                }
        }

        public static void MoveCardUp(CardViewModel card)
        {
            for (int i = 0; i < Nodes.Count; i++)
                if (Nodes[i].Cards.IndexOf(card) > 0)
                {
                    Nodes[i].Cards.Move(Nodes[i].Cards.IndexOf(card), Nodes[i].Cards.IndexOf(card) - 1);
                    break;
                }
        }

        public static void MoveCardDown(CardViewModel card)
        {
            for (int i = 0; i < Nodes.Count; i++)
                if (Nodes[i].Cards.IndexOf(card) != -1 && Nodes[i].Cards.IndexOf(card) < Nodes[i].Cards.Count - 1)
                {
                    Nodes[i].Cards.Move(Nodes[i].Cards.IndexOf(card), Nodes[i].Cards.IndexOf(card) + 1);
                    break;
                }
        }

        public static bool CanMoveCardLeft(CardViewModel card)
        {
            for (int i = 0; i < Nodes.Count; i++)
                if (Nodes[i].Cards.Contains(card))
                    if (i > 0)
                        return true;
            return false;
        }

        public static bool CanMoveCardRight(CardViewModel card)
        {
            for (int i = 0; i < Nodes.Count; i++)
                if (Nodes[i].Cards.Contains(card))
                    if (Nodes.Count > (i + 1))
                        return true;
            return false;
        }

        public static bool CanMoveCardUp(CardViewModel card)
        {
            for (int i = 0; i < Nodes.Count; i++)
                if (Nodes[i].Cards.IndexOf(card) > 0)
                    return true;
            return false;
        }

        public static bool CanMoveCardDown(CardViewModel card)
        {
            for (int i = 0; i < Nodes.Count; i++)
                if (Nodes[i].Cards.IndexOf(card) != -1 && Nodes[i].Cards.IndexOf(card) < Nodes[i].Cards.Count - 1)
                    return true;
            return false;
        }

        public void UpdateSelectedCard(object parameter = null)
        {
            SelectedCard.Title = SelectedCardTitle;
            onPropertyChanged(nameof(SelectedCard));
        }

        #endregion


        #region Methods

        public static void ClearForm()
        {
            SelectedCardTitle = "";
        }

        #endregion
    }
}
