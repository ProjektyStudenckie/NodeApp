namespace NodeApp.Core
{
    public class ApplicationViewModel : ViewModelBase
    {
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

        public bool SideMenuVisible { get; set; } = false;


        public void GoToPage(ApplicationPage page)
        {
            CurrentPage = page;

            SideMenuVisible = page == ApplicationPage.Nodes;
        }
    }
}
