using Ninject;

namespace NodeApp.Core
{
    public static class IoC
    {
        #region public properties

        public static IKernel Kernel { get; set; } = new StandardKernel();

        #endregion

        #region construction

        public static void Setup()
        {
            BindViewModels();
        }

        private static void BindViewModels()
        {
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }

        #endregion

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
