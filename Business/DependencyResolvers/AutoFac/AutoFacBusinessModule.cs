using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.AutoFac
{
    public class AutoFacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //difficulty
            builder.RegisterType<EfDifficultyDal>().As<IDifficultyDal>().SingleInstance();
            builder.RegisterType<DifficultyManager>().As<IDifficultyService>().SingleInstance();

            //track
            builder.RegisterType<EfTrackDal>().As<ITrackDal>().SingleInstance();
            builder.RegisterType<TrackManager>().As<ITrackService>().SingleInstance();

            //problem
            builder.RegisterType<EfProblemDal>().As<IProblemDal>().SingleInstance();
            builder.RegisterType<ProblemManager>().As<IProblemService>().SingleInstance();

            //problem inputs
            builder.RegisterType<EfProblemInputDal>().As<IProblemInputDal>().SingleInstance();
            builder.RegisterType<ProblemInputManager>().As<IProblemInputService>().SingleInstance();

            //user
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();


            /*var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();*/
        }
    }
}
