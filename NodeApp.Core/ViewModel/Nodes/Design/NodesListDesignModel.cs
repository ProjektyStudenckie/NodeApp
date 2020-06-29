using System.Collections.ObjectModel;

namespace NodeApp.Core
{
    public class NodesListDesignModel : NodesListViewModel
    {
        public static NodesListDesignModel Instance => new NodesListDesignModel();

        #region Constructor

        public NodesListDesignModel()
        {
            var l1 = new NodeContentListViewModel(new Column("LeGIAPANY", 0));

            Nodes = new ObservableCollection<NodeContentListViewModel>
            {
                new NodeContentListViewModel(new Column("LeGIAPANY",0))
                {
                    Cards = new ObservableCollection<CardViewModel>
                    {
                      
                    }
                },
                new NodeContentListViewModel(new Column("LeGIAPANY",0))
                {
                    Cards = new ObservableCollection<CardViewModel>
                    {
                    }
                },
                new NodeContentListViewModel(new Column("LeGIAPANY",0))
                {
                   
                }
            };
        }

        #endregion
    }
}
