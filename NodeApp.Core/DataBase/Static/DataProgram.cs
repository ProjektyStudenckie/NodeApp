using NodeApp.Core;
using System.Collections.ObjectModel;

namespace NodeApp
{
    public static class DataProgram
    {
        private static Room room;

        public static Room Room
        {
            get { return room; }
            set { room = value; }
        }  

        public static NodesListViewModel nodesListViewModel;
        public static ObservableCollection<CardLabel> availableLabels { get; set; } = new ObservableCollection<CardLabel>();
    }
}
