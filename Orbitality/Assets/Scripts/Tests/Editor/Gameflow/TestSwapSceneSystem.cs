using Gameflow.Enums;
using Gameflow.Systems;
using NUnit.Framework;
using Tests.Editor.Mocks;

namespace Tests.Editor.Gameflow
{
    public class TestSwapSceneSystem : AbstractTest
    {
        [Test]
        [TestCase(GameState.Gameplay, SceneName.Gameplay)]
        [TestCase(GameState.MainMenu, SceneName.MainMenu)]
        public void SmokeTest(GameState currentState, string currentScene)
        {
            var sceneManager = new MockedSceneManager();
            var system = new SwapSceneSystem(C);
            
            C.gameflow.ReplaceGameSceneManager(sceneManager);
            C.gameflow.ReplaceState(currentState);
            
            system.Execute();
            
            Assert.AreEqual(currentScene, sceneManager.CurrentSceneName);
        }
        
        [Test]
        [TestCase(GameState.Gameplay, SceneName.Gameplay)]
        [TestCase(GameState.MainMenu, SceneName.MainMenu)]
        public void NoGameSceneManager(GameState currentState, string currentScene)
        {
            var system = new SwapSceneSystem(C);
            
            C.gameflow.ReplaceState(currentState);
            
            system.Execute();
        }

        [Test]
        [TestCase(true, SceneName.YouWon)]
        [TestCase(false, SceneName.YouLose)]
        public void TestGameOver(bool playerWon, string currentScene)
        {
            var sceneManager = new MockedSceneManager();
            var system = new SwapSceneSystem(C);
            
            C.gameflow.ReplaceGameSceneManager(sceneManager);
            C.gameflow.ReplaceState(GameState.GameOver);
            C.gameflow.ReplaceGameOver(playerWon);
            
            system.Execute();
            
            Assert.AreEqual(currentScene, sceneManager.CurrentSceneName);
        }
    }
}