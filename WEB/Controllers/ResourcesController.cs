using BAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly IResourceService _resourceService;
        public ResourcesController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GeAllResources()
        {
            return StatusCode(StatusCodes.Status200OK, _resourceService.GetALLResources());
        }
    }
}
