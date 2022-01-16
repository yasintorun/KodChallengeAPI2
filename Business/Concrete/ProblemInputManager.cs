using Business.Abstract;
using Business.Constants;
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
    public class ProblemInputManager : BaseManager<ProblemInput>, IProblemInputService
    {
        private IProblemInputDal _problemInputDal;
        public ProblemInputManager(IProblemInputDal problemInputDal) : base(problemInputDal)
        {
            _problemInputDal = problemInputDal;
        }

        public IDataResult<ProblemInput> GetByProblemId(int problemId)
        {
            try
            {
                var problemInputs = _problemInputDal.GetAll(p => p.ProblemId == problemId);
                return new SuccessDataResult<ProblemInput>(Message.Listed);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ProblemInput>(Message.Error + " Mesaj: " + ex.Message);
            }
        }
    }
}
