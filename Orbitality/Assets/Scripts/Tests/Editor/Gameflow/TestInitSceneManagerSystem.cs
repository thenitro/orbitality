using Gameflow.Systems;
using NUnit.Framework;

namespace Tests.Editor.Gameflow
{
    public class TestInitSceneManagerSystem : AbstractTest
    {
        [Test]
        public void SmokeTest()
        {
            var system = new InitSceneManagerSystem(C);
            
            Assert.False(C.gameflow.hasGameSceneManager);
            
            system.Initialize();
            
            Assert.True(C.gameflow.hasGameSceneManager);
            Assert.NotNull(C.gameflow.gameSceneManager.Value);
        }
    }
}