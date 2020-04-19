using System.Collections.Generic;
using Entitas;

namespace Gameplay.Systems
{
    public class OnHealthChangeSystem : ReactiveSystem<GameplayEntity>
    {
        private readonly Contexts _contexts;
        
        public OnHealthChangeSystem(Contexts contexts) : base(contexts.gameplay)
        {
        }

        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(GameplayMatcher.Health);
        }

        protected override bool Filter(GameplayEntity entity)
        {
            return entity.hasHealth;
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            foreach (var gameplayEntity in entities)
            {
                if (gameplayEntity.health.Value <= 0)
                {
                    gameplayEntity.isReadyToDestroy = true;
                }
            }
        }
    }
}