using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Entitas;
using UnityEngine;

namespace Gameplay.Systems
{
    public class OnPlanetCreatedSystem : ReactiveSystem<GameplayEntity>
    {
        private readonly Contexts _contexts;
        
        public OnPlanetCreatedSystem(Contexts contexts) : base(contexts.gameplay)
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
                   entity.gameObjectType.Value == GameObjectType.Planet &&
                   _contexts.gameSettings.hasPlanetsPhysics;
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            var minDistanceFromSun = _contexts.gameSettings.planetsPhysics.MinDistanceFromSun;
            var maxVelocityY = _contexts.gameSettings.planetsPhysics.MaxVelocityY;
            var minVelocityY = _contexts.gameSettings.planetsPhysics.MinVelocityY;
            
            var sunEntity = _contexts.gameplay
                .GetEntities(GameplayMatcher.GameObjectType)
                .FirstOrDefault(sunE => sunE.gameObjectType.Value == GameObjectType.Sun);

            if (sunEntity == null || !sunEntity.hasPosition)
            {
                Debug.LogWarning("OnPlanetCreateSystem.Execute: no sun or no sun position!");
                return;
            }

            var sunPositionX = sunEntity.position.X;
            var sunPositionY = sunEntity.position.Y;
            var sunPositionZ = sunEntity.position.Z;

            var minRotationSpeed = _contexts.gameSettings.planetsPhysics.MinRotationSpeed;
            var maxRotationSpeed = _contexts.gameSettings.planetsPhysics.MaxRotationSpeed;

            var maxDistanceFromSun = entities.Count * _contexts.gameSettings.planetsPhysics.DistanceBetweenPlanets;
            var planetsCounter = 0;
            var playerCreated = false;
            
            foreach (var planetEntity in entities)
            {
                var positionX = sunPositionX + minDistanceFromSun + planetsCounter * 100;// + Random.Range(minDistanceFromSun, maxDistanceFromSun);
                var positionY = sunPositionY;
                var positionZ = sunPositionZ;

                var dx = sunPositionX - positionX;
                var dy = sunPositionY - positionY;
                var dz = sunPositionZ - positionZ;

                var distanceSquared = dx * dx + dy * dy + dz * dz;
                
                var distancePercent = Mathf.Sqrt(distanceSquared) / maxDistanceFromSun;

                var rotationSpeed = Mathf.Lerp(minRotationSpeed, maxRotationSpeed, 1 - distancePercent);
                var velocityY = Mathf.Lerp(minVelocityY, maxVelocityY, 1f - distancePercent);
                
                planetEntity.ReplaceRotationSpeed(rotationSpeed);
                planetEntity.ReplacePosition(positionX, positionY, positionZ);
                planetEntity.ReplaceMass(_contexts.gameSettings.planetsPhysics.Mass);
                planetEntity.ReplaceVelocity(0, velocityY, 0);
                planetEntity.ReplaceHealth(_contexts.gameSettings.planetsPhysics.Health);

                if (!playerCreated && Random.Range(0f, 1f) > 0.7f)
                {
                    planetEntity.isPlayer = true;
                    playerCreated = true;
                }

                planetsCounter++;
            }

            if (!playerCreated)
            {
                entities.Last().isPlayer = true;
            }
        }
    }
}