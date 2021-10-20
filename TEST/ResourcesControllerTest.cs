using BAL.Model;
using BAL.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST.FakeServices;
using WEB.Controllers;
using Xunit;

namespace TEST
{
    public class ResourcesControllerTest
    {
        private readonly ResourcesController _resourcesController;
        private readonly IResourceService _resourceService;
        public ResourcesControllerTest()
        {
            _resourceService = new FakeBookingService();
            _resourcesController = new ResourcesController(_resourceService);
        }
        [Fact]
        public void GeAllResources_WhenCalled_ReturnsOkResult()
        {
            // Act
            var Result = _resourcesController.GeAllResources() as ObjectResult;

            // Assert
            Assert.IsType<ObjectResult>(Result);
        }

        [Fact]
        public void GeAllResources_WhenCalled_ReturnsAllResources()
        {
            // Act
            var okResult = _resourcesController.GeAllResources() as ObjectResult;

            // Assert
            var Response = Assert.IsType<Response>(okResult.Value);
            Assert.Equal(10, Response.Data.Count);
        }

    }
}
