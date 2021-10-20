using BAL.Enum;
using BAL.Model;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ResourceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Response GetALLResources()
        {
            var Resources = _unitOfWork.ResourceRepository.Get();
            return new Response { Status = ResponseStatus.Success, Message = "Here is All Resources", Errors = null, Data =  Resources };
        }
    }
}
