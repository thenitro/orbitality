using System.Collections.Generic;
using Entitas;
using Gameflow.Enums;
using UnityEngine;

namespace Gameplay.Systems
{
    public class OnGameplayStateSystem : ReactiveSystem<GameflowEntity>
    {
        private readonly Contexts _contexts;
        
        public OnGameplayStateSystem(Contexts contexts):base(contexts.gameflow)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameflowEntity> GetTrigger(IContext<GameflowEntity> context)
        {
            return context.CreateCollector(GameflowMatcher.State);
        }

        protected override bool Filter(GameflowEntity entity)
        {
            return _contexts.gameflow.hasState &&
                   _contexts.gameflow.state.Value == GameState.Gameplay;
        }

        protected override void Execute(List<GameflowEntity> entities)
        {
            if (_contexts.gameflow.hasGameOver)
            {
                _contexts.gameflow.RemoveGameOver();
            }
            
            _contexts.gameflow.isCreatePlanets = true;
        }
    }
}