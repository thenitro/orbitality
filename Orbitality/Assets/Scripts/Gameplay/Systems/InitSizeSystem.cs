using System.Collections.Generic;
using Entitas;

namespace Gameplay.Systems
{
    public class InitSizeSystem : ReactiveSystem<GameplayEntity>
    {
        public InitSizeSystem(Contexts contexts) : base(contexts.gameplay)
        {
        }

        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(GameplayMatcher.View);
        }

        protected override bool Filter(GameplayEntity entity)
        {
            return entity.hasView &&
                   !entity.hasSize;
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            foreach (var gameplayEntity in entities)
            {
                var scale = gameplayEntity.view.View.transform.localScale;
                
                gameplayEntity.ReplaceSize(scale.x, scale.y, scale.z);
            }
        }
    }
}