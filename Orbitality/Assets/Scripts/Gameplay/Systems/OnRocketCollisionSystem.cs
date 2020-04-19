using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using Entitas;
using UnityEngine;

namespace Gameplay.Systems
{
    public class OnRocketCollisionSystem : ReactiveSystem<GameplayEntity>
    {
        public OnRocketCollisionSystem(Contexts contexts) : base(contexts.gameplay)
        {
        }
        
        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(GameplayMatcher.Collision);
        }

        protected override bool Filter(GameplayEntity entity)
        {
            return entity.hasCollision;
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            foreach (var collisionE in entities)
            {
                var entityA = collisionE.collision.entityA;
                var entityB = collisionE.collision.entityB;

                if (IsRocket(entityA) && IsRocket(entityB))
                {
                    entityA.isReadyToDestroy = true;
                    entityB.isReadyToDestroy = true;
                }
                else
                {
                    DealDamage(entityA, entityB);
                }
                
                collisionE.isReadyToDestroy = true;
            }
        }

        private void DealDamage(GameplayEntity entityA, GameplayEntity entityB)
        {
            var rocketE = IsRocket(entityA) ? entityA : entityB;
            var notRocketE = IsRocket(entityA) ? entityB : entityA;
            
            if (notRocketE.hasHealth && rocketE.hasDamageToDeal)
            {
                notRocketE.ReplaceHealth(notRocketE.health.Value - rocketE.damageToDeal.Value);
            }
            
            rocketE.isReadyToDestroy = true;
        }

        private bool IsRocket(GameplayEntity entity)
        {
            return entity.hasGameObjectType &&
                   entity.gameObjectType.Value == GameObjectType.Rocket;
        }
    }
}