using System.Collections.Generic;
using System.Linq;
using Entitas;

namespace Gameplay.Systems
{
    public class OnPlanetReadyToDestroySystem : ReactiveSystem<GameplayEntity>
    {
        private readonly Contexts _contexts;
        
        public OnPlanetReadyToDestroySystem(Contexts contexts) : base(contexts.gameplay)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(GameplayMatcher.ReadyToDestroy);
        }

        protected override bool Filter(GameplayEntity entity)
        {
            return entity.hasGameObjectType &&
                   entity.gameObjectType.Value == GameObjectType.Planet &&
                   !_contexts.gameflow.hasGameOver;
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            var planetsAlive = 
                _contexts.gameplay
                    .GetEntities(GameplayMatcher.GameObjectType)
                    .Where(entity => 
                        entity.gameObjectType.Value == GameObjectType.Planet &&
                        !entity.isReadyToDestroy);

            var isPlayerAlive = planetsAlive.Any(entity => entity.isPlayer);
            if (isPlayerAlive)
            {
                if (planetsAlive.Count() == 1)
                {
                    DestroyAllEntities();
                    
                    _contexts.gameflow.ReplaceGameOver(true);
                }
            }
            else
            {
                DestroyAllEntities();
                
                _contexts.gameflow.ReplaceGameOver(false);
            }
        }

        private void DestroyAllEntities()
        {
            foreach (var gameplayEntity in _contexts.gameplay.GetEntities())
            {
                gameplayEntity.isReadyToDestroy = true;
            }
        }
    }
}