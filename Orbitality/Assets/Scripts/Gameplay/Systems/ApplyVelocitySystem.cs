using System.Linq;
using Entitas;

namespace Gameplay.Systems
{
    public class ApplyVelocitySystem : IExecuteSystem
    {
        private readonly Contexts _contexts;
        
        public ApplyVelocitySystem(Contexts contexts)
        {
            _contexts = contexts;
        }
        
        public void Execute()
        {
            var entities = _contexts.gameplay
                .GetEntities(GameplayMatcher.Velocity)
                .Where(entity => entity.hasPosition);
            
            foreach (var entity in entities)
            {
                entity.ReplacePosition(
                    entity.position.X + entity.velocity.X,
                    entity.position.Y + entity.velocity.Y,
                    entity.position.Z + entity.velocity.Z);
            }
        }
    }
}