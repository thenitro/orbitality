using Gameplay.Systems;
using NUnit.Framework;

namespace Tests.Editor.Gameplay
{
    public class TestOnHealthChangeSystem : AbstractTest
    {
        [Test]
        public void SmokeTest()
        {
            var system = new OnHealthChangeSystem(C);

            var entity = C.gameplay.CreateEntity();
                entity.ReplaceHealth(1);
            
            system.Execute();
            
            Assert.False(entity.isReadyToDestroy);
            entity.ReplaceHealth(-1);
            
            system.Execute();
            
            Assert.True(entity.isReadyToDestroy);
        }
    }
}