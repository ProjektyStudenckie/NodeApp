using NodeApp.Core;

namespace NodeApp
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance { get; set; } = new ViewModelLocator();

        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();
    }
}
