using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using MobileApp.Screens;
using MobileApp.ViewModels;
using Unity;
using Xamarin.Forms;

namespace MobileApp
{
    public partial class App : Application
    {
        static IContainer container { get; set; }

        public App()
        {
            InitializeComponent();

            InitializeIOCContainer();

            MainPage = new NavigationPage(new ClientsPage());
        }

        void InitializeIOCContainer()
        {
            var containerBuilder = new ContainerBuilder();
         
            containerBuilder.RegisterType<PageService>().As<IPageService>().SingleInstance();

            //ViewModels
            containerBuilder.RegisterType<ClientsViewModel>();
            containerBuilder.RegisterType<ClientDetailsViewModel>();
            containerBuilder.RegisterType<InterventionsViewModel>();
            containerBuilder.RegisterType<InterventionDetailsViewModel>();
            containerBuilder.RegisterType<ReportViewModel>();

            container = containerBuilder.Build();

            var csl = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => csl);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
