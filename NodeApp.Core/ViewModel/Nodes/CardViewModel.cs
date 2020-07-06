using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NodeApp.Core
{
    public class CardViewModel : ViewModelBase
    {
        #region Public Properties
        
        public string Title { get; set; }

        private Tasks _Task;

        public Tasks Task {
            get
            {
                return _Task;
            } 
            set 
            {
                if(_Task == null)
                {
                    _Task = value; 
                }
                else
                {
                    _Task = value;
                    DataTask.EditTask(_Task, _Task.task_id);
                }
            } 
            
        }
            
        public ObservableCollection<CardLabel> Labels { get; set; } = new ObservableCollection<CardLabel>();

        #endregion


        #region Public Commands

        public ICommand DeleteCardCommand { get; set; }

        public ICommand MoveCardRightCommand { get; set; }
        public ICommand MoveCardLeftCommand { get; set; }

        public ICommand MoveCardUpCommand { get; set; }
        public ICommand MoveCardDownCommand { get; set; }

        #endregion


        #region Constructor

        public CardViewModel(Tasks Task)
        {
            this.Task = Task;
            Title = this.Task.task_name;
            DeleteCardCommand = new RelayCommand(DeleteCard);

            MoveCardRightCommand = new RelayCommand(MoveCardRight, (arg) => NodesListViewModel.CanMoveCardRight(this));
            MoveCardLeftCommand = new RelayCommand(MoveCardLeft, (arg) => NodesListViewModel.CanMoveCardLeft(this));

            MoveCardUpCommand = new RelayCommand(MoveCardUp, (arg) => NodesListViewModel.CanMoveCardUp(this));
            MoveCardDownCommand = new RelayCommand(MoveCardDown, (arg) => NodesListViewModel.CanMoveCardDown(this));

            AddLabels();
        }



        #endregion

        public void AddLabels()
        {
            List<Lable> labels = DataLableTask.ReturnLabelsOfTask(DataLable.DownloadLables(), Task);
            if (labels.Count > 0)
            {
                foreach (Lable y in labels)
                {
                    string labelText = y.lable_text.ToString();

                    for (int x = 0; x < DataProgram.availableLabels.Count; x++)
                        if (DataProgram.availableLabels[x].Text == labelText)
                        {
                            Labels.Add(DataProgram.availableLabels[x]);
                        }

                }
            }
        }

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
