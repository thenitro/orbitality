using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Gameplay.Systems
{
    public class ApplyPositionSystem : ReactiveSystem<GameplayEntity>
    {
        private readonly Contexts _contexts;
        
        public ApplyPositionSystem(Contexts contexts) : base(contexts.gameplay)
        {
        }

        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(GameplayMatcher.Position);
        }

        protected override bool Filter(GameplayEntity entity)
        {
            return entity.hasView &&
                   entity.hasPosition;
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            foreach (var gameplayEntity in entities)
            {
                gameplayEntity.view.View.transform.position = 
                    new Vector3(
                        gameplayEntity.position.X,
                        gameplayEntity.position.Y,
                        gameplayEntity.position.Z);
            }
        }
    }
}