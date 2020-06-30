using NodeApp.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static ObservableCollection<CardLabel> availableLabels 
        {
            get;
            set;
        }= new ObservableCollection<CardLabel>();
    }
}
