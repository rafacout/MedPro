using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MedPro.Domain.Entities;

namespace MedPro.UnitTest.Domain
{
    public class SpecialityTests
    {
        [Fact]
        public void Speciality_Constructor()
        {
            // Arrange
            var name = "Cardiology";
            var description = "Cardiology is a branch of medicine that deals with the disorders of the heart as well as some parts of the circulatory system.";

            // Act
            var speciality = new Speciality(name, description);

            // Assert
            name.Should().Be(speciality.Name);
            description.Should().Be(speciality.Description);
        }

        [Fact]
        public void ValidateUpdate()
        {
            // Arrange
            var speciality = new Speciality("Cardiology", "Cardiology is a branch of medicine that deals with the disorders of the heart as well as some parts of the circulatory system.");
            var name = "Cardiology";
            var description = "Cardiology is a branch of medicine that deals with the disorders of the heart as well as some parts of the circulatory system.";

            // Act
            speciality.Update(name, description);

            // Assert
            name.Should().Be(speciality.Name);
            description.Should().Be(speciality.Description);
        }
    }
}
