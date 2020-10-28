using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using MobileApp.Data;
using MobileApp.Data.Interfaces;
using MobileApp.Data.Repositories;
using MobileApp.Screens;
using MobileApp.ViewModels;
using System;
using Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
           // containerBuilder.RegisterType<ClientRepository>().As<IClientRepository>().SingleInstance();
            containerBuilder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerLifetimeScope();


            containerBuilder.RegisterType<InterventionRepository>().As<IInterventionRepository>().SingleInstance();
            containerBuilder.RegisterType<PageService>().As<IPageService>().SingleInstance();

           // containerBuilder.RegisterType<AppDbContext>().InstancePerLifetimeScope();

            //ViewModels
            containerBuilder.RegisterType<ClientsViewModel>();
            containerBuilder.RegisterType<ClientDetailsViewModel>();
            containerBuilder.RegisterType<InterventionsViewModel>();
            containerBuilder.RegisterType<InterventionDetailsViewModel>();
            
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
