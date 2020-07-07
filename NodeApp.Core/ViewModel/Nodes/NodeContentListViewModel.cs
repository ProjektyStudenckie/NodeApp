using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace NodeApp.Core
{
    public class NodeContentListViewModel : ViewModelBase
    {
        private static CardViewModel selectedCard;

        #region Public Properties

        private Column _Column;
        public Column Column
        {
            get
            {
                return _Column;
            }
            set
            {
                if (_Column == null)
                {
                    _Column = value;
                }
                else
                {
                    _Column = value;
                    DataColumn.EditColumn(_Column, _Column.column_id);
                }
            }
        }

        private string _Title;
        public string Title {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
                Column = new Column(Column.column_id, _Title, Column.room_id);
            }
        }

        public ObservableCollection<CardViewModel> Cards { get; set; }

        public static CardViewModel SelectedCard
        {
            get => selectedCard;
            set
            {
                if (selectedCard == value)
                    return;

                NodesListViewModel.DeselectCards();

                selectedCard = value;

                if (value == null)
                    NodesListViewModel.ClearForm();
                else
                    NodesListViewModel.SelectedCardTitle = selectedCard.Title;

                StaticPropertyChanged?.Invoke(null, SelectedCardPropertyEventArgs);
            }
        }

        public int NodeId { get; set; }

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

        public NodeContentListViewModel(Column column)
        {
            this.Column = column;
            Title = column.column_name;
            Cards = new ObservableCollection<CardViewModel>();

            AddCardCommand = new RelayCommand(AddCard);
            DeleteNodeCommand = new RelayCommand(RemoveNode);

            MoveNodeRightCommand = new RelayCommand(MoveNodeRight, 
                (arg) => { return NodesListViewModel.Nodes.Count > 1 &&
                    NodesListViewModel.Nodes.IndexOf(this) < NodesListViewModel.Nodes.Count - 1; });
            MoveNodeLeftCommand = new RelayCommand(MoveNodeLeft,
                (arg) => { return NodesListViewModel.Nodes.Count > 1 && 
                    NodesListViewModel.Nodes.IndexOf(this) >= 1; });

            List<Tasks> taskList = DataTask.ReturnTasksOfColumn(column);
            AddCardsWithLabel(taskList);
        }

        #endregion


        #region Command Methods

        public void AddCard(object parameter = null)
        {
            if (Cards == null)
                Cards = new ObservableCollection<CardViewModel>();

            Cards.Add(new CardViewModel(new Tasks("New", Cards.Count, Column.column_id)) { Id = Cards.Count });
        }

        public void AddCardsWithLabel(List<Tasks> task)
        {
            if (Cards == null)
                Cards = new ObservableCollection<CardViewModel>();

            foreach (Tasks x in task)
            {
                Cards.Add(new CardViewModel(x));
            }
        }

        public void RemoveNode(object parameter = null)
        {
            int index = NodesListViewModel.Nodes.IndexOf(this);
            for(int i=index+1; i< NodesListViewModel.Nodes.Count; i++)
                NodesListViewModel.Nodes[i].NodeId--;

            NodesListViewModel.Nodes.Remove(this);

            List<Tasks> tasks = DataTask.ReturnTasksOfColumn(Column);
            foreach(Tasks x in tasks)
            {
                DataProgram.DeleteRelationsTask(x);
                DataTask.DeleteTask(x);
            }
            DataColumn.DeleteColumn(Column);
        }

        public void MoveNodeRight(object parameter = null)
        {
            int oldIndex = NodesListViewModel.Nodes.IndexOf(this);
            NodeId = NodesListViewModel.Nodes[oldIndex + 1].NodeId;
            NodesListViewModel.Nodes[oldIndex + 1].NodeId = oldIndex;

            NodesListViewModel.Nodes.Move(oldIndex, ++oldIndex);
        }

        public void MoveNodeLeft(object parameter = null)
        {
            int oldIndex = NodesListViewModel.Nodes.IndexOf(this);
            NodeId = NodesListViewModel.Nodes[oldIndex - 1].NodeId;
            NodesListViewModel.Nodes[oldIndex - 1].NodeId = oldIndex;

            NodesListViewModel.Nodes.Move(oldIndex, --oldIndex);
        }

        #endregion
    }
}
