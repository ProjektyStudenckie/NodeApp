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

        public bool AreSettingsOpen { get; set; } = false;

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

        public ICommand RemoveSelectedCardCommand { get; set; }

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
            RemoveSelectedCardCommand = new RelayCommand(RemoveSelectedCard);
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
            // ToDo: Implement refresh method
        }

        public void RemoveLabel(object parameter)
        {
            string labelText = parameter.ToString();

            for(int i=0; i< DataProgram.availableLabels.Count; i++)
                if (DataProgram.availableLabels[i].Text.Equals(labelText))
                    DataProgram.availableLabels.RemoveAt(i);

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
            if(SelectedCard != null)
            {
                string labelText = parameter.ToString();

                for (int i = 0; i < DataProgram.availableLabels.Count; i++)
                    if (DataProgram.availableLabels[i].Text == labelText)
                    {
                        if (SelectedCard.Labels.Contains(DataProgram.availableLabels[i]))
                            SelectedCard.Labels.Remove(DataProgram.availableLabels[i]);
                        else
                            SelectedCard.Labels.Add(DataProgram.availableLabels[i]);
                    }
            }
        }


        public void AddNode(object parameter)
        {
            Nodes.Add(new NodeContentListViewModel(new Column("LeGIAPANY", 0)));
        }

        public void AddNodes(List<Column> columns)
        {
            foreach( Column x in columns)
            {
                Nodes.Add(new NodeContentListViewModel(x));
            }  
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
            if (SelectedCard == null)
                return;
            SelectedCard.Title = SelectedCardTitle;
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
