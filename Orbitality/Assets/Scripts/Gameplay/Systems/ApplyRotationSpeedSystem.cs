using System.Collections.Generic;
using Entitas;

namespace Gameplay.Systems
{
    public class ApplyRotationSpeedSystem : ReactiveSystem<GameplayEntity>
    {
        public ApplyRotationSpeedSystem(Contexts contexts) : base(contexts.gameplay)
        {
        }

        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(GameplayMatcher.RotationSpeed);
        }

        protected override bool Filter(GameplayEntity entity)
        {
            return entity.hasRotationSpeed &&
                   entity.hasView;
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            foreach (var gameplayEntity in entities)
            {
                var go = gameplayEntity.view.View;
                var rotationController = go.GetComponent<RotationController>();
                    rotationController.RotationSpeedY = gameplayEntity.rotationSpeed.Value;
            }
        }
    }
}