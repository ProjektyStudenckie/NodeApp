using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NodeApp.Core
{
    /// <summary>
    /// View Model for the custom flat window
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        #region Public Properties

        public string RoomName { get; set; }

        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }

        #endregion

        #region Constructor

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(async (parameter) => await Login(parameter));
        }

        #endregion

        public async Task Login(object parameter)
        {

            await RunCommand(() => this.LoginIsRunning, async () =>
            {
                //Change page to nodes page if everything is ok
                IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Nodes);

                Room room = new Room("Kasza");
                DataRoom.AddRoom(room);
                Column column = new Column("Wtorek", room.room_id);
                DataColumn.AddColumn(column);
                Lable lable = new Lable("kuczak", "ffff", "ffff");
                DataLable.AddLable(lable);
                Tasks task = new Tasks("zadanie domowe", 2, column.column_id);
                DataTask.AddTask(task);
                LableTask lt = new LableTask(lable, task);
                DataLableTask.AddLableTask(lt);
                List<LableTask> list = DataLableTask.DownloadLableTask();
                List<Lable> lables = DataLable.DownloadLables();
                List<Lable> list2 = DataLableTask.ReturnLabelsOfTask(lables, task);
                List<Column> listcol = DataColumn.ReturnColumnsOfRoom(room);
                DataLableTask.DeleteLableTask(lt);
                DataTask.DeleteTask(task);
                DataColumn.DeleteColumn(column);
            });
        }
    }
}
