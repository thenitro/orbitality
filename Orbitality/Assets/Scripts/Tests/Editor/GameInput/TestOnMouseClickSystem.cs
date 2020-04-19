using System.Linq;
using Entitas;
using Gameflow.Enums;
using GameInput.Systems;
using Gameplay;
using NUnit.Framework;

namespace Tests.Editor.GameInput
{
    public class TestOnMouseClickSystem : AbstractTest
    {
        [Test]
        public void SmokeTest()
        {
            var system = new OnMouseClickSystem(C);

            C.gameInput.CreateEntity().isMouseClick = true;
            C.gameflow.ReplaceState(GameState.Gameplay);
            
            system.Execute();
            
            Assert.Zero(C.gameInput.GetEntities(GameInputMatcher.MouseClick).Length);

            var rocketEs = C.gameplay
                .GetEntities(GameplayMatcher.GameObjectType)
                .Where(entity => entity.gameObjectType.Value == GameObjectType.Rocket);
            Assert.AreEqual(1, rocketEs.Count());
        }
        
        [Test]
        public void WrongState([Values] GameState state)
        {
            if (state == GameState.Gameplay)
            {
                return;
            }
            
            var system = new OnMouseClickSystem(C);

            C.gameInput.CreateEntity().isMouseClick = true;
            C.gameflow.ReplaceState(state);
            
            system.Execute();
            
            Assert.Zero(C.gameInput.GetEntities(GameInputMatcher.MouseClick).Length);

            var rocketEs = C.gameplay
                .GetEntities(GameplayMatcher.GameObjectType)
                .Where(entity => entity.gameObjectType.Value == GameObjectType.Rocket);
            Assert.Zero(rocketEs.Count());
        }
        
        [Test]
        public void NoState()
        {   
            var system = new OnMouseClickSystem(C);

            C.gameInput.CreateEntity().isMouseClick = true;
            
            system.Execute();
            
            Assert.AreEqual(1, C.gameInput.GetEntities(GameInputMatcher.MouseClick).Length);

            var rocketEs = C.gameplay
                .GetEntities(GameplayMatcher.GameObjectType)
                .Where(entity => entity.gameObjectType.Value == GameObjectType.Rocket);
            Assert.Zero(rocketEs.Count());
        }
    }
}