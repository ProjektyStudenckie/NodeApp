using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NodeApp.Core
{
   public class CardDesignModel : CardViewModel
    {
        public static CardDesignModel Instance => new CardDesignModel(new Tasks("Mistrze Jest Nasz", 0,1));

        #region Constructor

        public CardDesignModel(Tasks Task):base(Task)
        {
            Title = "Przykładowy kafelek";
            Labels = new ObservableCollection<CardLabel>
            {
               
            };
        }

        #endregion
    }
}
