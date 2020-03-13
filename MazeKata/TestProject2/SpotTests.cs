using System;
using MazeKata;
using Xunit;

namespace TestProject2
{
    public class SpotTests
    {
        [Fact]
        public void It_Should_ReturnFalse_When_ItsAWall()
        {
            var wall = new Wall();
            Assert.False(wall.IsWalkable);
        }
        
        [Fact]
        public void It_Should_ReturnFalse_When_ItsAFloor()
        {
            var floor = new Floor();
            Assert.True(floor.IsWalkable);
        }
    }
}