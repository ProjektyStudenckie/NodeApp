using System.Collections.ObjectModel;

namespace NodeApp.Core
{
    public class NodeContentListDesignModel : NodeContentListViewModel
    {
        public static NodeContentListDesignModel Instance => new NodeContentListDesignModel();

        #region Constructor

        public NodeContentListDesignModel()
        {
            Title = "Przykładowy node";

            Cards = new ObservableCollection<CardViewModel>
            {
                new CardViewModel
                {
                    Title = "Przykładowy kafelek 1"
                },
                new CardViewModel
                {
                    Title = "Przykładowy kafelek 2"
                },
                new CardViewModel
                {
                    Title = "Przykładowy kafelek 3"
                },
                new CardViewModel
                {
                    Title = "Przykładowy kafelek 4"
                },
                new CardViewModel
                {
                    Title = "Przykładowy kafelek 5"
                }
            };
        }

        #endregion
    }
}
