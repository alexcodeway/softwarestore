using NSubstitute;
using SoftwareStore.DataManager;
using SoftwareStore.Models;
using SoftwareStore.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SoftwareStoreTests.cs
{
    public class SoftwareServiceTests
    {
        public readonly ISoftwareManager _softwareManager;
        public readonly ISoftwareService _softwareService;

        public SoftwareServiceTests()
        {
            _softwareManager = Substitute.For<ISoftwareManager>();
            _softwareService = new SoftwareService(_softwareManager);
        }

        [Theory]
        [InlineData("2", 5)]
        [InlineData("2018", 0)]
        [InlineData("0.0.1", 8)]
        public void GetSoftwareGreaterThan_Should_Return_Correct_Values(string version, int expected)
        {
            // arrange (could be shifted to ctor)
            _softwareManager.GetAllSoftware().Returns(
            new List<Software>
            {
                new Software
                {
                    Name = "MS Word",
                    Version = "13.2.1."
                },
                new Software
                {
                    Name = "Angular1",
                    Version = "1.0.9"
                },
                new Software
                {
                    Name = "Angular2",
                    Version = "2"
                },
                new Software
                {
                    Name = "Doom",
                    Version = "0.0.5"
                },
                new Software
                {
                    Name = "Clippy",
                    Version = "2.1"
                },
                new Software
                {
                    Name = "Visual Studio",
                    Version = "2017.0.1"
                },
                new Software
                {
                    Name = "Sublime3",
                    Version = "3.9"
                },
                new Software
                {
                    Name = "Call of Duty",
                    Version = "9.9.9"
                }
            });

            // act
            var result = _softwareService.GetSoftwareGreaterThan(version);

            // assert
            Assert.Equal(expected, result.ToList().Count);

        }
    }
}
