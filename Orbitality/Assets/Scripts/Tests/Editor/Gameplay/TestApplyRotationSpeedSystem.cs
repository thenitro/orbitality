using Gameplay.Systems;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Editor.Gameplay
{
    public class TestApplyRotationSpeedSystem : AbstractTest
    {
        [Test]
        public void SmokeTest()
        {
            var system = new ApplyRotationSpeedSystem(C);

            var rotationSpeed = 10f;
            
            var go = new GameObject();
            var rotationController = go.AddComponent<RotationController>();

            var entity = C.gameplay.CreateEntity();
                entity.ReplaceView(go);
                entity.ReplaceRotationSpeed(rotationSpeed);
            
            system.Execute();
            
            Assert.AreEqual(rotationSpeed, rotationController.RotationSpeedY);
        }
        
        [Test]
        public void NoView()
        {
            var system = new ApplyRotationSpeedSystem(C);

            var rotationSpeed = 10f;
            
            var go = new GameObject();
            var rotationController = go.AddComponent<RotationController>();

            var entity = C.gameplay.CreateEntity();
                entity.ReplaceRotationSpeed(rotationSpeed);
            
            system.Execute();
            
            Assert.AreNotEqual(rotationSpeed, rotationController.RotationSpeedY);
        }
    }
}