using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TrackManager : BaseManager<Track>, ITrackService
    {
        private ITrackDal _trackDal;
        public TrackManager(ITrackDal trackDal) : base(trackDal)
        {
            _trackDal = trackDal;
        }
    }
}
