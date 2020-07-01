using System.Collections.ObjectModel;

namespace NodeApp.Core
{
    public class NodeContentListDesignModel : NodeContentListViewModel
    {
        public static NodeContentListDesignModel Instance => new NodeContentListDesignModel(new Column("New Node",0));

        #region Constructor

        public NodeContentListDesignModel(Column column):base(column)
        {

            Cards = new ObservableCollection<CardViewModel>
            {
                new CardViewModel(new Tasks("Mistrze Jest Nasz", 0,1)),
            };
        }

        #endregion
    }
}
