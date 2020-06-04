using System.Collections.ObjectModel;

namespace NodeApp.Core
{
    public class NodeListItemViewModel : ViewModelBase
    {
        public string Title { get; set; }

        public ObservableCollection<CardLabel> Labels { get; set; }
    }
}
