using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProblemService : IBaseService<Problem>
    {
        IResult Add(ProblemDto dto);
        IDataResult<List<Problem>> GetAllByTrackId(int trackId);
        IDataResult<List<Problem>> GetAllByTrackName(string trackName);
        IDataResult<List<ProblemDto>> GetAllByTrackNameWithDetails(string trackName);
    }
}
