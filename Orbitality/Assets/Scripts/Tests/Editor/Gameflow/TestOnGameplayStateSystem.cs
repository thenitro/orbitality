using Gameflow.Enums;
using Gameplay.Systems;
using NUnit.Framework;

namespace Tests.Editor.Gameflow
{
    public class TestOnGameplayStateSystem : AbstractTest
    {
        [Test]
        public void SmokeTest()
        {
            var system = new OnGameplayStateSystem(C);
            
            C.gameflow.ReplaceState(GameState.Gameplay);
            Assert.False(C.gameflow.isCreatePlanets);
            
            system.Execute();
            
            Assert.True(C.gameflow.isCreatePlanets);
        }
        
        [Test]
        public void DestroyGameOver()
        {
            var system = new OnGameplayStateSystem(C);
            
            C.gameflow.ReplaceGameOver(true);
            C.gameflow.ReplaceState(GameState.Gameplay);
            Assert.False(C.gameflow.isCreatePlanets);
            
            system.Execute();
            
            Assert.False(C.gameflow.hasGameOver);
            Assert.True(C.gameflow.isCreatePlanets);
        }
        
        [Test]
        public void WrongState([Values] GameState state)
        {
            if (state == GameState.Gameplay)
            {
                return;
            }
            
            var system = new OnGameplayStateSystem(C);
            
            C.gameflow.ReplaceState(state);
            Assert.False(C.gameflow.isCreatePlanets);
            
            system.Execute();
            
            Assert.False(C.gameflow.isCreatePlanets);
        }
    }
}