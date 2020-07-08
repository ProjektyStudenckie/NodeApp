﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NodeApp.Core
{
    public class NodesListViewModel : ViewModelBase
    {
        private static string selectedCardTitle;

        #region Public Properties

        public bool AreSettingsOpen { get; set; } = false;

        public bool RefreshIsRunning { get; set; }

        public string NewLabelTitle { get; set; }
        public string NewLabelBackgroundColor { get; set; } = "2c354a";
        public string NewLabelForegroundColor { get; set; } = "fff";

        public static ObservableCollection<NodeContentListViewModel> Nodes { get; set; }

        public static CardViewModel SelectedCard => NodeContentListViewModel.SelectedCard;

        public ObservableCollection<CardLabel> AvailableLabels => DataProgram.availableLabels;

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

        public ICommand UpdateCardCommand { get; set; }

        public ICommand LabelClickCommand { get; set; }

        public ICommand RemoveLabelCommand { get; set; }

        public ICommand OpenSettingsCommand { get; set; }

        public ICommand OpenPropertiesCommand { get; set; }

        public ICommand CreateLabelCommand { get; set; }

        public ICommand RefreshCommand { get; set; }

        #endregion

        #region Constructor

        public NodesListViewModel()
        {
            Nodes = new ObservableCollection<NodeContentListViewModel>();
            InitializeCommands();

            List<Column> colList = DataColumn.ReturnColumnsOfRoom(DataProgram.Room);
            colList.Sort();
            AddNodes(colList);
            List<Lable> labList = DataLable.ReturnLabelsOfRoom(DataProgram.Room);

            foreach (Lable x in labList)
                if(!UpdateDuplicates(x))
                    DataProgram.availableLabels.Add(new CardLabel(x));
        }

        private static bool UpdateDuplicates(Lable x)
        {
            bool containsDuplicates = false;
            for (int i = 0; i < DataProgram.availableLabels.Count; i++)
                if (DataProgram.availableLabels[i].Text == x.lable_text)
                {
                    DataProgram.availableLabels[i] = new CardLabel(x);
                    containsDuplicates = true;
                }
            return containsDuplicates;
        }

        private void InitializeCommands()
        {
            AddNodeCommand = new RelayCommand(AddNode);
            UpdateCardCommand = new RelayCommand(UpdateSelectedCard);
            LabelClickCommand = new RelayCommand(LabelClick, (arg) => SelectedCard != null);
            RemoveLabelCommand = new RelayCommand(RemoveLabel);
            OpenSettingsCommand = new RelayCommand(OpenSettings);
            OpenPropertiesCommand = new RelayCommand(OpenProperties);
            CreateLabelCommand = new RelayCommand(CreateLabel, (arg) => !string.IsNullOrEmpty(NewLabelTitle) && !IsLabelDuplicate());
            RefreshCommand = new RelayCommand(Refresh);
        }

        #endregion

        #region Command Methods

        public void Refresh(object parameter = null)
        {
            DataProgram.nodesListViewModel = new NodesListViewModel();
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Nodes);
        }

        public void RemoveLabel(object parameter)
        { 
            string labelText = parameter.ToString();

            for (int i = 0; i < DataProgram.availableLabels.Count; i++)
                if (DataProgram.availableLabels[i].Text.Equals(labelText))
                {
                    List<LableTask> relationsToDestroy = DataLableTask.ReturnRelationsOfLable(DataProgram.availableLabels[i].lable);
                    foreach(LableTask x in relationsToDestroy)
                    {
                        DataLableTask.DeleteLableTask(x);
                    }
                    DataLable.DeleteLable(DataProgram.availableLabels[i].lable);
                    DataProgram.availableLabels.RemoveAt(i);
                }

            // Remove labels already placed on cards
            for(int i=0; i<Nodes.Count; i++)
                for(int j=0; j<Nodes[i].Cards.Count; j++)
                    for(int k=0; k<Nodes[i].Cards[j].Labels.Count; k++)
                        if (Nodes[i].Cards[j].Labels[k].Text == labelText)
                            Nodes[i].Cards[j].Labels.RemoveAt(k);

        }

        public void CreateLabel(object parameter = null)
        {
            var newLabel = new CardLabel(NewLabelTitle, NewLabelBackgroundColor, NewLabelForegroundColor);

            DataProgram.availableLabels.Add(newLabel);
        }


        private void OpenSettings(object parameter = null)
        {
            AreSettingsOpen = true;
        }

        private void OpenProperties(object parameter = null)
        {
            AreSettingsOpen = false;
        }

        public void LabelClick(object parameter)
        {
            if (SelectedCard != null)
            {
                string labelText = parameter.ToString();
                for (int i = 0; i < DataProgram.availableLabels.Count; i++)
                    if (DataProgram.availableLabels[i].Text == labelText)
                    {
                        for (int j = 0; j < SelectedCard.Labels.Count; j++)
                            if (SelectedCard.Labels[j].Text == labelText)
                            {
                                SelectedCard.Labels.RemoveAt(j);
                                DataLableTask.DeleteLableTask(new LableTask(DataProgram.availableLabels[i].lable, SelectedCard.Task));
                                return;
                            }
                        SelectedCard.Labels.Add(DataProgram.availableLabels[i]);
                        new LableTask(DataProgram.availableLabels[i].lable, SelectedCard.Task);
                    }
            }
        }


        public void AddNode(object parameter)
        {
            Nodes.Add(new NodeContentListViewModel(new Column("New Node", DataProgram.Room.room_id, Nodes.Count)));
        }

        public void AddNodes(List<Column> columns)
        {
            foreach( Column x in columns)
            {
                Nodes.Add(new NodeContentListViewModel(x));
            }  
        }

        public static void DeleteCard(CardViewModel card)
        {
            for (int i = 0; i < Nodes.Count; i++)
                if (Nodes[i].Cards.Contains(card))
                {
                    DataProgram.DeleteTaskWithRelations(card.Task);

                    // Decrement all cards with higher id in the column
                    int indexOfRemoved = Nodes[i].Cards.IndexOf(card);
                    for(int x=indexOfRemoved+1; x<Nodes[i].Cards.Count; x++)
                        Nodes[i].Cards[x].Id--;

                    Nodes[i].Cards.Remove(card);
                }
        }

        public static void MoveCardRight(CardViewModel card)
        {

            for (int i = 0; i < Nodes.Count; i++)
                if (Nodes[i].Cards.Contains(card))
                {
                    // Decrement ids of cards below moved one
                    int indexOfRemoved = Nodes[i].Cards.IndexOf(card);
                    for (int x = indexOfRemoved + 1; x < Nodes[i].Cards.Count; x++)
                        Nodes[i].Cards[x].Id--;

                    Nodes[i].Cards.Remove(card);
                    Nodes[i + 1].Cards.Add(card);

                    card.Id = Nodes[i + 1].Cards.Count-1;
                    card.Task.column_id = Nodes[i+1].Column.column_id;
                    DataTask.EditTask(card.Task, card.Task.task_id);
                    break;
                }
        }

        public static void MoveCardLeft(CardViewModel card)
        {
            for (int i = 0; i < Nodes.Count; i++)
                if (Nodes[i].Cards.Contains(card))
                {
                    // Decrement ids of cards below moved one
                    int indexOfRemoved = Nodes[i].Cards.IndexOf(card);
                    for (int x = indexOfRemoved + 1; x < Nodes[i].Cards.Count; x++)
                        Nodes[i].Cards[x].Id--;

                    Nodes[i].Cards.Remove(card);
                    Nodes[i - 1].Cards.Add(card);

                    card.Id = Nodes[i - 1].Cards.Count-1;
                    card.Task.column_id = Nodes[i-1].Column.column_id;
                    DataTask.EditTask(card.Task, card.Task.task_id);
                    break;
                }
        }

        public static void MoveCardUp(CardViewModel card)
        {
            for (int i = 0; i < Nodes.Count; i++)
                if (Nodes[i].Cards.IndexOf(card) > 0)
                {
                    int indexOfMovedCard = Nodes[i].Cards.IndexOf(card);

                    // Swap Id's with card above
                    int tmp = Nodes[i].Cards[indexOfMovedCard - 1].Id;
                    Nodes[i].Cards[indexOfMovedCard - 1].Id = card.Id;
                    card.Id = tmp;

                    Nodes[i].Cards.Move(indexOfMovedCard, indexOfMovedCard - 1);
                    break;
                }   
        }

        public static void MoveCardDown(CardViewModel card)
        {
            for (int i = 0; i < Nodes.Count; i++)
                if (Nodes[i].Cards.IndexOf(card) != -1 && Nodes[i].Cards.IndexOf(card) < Nodes[i].Cards.Count - 1)
                {
                    int indexOfMovedCard = Nodes[i].Cards.IndexOf(card);

                    // Swap Id's with card below
                    int tmp = Nodes[i].Cards[indexOfMovedCard + 1].Id;
                    Nodes[i].Cards[indexOfMovedCard + 1].Id = card.Id;
                    card.Id = tmp;

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
            if (SelectedCard == null)
                return;
            SelectedCard.Title = SelectedCardTitle;
            SelectedCard.Task=new Tasks(SelectedCard.Task.task_id,SelectedCardTitle, SelectedCard.Task.task_order, SelectedCard.Task.column_id);
            onPropertyChanged(nameof(SelectedCard));
        }

        #endregion

        #region Methods

        public static void ClearForm()
        {
            SelectedCardTitle = "";
        }

        public static void DeselectCards()
        {
            for(int i=0; i<Nodes.Count; i++)
                for(int j=0; j<Nodes[i].Cards.Count; j++)
                {
                    CardViewModel card = Nodes[i].Cards[j];
                    Nodes[i].Cards.RemoveAt(j);
                    Nodes[i].Cards.Insert(j, card);
                }
        }

        private bool IsLabelDuplicate()
        {
            for(int i=0; i< DataProgram.availableLabels.Count; i++)
                if (DataProgram.availableLabels[i].Text.Equals(NewLabelTitle))
                    return true;

            return false;
        }

        #endregion
    }
}
