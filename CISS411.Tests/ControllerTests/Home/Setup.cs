using CISS411.Controllers;
using Moq;
using CISS411.Models.Interfaces;
using CISS411.Controllers.Web;

namespace CISS411.Tests.ControllerTests.Home
{
    public class Setup
    {
        protected HomeController sut; // sut stands for "System under test" and it's an industry convention
        protected Mock<IModelRepository> repository;

        protected virtual void Arrange()
        {
            repository = new Mock<IModelRepository>();
            sut = new HomeController(repository.Object);
        }
        
    }
}
