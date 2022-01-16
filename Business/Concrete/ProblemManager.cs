using Business.Abstract;
using Business.Constants;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProblemManager : BaseManager<Problem>, IProblemService
    {
        private IProblemDal _problemDal;
        private IProblemInputService _problemInputService;
        public ProblemManager(IProblemDal problemDal, IProblemInputService problemInputService) : base(problemDal)
        {
            _problemDal = problemDal;
            _problemInputService = problemInputService;
        }

        public IResult Add(ProblemDto dto)
        {
            //validate
            //business
            this.Add(dto.Problem);
         //   _problemInputService.Add(dto.ProblemInput);

            return new SuccessResult(Message.Added);
        }

        public IDataResult<List<Problem>> GetAllByTrackId(int trackId)
        {
            try
            {
                var data = _problemDal.GetAll(x => x.TrackId == trackId);
                if(data == null ||  data.Count<1)
                {
                    throw new Exception("Bu kategoriye ait problem bulunamadı");
                }
                return new SuccessDataResult<List<Problem>>(data, Message.Listed);
            }catch(Exception e)
            {
                return new ErrorDataResult<List<Problem>>(e.Message);
            }
        }
    }
}
