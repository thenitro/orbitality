using System.Linq;
using Entitas;
using UnityEngine;

namespace Gameplay.Systems
{
    public class ApplyGravitationSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;
        private bool _prewarmed;
        
        public ApplyGravitationSystem(Contexts contexts)
        {
            _contexts = contexts;
        }
        
        public void Execute()
        {
            var entities = _contexts.gameplay
                .GetEntities(GameplayMatcher.Velocity)
                .Where(
                    entity => 
                        entity.hasPosition && 
                        entity.hasMass &&
                        entity.hasVelocity)
                .ToArray();

            var entitiesAmount = entities.Length;
            if (entitiesAmount < 2)
            {
                return;
            }
            
            for (var i = 0; i < entitiesAmount; i++)
            {
                var entityA = entities[i];
                
                for (var j = i + 1; j < entitiesAmount; j++)
                {
                    var entityB = entities[j];
                    
                    var dx = entityB.position.X - entityA.position.X;
                    var dy = entityB.position.Y - entityA.position.Y;
                    var dz = entityB.position.Z - entityA.position.Z;

                    var distanceSquared = dx * dx + dy * dy + dz * dz;
                    var distance = Mathf.Sqrt(distanceSquared);
                    
                    var force = entityA.mass.Value * entityB.mass.Value / distanceSquared;
                    
                    var accelerationX = force * dx / distance;
                    var accelerationY = force * dy / distance;
                    var accelerationZ = force * dz / distance;
                    
                    entityA.ReplaceVelocity(
                        entityA.velocity.X + accelerationX / entityA.mass.Value,
                        entityA.velocity.Y + accelerationY / entityA.mass.Value,
                        entityA.velocity.Z + accelerationZ / entityA.mass.Value);
                    
                    entityB.ReplaceVelocity(
                        entityB.velocity.X - accelerationX / entityB.mass.Value,
                        entityB.velocity.Y - accelerationY / entityB.mass.Value,
                        entityB.velocity.Z - accelerationZ / entityB.mass.Value);
                }
            }
        }
    }
}