using Gameplay;
using Gameplay.Systems;
using NUnit.Framework;

namespace Tests.Editor.Gameplay
{
    public class TestOnSunCreatedSystem : AbstractTest
    {
        [Test]
        public void SmokeTest()
        {
            var system = new OnSunCreatedSystem(C);

            var sunEntity = C.gameplay.CreateEntity();
                sunEntity.ReplaceGameObjectType(GameObjectType.Sun);

            var mass = 10f;
                
            C.gameSettings.ReplaceSunPhysics(mass);
                
            Assert.False(sunEntity.hasPosition);
            
            system.Execute();
            
            Assert.True(sunEntity.hasPosition);
            Assert.AreEqual(0, sunEntity.position.X);
            Assert.AreEqual(0, sunEntity.position.Y);
            Assert.AreEqual(0, sunEntity.position.Z);
            
            Assert.True(sunEntity.hasVelocity);
            Assert.AreEqual(0, sunEntity.velocity.X);
            Assert.AreEqual(0, sunEntity.velocity.Y);
            Assert.AreEqual(0, sunEntity.velocity.Z);
            
            Assert.True(sunEntity.hasMass);
            Assert.AreEqual(mass, sunEntity.mass.Value);
        }
        
        [Test]
        public void NotSun([Values] GameObjectType type)
        {
            if (type == GameObjectType.Sun)
            {
                return;
            }
            
            var system = new OnSunCreatedSystem(C);

            var gameplayEntity = C.gameplay.CreateEntity();
                gameplayEntity.ReplaceGameObjectType(type);
                
            Assert.False(gameplayEntity.hasPosition);
            
            system.Execute();
            
            Assert.False(gameplayEntity.hasPosition);
        }
    }
}