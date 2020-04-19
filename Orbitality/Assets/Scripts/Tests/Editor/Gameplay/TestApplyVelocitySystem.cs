using Gameplay.Systems;
using NUnit.Framework;

namespace Tests.Editor.Gameplay
{
    public class TestApplyVelocitySystem : AbstractTest
    {
        [Test]
        public void SmokeTest()
        {
            var velocityX = 1;
            var velocityY = 2;
            var velocityZ = 3;
            
            var system = new ApplyVelocitySystem(C);

            var entity = C.gameplay.CreateEntity();
                entity.ReplacePosition(0, 0, 0);
                entity.ReplaceVelocity(velocityX, velocityY, velocityZ);
            
            system.Execute();
            
            Assert.AreEqual(velocityX, entity.position.X);
            Assert.AreEqual(velocityY, entity.position.Y);
            Assert.AreEqual(velocityZ, entity.position.Z);
        }
    }
}