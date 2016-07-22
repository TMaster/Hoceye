﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HocEye.Core;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Operations;
using Moq;
using NUnit.Framework;

namespace Hoceye.Core.Tests
{
    [TestFixture(Author = "Tomer K", Category = "Hoceye.Core")]
    public class PathConstructorTests
    {
        [Test(Description = "Validate simple path construction, when the all the path elements exist in the same line")]
        [TestCase("application.prod.resources.mongo.connection",",application.prod.resources.mongo")]
        public void When_Constucting_Elment_Path(string rawLine, string excpectedPath)
        {
            //Act

            var textNavigator = new Mock<ITextStructureNavigator>();
            
            
            var constructor = new PathConstructor(textNavigator.Object);

            //Act

            var pathResult = constructor.ConstructPathBackwards(rawLine,excpectedPath.Length-3);

            //Assert

            Assert.That(pathResult, Is.EqualTo(excpectedPath));

        }
    }
}