using System.Collections.Generic;
using CISS411.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CISS411.Tests.ControllerTests.Home
{
    
    public class Index : Setup
    {
        [Fact]
        public void CanPaginate()
        {
            //Arrange
            base.Arrange();
            sut.PageSize = 2;
            repository.Setup(r => r.Models()).Returns(
                new ExampleModel[] 
                {
                    new ExampleModel { ID = 1, Name = "ModelA" },
                    new ExampleModel { ID = 2, Name = "ModelB" },
                    new ExampleModel { ID = 3, Name = "ModelC" },
                    new ExampleModel { ID = 3, Name = "ModelD" },
                    new ExampleModel { ID = 3, Name = "ModelE" },
                });

            //Act 
            IEnumerable<ExampleModel> result =
                (sut.Index(2) as ViewResult).ViewData.Model as IEnumerable<ExampleModel>;

            // Assert
            ExampleModel[] modelArray = result.ToArray();
            Assert.True(modelArray.Length == 2);
            Assert.Equal("ModelC", modelArray[0].Name);
            Assert.Equal("ModelD", modelArray[1].Name);
        }
    }
}
