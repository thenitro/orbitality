using Gameflow.Enums;
using Gameflow.Systems;
using NUnit.Framework;

namespace Tests.Editor.Gameflow
{
    public class TestInitGameSystem : AbstractTest
    {
        [Test]
        public void SmokeTest()
        {
            var system = new InitGameSystem(C);
            
            Assert.False(C.gameflow.hasState);
            
            system.Initialize();
            
            Assert.True(C.gameflow.hasState);
            Assert.AreEqual(GameState.MainMenu, C.gameflow.state.Value);
        }
    }
}