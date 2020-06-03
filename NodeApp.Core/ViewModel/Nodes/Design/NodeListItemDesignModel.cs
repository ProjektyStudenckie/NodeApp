namespace NodeApp.Core
{
   public class NodeListItemDesignModel : NodeListItemViewModel
    {
        public static NodeListItemDesignModel Instance => new NodeListItemDesignModel();

        #region Constructor

        public NodeListItemDesignModel()
        {
            Title = "Przykładowy kafelek";
        }

        #endregion
    }
}
