using System.Collections.ObjectModel;

namespace NodeApp.Core
{
    public class CardViewModel : ViewModelBase
    {
        public string Title { get; set; }

        public ObservableCollection<CardLabel> Labels { get; set; }
    }
}
