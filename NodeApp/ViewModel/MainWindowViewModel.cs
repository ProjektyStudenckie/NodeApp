using NodeApp.Core;
using System.Windows;
using System.Windows.Input;

namespace NodeApp
{
    class MainWindowViewModel : ViewModelBase
    {
        #region Private Member

        private Window mWindow;

        private WindowResizer mWindowResizer;

        /// <summary>
        /// Margin around the window to allow for a drop shadow
        /// </summary>
        private int mOuterMarginSize = 10;

        private int mWindowRadius = 10;

        private WindowDockPosition mDockPosition = WindowDockPosition.Undocked;

        #endregion

        #region Public Properties

        public double WindowMinimumWidth { get; set; } = 800;
        public double WindowMinimumHeight { get; set; } = 500;


        public bool Borderless
        {
            get
            {
                return (mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked);
            }
        }

        /// <summary>
        /// The size of the resize border arount the window
        /// </summary>
        public int ResizeBorder { get { return Borderless ? 0 : 6; } }

        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize);

        public Thickness InnerContentPadding => new Thickness(0);

        public int OuterMarginSize
        {
            get
            {
                // No outer margin while window is maximized
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }
        public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);

        public int WindowRadius
        {
            get
            {
                // If it is maximized or docked, no border
                return Borderless ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }

        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

        public int TitleHeight { get; set; } = 42;
        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);

        #endregion

        #region Commands

        public ICommand MenuCommand { get; set; }

        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        #endregion

        #region Constructor

        public MainWindowViewModel(Window window)
        {
            mWindow = window;

            // Listen out for the window resizing
            mWindow.StateChanged += (sender, e) =>
            {
                WindowResized();
            };

            MinimizeCommand = new RelayCommand((arg) => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand((arg) => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand((arg) => mWindow.Close());
            MenuCommand = new RelayCommand((arg) => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            // Fix window resize issue
            mWindowResizer = new WindowResizer(mWindow);

            // Listen out for dock changes
            mWindowResizer.WindowDockChanged += (dock) =>
            {
                // Store last position
                mDockPosition = dock;

                // Fire off resize events
                WindowResized();
            };
        }

        #endregion

        #region Private Helpers

        public Point GetMousePosition()
        {
            return mWindowResizer.GetCursorPosition();
        }

        private void WindowResized()
        {
            // Fire off events for all properties that are affected by a resize
            onPropertyChanged(nameof(Borderless));
            onPropertyChanged(nameof(ResizeBorderThickness));
            onPropertyChanged(nameof(OuterMarginSize));
            onPropertyChanged(nameof(OuterMarginSizeThickness));
            onPropertyChanged(nameof(WindowRadius));
            onPropertyChanged(nameof(WindowCornerRadius));
        }

        #endregion
    }
}

