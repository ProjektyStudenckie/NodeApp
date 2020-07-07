using NodeApp.Core;
using System.Collections.Generic;
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

        public static void DeleteTaskWithRelations(Tasks task)
        {
            List<LableTask> relationsToDestroy = DataLableTask.ReturnRelationsOfTask(task);
            foreach (LableTask x in relationsToDestroy)
            {
                DataLableTask.DeleteLableTask(x);
            }
            DataTask.DeleteTask(task);
            
        }
    }
}
