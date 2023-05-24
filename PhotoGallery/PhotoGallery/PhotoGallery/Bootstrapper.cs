using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using Autofac;
//using PhotoGallery.ViewsModels;
using Xamarin.Forms;

namespace PhotoGallery
{
    public abstract class Bootstrapper
    {
        protected ContainerBuilder ContainerBuilder
        { get; private set; }

        protected Bootstrapper()
        {
            Initialize();
            FinishInitialization();
        }

        protected virtual void Initialize()
        {
            ContainerBuilder = new ContainerBuilder();
            //ContainerBuilder.RegisterType<MainShell>();

            var currentAssembly = Assembly.GetExecutingAssembly();

            foreach(var type in 
                currentAssembly.DefinedTypes.Where( e => 
                e.IsSubclassOf(typeof(ContentPage))
             ))
            {
                ContainerBuilder.RegisterType(type.AsType());
            }
        }

        private void FinishInitialization()
        {
            var container = ContainerBuilder.Build();
            Resolver.Initialize(container);
        }
    }
}
