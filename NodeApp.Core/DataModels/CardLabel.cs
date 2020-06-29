namespace NodeApp.Core
{
    public class CardLabel
    {
        #region Public Properties

        public Lable lable { get; set; }

        public string Text { get; set; }

        public string BackgroundRGBColor { get; set; }

        public string ForegroundRGBColor { get; set; }

        public CardLabel(Lable lable)
        {
            this.lable = lable;
            this.Text = lable.lable_text;
            this.BackgroundRGBColor = lable.background;
            this.ForegroundRGBColor = lable.foreground;
        }


        public CardLabel(string Text, string BackgroundRGBColor, string ForegroundRGBColor)
        {
            this.Text = Text; 
            this.BackgroundRGBColor = BackgroundRGBColor;
            this.ForegroundRGBColor = ForegroundRGBColor;
            lable = new Lable(Text, BackgroundRGBColor, ForegroundRGBColor, DataProgram.Room.room_id);
            DataLable.AddLable(lable);
        }
        #endregion
    }
}
