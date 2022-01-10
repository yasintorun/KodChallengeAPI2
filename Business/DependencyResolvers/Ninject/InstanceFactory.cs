using DataAccess.Abstract;
using Business.Abstract;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Ninject
{
    public class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new BusinessModule());
            return kernel.Get<T>();
        }

        public static void RegisterServices()
        {
            GetInstance<IDifficultyDal>();
            GetInstance<IDifficultyService>();
        }
    }
}
