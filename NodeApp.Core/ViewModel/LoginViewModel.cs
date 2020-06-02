﻿using System.Threading.Tasks;
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
                //await Task.Delay(1500);

                IoC.Get<ApplicationViewModel>().SideMenuVisible ^= true;
                return;

                //Change page to nodespage if everything is ok
                //IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Nodes;

                //var roomName = RoomName;

                await Task.Delay(1);
            });
        }
    }
}
