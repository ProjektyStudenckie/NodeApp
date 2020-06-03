using System.Collections.Generic;

namespace NodeApp.Core
{
    public class NodeContentListDesignModel : NodeContentListViewModel
    {
        public static NodeContentListDesignModel Instance => new NodeContentListDesignModel();

        #region Constructor

        public NodeContentListDesignModel()
        {
            Title = "Przykładowy node";

            Items = new List<NodeListItemViewModel>
            {
                new NodeListItemViewModel
                {
                    Title = "Przykładowy kafelek 1"
                },
                new NodeListItemViewModel
                {
                    Title = "Przykładowy kafelek 2"
                },
                new NodeListItemViewModel
                {
                    Title = "Przykładowy kafelek 3"
                },
                new NodeListItemViewModel
                {
                    Title = "Przykładowy kafelek 4"
                },
                new NodeListItemViewModel
                {
                    Title = "Przykładowy kafelek 5"
                }
            };
        }

        #endregion
    }
}
