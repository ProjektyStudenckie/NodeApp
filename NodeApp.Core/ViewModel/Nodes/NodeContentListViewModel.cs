using System.Collections.Generic;

namespace NodeApp.Core
{
    public class NodeContentListViewModel : ViewModelBase
    {
        public string Title { get; set; }

        public List<NodeListItemViewModel> Items { get; set; }
    }
}
