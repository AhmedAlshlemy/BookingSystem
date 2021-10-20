using BAL.Enum;
using BAL.Model;
using BAL.Services;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST.FakeServices
{
    public class FakeBookingService : IResourceService
    {
        private readonly List<Resource> _resources;

        public FakeBookingService()
        {
            _resources = new List<Resource>();
            
                for (int i = 1; i <= 10; i++)
                {
                    Resource temp = new Resource
                    {
                        Id = i,
                        Name = $"Resource number {i}",
                        Quantity =(i*10)
                    };
                    _resources.Add(temp);
                }
        }
        public Response GetALLResources()
        {
          return new Response { Status = ResponseStatus.Success, Message = "Here is All Resources", Errors = null, Data = _resources};
        }
    }
}
