using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

namespace Gameplay.Systems
{
    public class OnRocketCreatedSystem : ReactiveSystem<GameplayEntity>
    {
        private readonly Contexts _contexts;
        
        public OnRocketCreatedSystem(Contexts contexts) : base(contexts.gameplay)
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
                   entity.gameObjectType.Value == GameObjectType.Rocket &&
                   _contexts.gameflow.hasGameplayCamera &&
                   _contexts.gameInput.hasMousePosition &&
                   _contexts.gameSettings.hasRocketPhysics;
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            var sunE = _contexts.gameplay
                .GetEntities(GameplayMatcher.GameObjectType)
                .FirstOrDefault(
                    entity => 
                        entity.gameObjectType.Value == GameObjectType.Sun && 
                        entity.hasPosition);
            if (sunE == null)
            {
                Debug.LogWarning("OnRocketCreatedSystem.Execute: no sun!");
                return;
            }

            var playerE = _contexts.gameplay
                .GetEntities(GameplayMatcher.Player)
                .FirstOrDefault(
                    entity => 
                        entity.hasPosition && 
                        entity.hasSize);
            if (playerE == null)
            {
                Debug.LogWarning("OnRocketCreatedSystem.Execute: no player!");
                return;
            }
            
            foreach (var rocketE in entities)
            {
                var camera = _contexts.gameflow.gameplayCamera.Value;
                    
                var screenPosition = _contexts.gameInput.mousePosition.Value;
                    screenPosition.z = camera.transform.position.z * -1;
                        
                var directionPosition = camera.ScreenToWorldPoint(screenPosition);
                    directionPosition.z = sunE.position.Z;

                var dx = directionPosition.x - playerE.position.X;
                var dy = directionPosition.y - playerE.position.Y;
                    
                var direction = Mathf.Atan2(dy, dx);

                var newPositionX = playerE.position.X + Mathf.Cos(direction) * playerE.size.X;
                var newPositionY = playerE.position.Y + Mathf.Sin(direction) * playerE.size.Y;
                    
                var newVelocityX = Mathf.Cos(direction);
                var newVelocityY = Mathf.Sin(direction); 
                
                rocketE.ReplacePosition(newPositionX, newPositionY, playerE.position.Z);
                rocketE.ReplaceVelocity(newVelocityX, newVelocityY, 0);
                rocketE.ReplaceMass(_contexts.gameSettings.rocketPhysics.Mass);
                rocketE.ReplaceDamageToDeal(_contexts.gameSettings.rocketPhysics.Damage);
            }
        }
    }
}