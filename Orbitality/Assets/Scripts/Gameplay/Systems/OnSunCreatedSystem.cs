using System.Collections.Generic;
using Entitas;

namespace Gameplay.Systems
{
    public class OnSunCreatedSystem : ReactiveSystem<GameplayEntity>
    {
        private readonly Contexts _contexts;
        
        public OnSunCreatedSystem(Contexts contexts) : base(contexts.gameplay)
        {
            _contexts = contexts;
        }
        
        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(GameplayMatcher.GameObjectType);
        }

        protected override bool Filter(GameplayEntity entity)
        {
            return entity.hasGameObjectType &&
                   entity.gameObjectType.Value == GameObjectType.Sun &&
                   _contexts.gameSettings.hasSunPhysics;
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            foreach (var sunEntity in entities)
            {
                sunEntity.ReplacePosition(0f, 0f, 0f);
                sunEntity.ReplaceVelocity(0f, 0f, 0f);
                sunEntity.ReplaceMass(_contexts.gameSettings.sunPhysics.Mass);
            }
        }
    }
}