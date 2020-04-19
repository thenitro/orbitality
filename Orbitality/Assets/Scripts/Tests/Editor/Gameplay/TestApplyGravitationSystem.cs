using Gameplay.Systems;
using NUnit.Framework;

namespace Tests.Editor.Gameplay
{
    public class TestApplyGravitationSystem : AbstractTest
    {
        [Test]
        public void SmokeTest()
        {
            var system = new ApplyGravitationSystem(C);

            var entitySmall = C.gameplay.CreateEntity();
                entitySmall.ReplacePosition(100, 0, 0);
                entitySmall.ReplaceMass(1);
                entitySmall.ReplaceVelocity(0, 1, 0);
                
            var entityBig = C.gameplay.CreateEntity();
                entityBig.ReplacePosition(0, 0, 0);
                entityBig.ReplaceMass(10000);
                entityBig.ReplaceVelocity(0, 0, 0);
            
            system.Execute();
            
            Assert.AreEqual(-1.0f, entitySmall.velocity.X);
            Assert.AreEqual(1f, entitySmall.velocity.Y);
            Assert.AreEqual(0f, entitySmall.velocity.Z);
            
            Assert.AreEqual(0.0001f, entityBig.velocity.X);
            Assert.AreEqual(0f, entityBig.velocity.Y);
            Assert.AreEqual(0f, entityBig.velocity.Z);
        }
        
        [Test]
        public void OnlyOneEntityIsValid()
        {
            var system = new ApplyGravitationSystem(C);

            var entitySmall = C.gameplay.CreateEntity();
                entitySmall.ReplacePosition(100, 0, 0);
                entitySmall.ReplaceMass(1);
                entitySmall.ReplaceVelocity(0, 1, 0);
                
            var entityBig = C.gameplay.CreateEntity();
                entityBig.ReplacePosition(0, 0, 0);
                entityBig.ReplaceMass(10000);
            
            system.Execute();
            
            Assert.AreEqual(0f, entitySmall.velocity.X);
            Assert.AreEqual(1f, entitySmall.velocity.Y);
            Assert.AreEqual(0f, entitySmall.velocity.Z);
        }
    }
}