using Gameflow.Enums;
using Gameflow.Systems;
using NUnit.Framework;

namespace Tests.Editor.Gameflow
{
    public class TestOnGameOverSystem : AbstractTest
    {
        [Test]
        public void SmokeTest()
        {
            var system = new OnGameOverSystem(C);
            
            C.gameflow.ReplaceGameOver(true);
            
            Assert.False(C.gameflow.hasState);
            
            system.Execute();
            
            Assert.True(C.gameflow.hasState);
            Assert.AreEqual(GameState.GameOver, C.gameflow.state.Value);
        }
    }
}