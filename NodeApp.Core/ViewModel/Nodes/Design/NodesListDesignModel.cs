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

            Nodes = new ObservableCollection<NodeContentListViewModel>
            {
                new NodeContentListViewModel
                {
                    Title = "ToDo",
                    Cards = new ObservableCollection<CardViewModel>
                    {
                        new CardViewModel
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
                        new CardViewModel
                        {
                            Title = "Przykład 2"
                        },
                        new CardViewModel
                        {
                            Title = "Przykład 3"
                        },
                        new CardViewModel
                        {
                            Title = "Przykład 4"
                        },
                        new CardViewModel
                        {
                            Title = "Przykład 5"
                        },
                        new CardViewModel
                        {
                            Title = "Przykład 6"
                        },
                    }
                },
                new NodeContentListViewModel
                {
                    Title = "In Progress",
                    Cards = new ObservableCollection<CardViewModel>
                    {
                        new CardViewModel
                        {
                            Title = "Przykład 1"
                        },
                        new CardViewModel
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
                        new CardViewModel
                        {
                            Title = "Przykład 3"
                        }
                    }
                },
                new NodeContentListViewModel
                {
                    Title = "Done",
                    Cards = new ObservableCollection<CardViewModel>
                    {
                        new CardViewModel
                        {
                            Title = "Przykład 1"
                        },
                        new CardViewModel
                        {
                            Title = "Przykład 2"
                        },
                        new CardViewModel
                        {
                            Title = "Przykład 3"
                        },
                        new CardViewModel
                        {
                            Title = "Przykład 4"
                        },
                        new CardViewModel
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
