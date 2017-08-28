using System;
using Xunit;
using CISS411.Controllers;
using CISS411.Models;
using Moq;

namespace CISS411.Tests.ControllerTests.Home
{
    public class Setup
    {
        protected HomeController sut; // sut stands for "System under test" and it's an industry convention
        protected Mock<IExampleRepository> repository;

        protected virtual void Arrange()
        {
            repository = new Mock<IExampleRepository>();
            sut = new HomeController(repository.Object);
        }
        
    }
}
