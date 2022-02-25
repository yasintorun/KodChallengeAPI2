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
        private ITrackService _trackService;
        public ProblemManager(IProblemDal problemDal, IProblemInputService problemInputService, ITrackService trackService) : base(problemDal)
        {
            _problemDal = problemDal;
            _problemInputService = problemInputService;
            _trackService = trackService;
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

        public IDataResult<List<Problem>> GetAllByTrackName(string trackName)
        {
            try
            {
                var trackResult = _trackService.Get(x => x.Slug == trackName);
                if(!trackResult.Success || trackResult.Data == null)
                {
                    throw new Exception("Kategori Bulunamadı");
                }
                int trackId = trackResult.Data.Id;
                var data = _problemDal.GetAll(x => x.TrackId == trackId);
                if (data == null || data.Count < 1)
                {
                    throw new Exception("Bu kategoriye ait problem bulunamadı");
                }
                return new SuccessDataResult<List<Problem>>(data, Message.Listed);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<Problem>>(e.Message);
            }
        }

        public IDataResult<List<ProblemDto>> GetAllByTrackNameWithDetails(string trackName)
        {
            try
            {
                var trackResult = _trackService.Get(x => x.Slug == trackName);
                if (!trackResult.Success || trackResult.Data == null)
                {
                    throw new Exception("Kategori Bulunamadı");
                }
                int trackId = trackResult.Data.Id;
                var problemData = _problemDal.GetAll(x => x.TrackId == trackId);
                if (problemData == null || problemData.Count < 1)
                {
                    throw new Exception("Bu kategoriye ait problem bulunamadı");
                }
                var data = new List<ProblemDto>();
                foreach (var problem in problemData)
                {
                    var ioResult = _problemInputService.GetByProblemId(problem.Id);
                    if(ioResult.Success && ioResult.Data != null)
                    {
                        data.Add(new ProblemDto 
                        { 
                            Problem=problem,
                            ProblemInputs=ioResult.Data,
                            Track = trackResult.Data
                        }
                        );
                    }

                }
                return new SuccessDataResult<List<ProblemDto>>(data, Message.Listed);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<ProblemDto>>(e.Message);
            }
        }
    }
}
