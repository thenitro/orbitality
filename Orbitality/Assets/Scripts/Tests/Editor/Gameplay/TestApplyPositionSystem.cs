using Gameplay.Systems;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Editor.Gameplay
{
    public class TestApplyPositionSystem : AbstractTest
    {
        [Test]
        public void SmokeTest()
        {
            var system = new ApplyPositionSystem(C);

            var go = new GameObject();

            var x = 1;
            var y = 2;
            var z = 3;

            var entity = C.gameplay.CreateEntity();
                entity.ReplaceView(go);
                entity.ReplacePosition(x, y, z);
            
            system.Execute();
            
            Assert.AreEqual(x, go.transform.position.x);
            Assert.AreEqual(y, go.transform.position.y);
            Assert.AreEqual(z, go.transform.position.z);
        }
        
        [Test]
        public void NoView()
        {
            var system = new ApplyPositionSystem(C);

            var go = new GameObject();

            var x = 1;
            var y = 2;
            var z = 3;

            var entity = C.gameplay.CreateEntity();
                entity.ReplacePosition(x, y, z);
            
            system.Execute();
            
            Assert.AreNotEqual(x, go.transform.position.x);
            Assert.AreNotEqual(y, go.transform.position.y);
            Assert.AreNotEqual(z, go.transform.position.z);
        }
    }
}