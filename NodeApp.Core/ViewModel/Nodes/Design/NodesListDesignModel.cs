using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeApp.Core
{
    public class NodesListDesignModel : NodesListViewModel
    {
        public static NodesListDesignModel Instance => new NodesListDesignModel();

        #region Constructor

        public NodesListDesignModel()
        {
            var l1 = new NodeContentListViewModel();
            l1.Title = "ToDo";

            Items = new List<NodeContentListViewModel>
            {
                new NodeContentListViewModel
                {
                    Title = "ToDo",
                    Items = new List<NodeListItemViewModel>
                    {
                        new NodeListItemViewModel
                        {
                            Title = "Przykład 1"
                        },
                        new NodeListItemViewModel
                        {
                            Title = "Przykład 2"
                        },
                        new NodeListItemViewModel
                        {
                            Title = "Przykład 3"
                        },
                        new NodeListItemViewModel
                        {
                            Title = "Przykład 4"
                        },
                        new NodeListItemViewModel
                        {
                            Title = "Przykład 5"
                        },
                        new NodeListItemViewModel
                        {
                            Title = "Przykład 6"
                        },
                    }
                },
                new NodeContentListViewModel
                {
                    Title = "In Progress",
                    Items = new List<NodeListItemViewModel>
                    {
                        new NodeListItemViewModel
                        {
                            Title = "Przykład 1"
                        },
                        new NodeListItemViewModel
                        {
                            Title = "Przykład 2"
                        },
                        new NodeListItemViewModel
                        {
                            Title = "Przykład 3"
                        }
                    }
                },
                new NodeContentListViewModel
                {
                    Title = "Done",
                    Items = new List<NodeListItemViewModel>
                    {
                        new NodeListItemViewModel
                        {
                            Title = "Przykład 1"
                        },
                        new NodeListItemViewModel
                        {
                            Title = "Przykład 2"
                        },
                        new NodeListItemViewModel
                        {
                            Title = "Przykład 3"
                        },
                        new NodeListItemViewModel
                        {
                            Title = "Przykład 4"
                        },
                        new NodeListItemViewModel
                        {
                            Title = "Przykład 5"
                        }
                    }
                }
            };
        }

        #endregion
    }
}
