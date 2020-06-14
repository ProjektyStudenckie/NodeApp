using System.Collections.ObjectModel;

namespace NodeApp.Core
{
   public class CardDesignModel : CardViewModel
    {
        public static CardDesignModel Instance => new CardDesignModel();

        #region Constructor

        public CardDesignModel()
        {
            Title = "Przykładowy kafelek";
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
                },
                new CardLabel
                {
                    Text = "ĆWICZENIA",
                    BackgroundRGBColor = "4a6",
                    ForegroundRGBColor = "fff"
                },
                new CardLabel
                {
                    Text = "NUDNE",
                    BackgroundRGBColor = "999",
                    ForegroundRGBColor = "fff"
                },
                new CardLabel
                {
                    Text = "PROGRAMOWANIE",
                    BackgroundRGBColor = "EEE",
                    ForegroundRGBColor = "000"
                }
            };
        }

        #endregion
    }
}
