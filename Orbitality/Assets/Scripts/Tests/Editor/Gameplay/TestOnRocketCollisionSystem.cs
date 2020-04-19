using Gameplay;
using Gameplay.Systems;
using NUnit.Framework;

namespace Tests.Editor.Gameplay
{
    public class TestOnRocketCollisionSystem : AbstractTest
    {
        [Test]
        public void SmokeTest([Values] GameObjectType type)
        {
            var system = new OnRocketCollisionSystem(C);

            var rocketE = C.gameplay.CreateEntity();
                rocketE.ReplaceGameObjectType(GameObjectType.Rocket);
                rocketE.ReplaceDamageToDeal(1f);
                
            var otherE = C.gameplay.CreateEntity();
                otherE.ReplaceGameObjectType(type);
                otherE.ReplaceHealth(10f);

            var collisionE = C.gameplay.CreateEntity();
                collisionE.ReplaceCollision(rocketE, otherE);
                
            system.Execute();
            
            Assert.True(rocketE.isReadyToDestroy);

            if (otherE.gameObjectType.Value == GameObjectType.Rocket)
            {
                Assert.True(otherE.isReadyToDestroy);
            }
            else
            {
                Assert.AreEqual(9f, otherE.health.Value);
                Assert.False(otherE.isReadyToDestroy);
            }
            
            Assert.True(collisionE.isReadyToDestroy);
        }
    }
}