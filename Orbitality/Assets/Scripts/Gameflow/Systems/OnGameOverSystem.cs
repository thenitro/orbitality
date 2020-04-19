using System.Collections.Generic;
using Entitas;
using Gameflow.Enums;

namespace Gameflow.Systems
{
    public class OnGameOverSystem : ReactiveSystem<GameflowEntity>
    {
        private readonly Contexts _contexts;
        
        public OnGameOverSystem(Contexts contexts) : base(contexts.gameflow)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameflowEntity> GetTrigger(IContext<GameflowEntity> context)
        {
            return context.CreateCollector(GameflowMatcher.GameOver);
        }

        protected override bool Filter(GameflowEntity entity)
        {
            return entity.hasGameOver;
        }

        protected override void Execute(List<GameflowEntity> entities)
        {
            _contexts.gameflow.ReplaceState(GameState.GameOver);
        }
    }
}