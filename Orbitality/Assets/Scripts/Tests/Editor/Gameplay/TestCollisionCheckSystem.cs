using System.Linq;
using Entitas;
using Gameplay.Systems;
using NUnit.Framework;

namespace Tests.Editor.Gameplay
{
    public class TestCollisionCheckSystem : AbstractTest
    {
        [Test]
        public void SmokeTest()
        {
            var system = new CollisionCheckSystem(C);

            var entityA = C.gameplay.CreateEntity();
                entityA.ReplacePosition(0, 0, 0);
                entityA.ReplaceSize(4, 4, 4);
                
            var entityB = C.gameplay.CreateEntity();
                entityB.ReplacePosition(1, 1, 1);
                entityB.ReplaceSize(2, 2, 2);
            
            system.Execute();

            var collisionEs = C.gameplay.GetEntities(GameplayMatcher.Collision);
            Assert.AreEqual(1, collisionEs.Length);

            var collision = collisionEs.FirstOrDefault();
            Assert.AreEqual(entityA, collision.collision.entityA);
            Assert.AreEqual(entityB, collision.collision.entityB);
        }
        
        [Test]
        public void NotEnoughValidEntities()
        {
            var system = new CollisionCheckSystem(C);

            var entityA = C.gameplay.CreateEntity();
                entityA.ReplacePosition(0, 0, 0);
                entityA.ReplaceSize(4, 4, 4);
                
            var entityB = C.gameplay.CreateEntity();
                entityB.ReplacePosition(1, 1, 1);
            
            system.Execute();

            var collisionEs = C.gameplay.GetEntities(GameplayMatcher.Collision);
            Assert.AreEqual(0, collisionEs.Length);
        }
    }
}