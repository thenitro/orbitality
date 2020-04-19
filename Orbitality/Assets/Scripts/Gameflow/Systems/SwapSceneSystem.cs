using System.Collections.Generic;
using Controllers;
using Entitas;
using Gameflow.Enums;
using UnityEngine.SceneManagement;

namespace Gameflow.Systems
{
    public class SwapSceneSystem : ReactiveSystem<GameflowEntity>
    {
        private readonly Contexts _contexts;
        
        public SwapSceneSystem(Contexts contexts) : base(contexts.gameflow)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameflowEntity> GetTrigger(IContext<GameflowEntity> context)
        {
            return context.CreateCollector(GameflowMatcher.State);
        }

        protected override bool Filter(GameflowEntity entity)
        {
            return entity.hasState &&
                   _contexts.gameflow.hasGameSceneManager;
        }

        protected override void Execute(List<GameflowEntity> entities)
        {
            if (_contexts.gameflow.state.Value == GameState.MainMenu)
            {
                _contexts.gameflow.gameSceneManager.Value.LoadScene(
                    SceneName.MainMenu, 
                    LoadSceneMode.Single);
            } 
            else if (_contexts.gameflow.state.Value == GameState.Gameplay)
            {
                _contexts.gameflow.gameSceneManager.Value.LoadScene(
                    SceneName.Gameplay, 
                    LoadSceneMode.Single);
            }
            else if (_contexts.gameflow.state.Value == GameState.GameOver)
            {
                if (!_contexts.gameflow.hasGameOver)
                {
                    return;
                }

                var sceneName = _contexts.gameflow.gameOver.PlayerWon 
                    ? SceneName.YouWon 
                    : SceneName.YouLose;

                _contexts.gameflow.gameSceneManager.Value.LoadScene(
                    sceneName, 
                    LoadSceneMode.Single);
            }
        }
    }
}