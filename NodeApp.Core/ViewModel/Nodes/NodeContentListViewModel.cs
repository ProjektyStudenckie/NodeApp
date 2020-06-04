using System.Collections.ObjectModel;

namespace NodeApp.Core
{
    public class NodeContentListViewModel : ViewModelBase
    {
        public string Title { get; set; }

        public ObservableCollection<NodeListItemViewModel> Items { get; set; }
    }
}
