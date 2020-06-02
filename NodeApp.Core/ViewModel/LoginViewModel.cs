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
                await Task.Delay(500);


                //Change page to nodes page if everything is ok
                IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Nodes);

                //var roomName = RoomName;
            });
        }
    }
}
