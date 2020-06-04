using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            Items = new ObservableCollection<NodeContentListViewModel>
            {
                new NodeContentListViewModel
                {
                    Title = "ToDo",
                    Items = new ObservableCollection<NodeListItemViewModel>
                    {
                        new NodeListItemViewModel
                        {
                            Title = "Przykład 1",
                            Labels = new ObservableCollection<CardLabel>
                            {
                                new CardLabel
                                {
                                    Text = "STUDIA",
                                    BackgroundRGBColor = "46a",
                                    ForegroundRGBColor = "fff"
                                },
                                new CardLabel
                                {
                                    Text = "WAŻNE",
                                    BackgroundRGBColor = "D64",
                                    ForegroundRGBColor = "fff"
                                }
                            }
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
                    Items = new ObservableCollection<NodeListItemViewModel>
                    {
                        new NodeListItemViewModel
                        {
                            Title = "Przykład 1"
                        },
                        new NodeListItemViewModel
                        {
                            Title = "Przykład 2",
                            Labels = new ObservableCollection<CardLabel>
                            {
                                new CardLabel
                                {
                                    Text = "ĆWICZENIA",
                                    BackgroundRGBColor = "4a6",
                                    ForegroundRGBColor = "fff"
                                },
                                new CardLabel
                                {
                                    Text = "WAŻNE",
                                    BackgroundRGBColor = "D64",
                                    ForegroundRGBColor = "fff"
                                },
                                new CardLabel
                                {
                                    Text = "PROGRAMOWANIE",
                                    BackgroundRGBColor = "EEE",
                                    ForegroundRGBColor = "000"
                                }
                            }
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
                    Items = new ObservableCollection<NodeListItemViewModel>
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
