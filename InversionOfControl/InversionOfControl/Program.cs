using System;
using Microsoft.Extensions.DependencyInjection;

namespace InversionOfControl
{
    class Program
    {
       
        static void Main(string[] args)
        {
        // var serviceC = new ServiceC(new MyLogger());
        //
        // var serviceB = new ServiceB(serviceC, new MyLogger());
        //
        // var serviceA = new ServiceA(serviceB, new MyLogger() );
        
            var services = ConfigureServices(); 
            
            var serviceProvider = services.BuildServiceProvider(); // framework operation

            var serviceA = serviceProvider.GetService<IServiceA>(); //get me serviceA, create all it's dependencies 

            Console.WriteLine(serviceA.CalculateA());
        }

        //helper function
        private static IServiceCollection ConfigureServices()  //within dependencyInjection framework // needs to happen at the highest level/client layer
        {
            IServiceCollection services = new ServiceCollection(); //custom collection
            
            services.AddTransient<IServiceC, ServiceC>(); //AddTransient: When you see IServiceC, you will create an instance of ServiceC
            services.AddTransient<IServiceB, ServiceB>(); //doesn't have to have an interface 
            services.AddTransient<IServiceA, ServiceA>();  
            services.AddScoped<IMyLogger, MyLogger>();
            
            return services;
        }
    }
}

//Transient objects are always different; a new instance is provided to every controller and every service.
//Scoped objects are the same within a request, but different across different requests.
//Singleton objects are the same for every object and every request.
//Also takes care of disposing objects 

//Dependency inversion is part of SOLID
//IOC container - Microsoft.Extensions.DependencyInjection