using NodeApp.Core;

namespace NodeApp
{
    /// <summary>
    /// Logika interakcji dla klasy NodesPage.xaml
    /// </summary>
    public partial class NodesPage : BasePage<NodesListViewModel>
    {
        public NodesPage()
        {
            InitializeComponent();
            DataProgram.nodesListViewModel = new NodesListViewModel();
            DataContext = DataProgram.nodesListViewModel;
        }
    }
}
