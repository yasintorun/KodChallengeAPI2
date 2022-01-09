using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Ninject
{
    internal class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            //difficulty
            Bind<IDifficultyDal>().To<EfDifficultyDal>().InSingletonScope();
            Bind<IDifficultyService>().To<DifficultyManager>().InSingletonScope();

            //Track
            Bind<ITrackDal>().To<EfTrackDal>().InSingletonScope();
            Bind<ITrackService>().To<TrackManager>().InSingletonScope();

            //problem
            Bind<IProblemDal>().To<EfProblemDal>().InSingletonScope();
            Bind<IProblemService>().To<ProblemManager>().InSingletonScope();

            //User
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

        }
    }
}
