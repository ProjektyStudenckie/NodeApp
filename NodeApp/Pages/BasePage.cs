using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using NodeApp.Core;

namespace NodeApp
{
    public class BasePage<VM> : Page
        where VM : ViewModelBase, new()
    {
        #region Private Member

        private VM mViewModel;

        #endregion


        #region Public Properties

        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlidaAndFadeOutToLeft;

        public float SlideSeconds { get; set; } = 0.8f;

        public VM ViewModel
        {
            get { return mViewModel; }
            set
            {
                if (mViewModel == value)
                    return;

                mViewModel = value;

                this.DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructor

        public BasePage()
        {
            // If we are animating in, hide to begin with
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            // Listen out for the page loading
            this.Loaded += BasePage_Loaded;

            this.ViewModel = new VM();
        }

        #endregion

        #region Animation Load / Unload

        /// <summary>
        /// Once the page is loaded, perform any required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            await AnimateIn();
        }

        public async Task AnimateIn()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRight(this.SlideSeconds);
                    break;
            }
        }

        public async Task AnimateOut()
        {
            if (this.PageUnloadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlidaAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeft(this.SlideSeconds);
                    break;
            }
        }

        #endregion
    }
}
