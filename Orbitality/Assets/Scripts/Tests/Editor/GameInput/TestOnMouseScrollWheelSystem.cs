using System.Linq;
using Entitas;
using Gameflow.Enums;
using GameInput.Systems;
using NUnit.Framework;

namespace Tests.Editor.GameInput
{
    public class TestOnMouseScrollWheelSystem : AbstractTest
    {
        [Test]
        public void SmokeTest()
        {
            var scrollValue = 0.1f;
            
            var system = new OnMouseScrollWheelSystem(C);
            
            C.gameInput.CreateEntity().ReplaceMouseScrollWheel(scrollValue);
            C.gameflow.ReplaceState(GameState.Gameplay);
            
            system.Execute();
            
            Assert.Zero(C.gameInput.GetEntities(GameInputMatcher.MouseScrollWheel).Length);

            var cameraZoomEs = C.gameflow.GetEntities(GameflowMatcher.CameraZoom);
            Assert.AreEqual(1, cameraZoomEs.Length);

            var cameraZoomE = cameraZoomEs.FirstOrDefault();
            Assert.AreEqual(scrollValue, cameraZoomE.cameraZoom.Value);
        }
        
        [Test]
        public void WrongState([Values] GameState state)
        {
            if (state == GameState.Gameplay)
            {
                return;
            }
            
            var scrollValue = 0.1f;
            
            var system = new OnMouseScrollWheelSystem(C);
            
            C.gameInput.CreateEntity().ReplaceMouseScrollWheel(scrollValue);
            C.gameflow.ReplaceState(state);
            
            system.Execute();
            
            Assert.Zero(C.gameInput.GetEntities(GameInputMatcher.MouseScrollWheel).Length);
            Assert.Zero(C.gameflow.GetEntities(GameflowMatcher.CameraZoom).Length);
        }
        
        [Test]
        public void NoState()
        {
            var scrollValue = 0.1f;
            
            var system = new OnMouseScrollWheelSystem(C);
            
            C.gameInput.CreateEntity().ReplaceMouseScrollWheel(scrollValue);
            
            system.Execute();
            
            Assert.AreEqual(1, C.gameInput.GetEntities(GameInputMatcher.MouseScrollWheel).Length);
            Assert.Zero(C.gameflow.GetEntities(GameflowMatcher.CameraZoom).Length);
        }
    }
}