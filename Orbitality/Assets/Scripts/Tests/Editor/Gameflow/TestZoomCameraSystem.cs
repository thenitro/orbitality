using Gameflow.Systems;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Editor.Gameflow
{
    public class TestZoomCameraSystem : AbstractTest
    {
        [Test]
        public void SmokeTest()
        {
            var cameraZoom = 0.1f;
            
            var system = new ZoomCameraSystem(C);
            
            var go = new GameObject();
            var camera = go.AddComponent<Camera>();
            
            C.gameflow.CreateEntity().ReplaceCameraZoom(cameraZoom);
            C.gameflow.ReplaceGameplayCamera(camera);
            
            system.Execute();
            
            Assert.AreEqual(0, camera.transform.position.x);
            Assert.AreEqual(0, camera.transform.position.y);
            Assert.AreEqual(cameraZoom * 100, camera.transform.position.z);
        }
    }
}