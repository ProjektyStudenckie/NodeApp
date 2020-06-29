using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
                Room room = new Room(RoomName);
                List<Room> Rooms = DataRoom.DownloadRooms();
                if (Rooms.Contains(room))
                { 
                    DataProgram.Room = Rooms.Find(x => x.room_name == room.room_name);
                }
                else
                {
                    DataRoom.AddRoom(room);
                    DataProgram.Room = room;
                }
                IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Nodes);
            });
        }
    }
}
