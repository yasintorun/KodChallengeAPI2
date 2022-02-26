using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
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

        public IDataResult<Track> GetBySlug(string slug)
        {
            try
            {
                var data = _trackDal.Get(x => x.Slug.Equals(slug));
                return new SuccessDataResult<Track>(data, "Kategori adına göre getirildi");
            } catch (Exception ex)
            {
                return new ErrorDataResult<Track>(ex.Message);
            }
        }
    }
}
