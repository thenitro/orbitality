using Gameplay;
using Gameplay.Systems;
using NUnit.Framework;
using Tests.Editor.Mocks;

namespace Tests.Editor.Gameplay
{
    public class TestCreateViewSystem : AbstractTest
    {
        [Test]
        public void SmokeTest([Values] GameObjectType type)
        {
            if (type == GameObjectType.None)
            {
                return;
            }
            
            var system = new CreateViewSystem(C);
            
            C.gameflow.ReplaceGameAssets(new MockedGameAssets());

            var gameplayE = C.gameplay.CreateEntity();
                gameplayE.ReplaceGameObjectType(type);
            
            system.Execute();
            
            Assert.True(gameplayE.hasView);
        }
    }
}