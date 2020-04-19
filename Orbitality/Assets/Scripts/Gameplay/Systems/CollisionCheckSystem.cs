using System.Linq;
using Entitas;

namespace Gameplay.Systems
{
    public class CollisionCheckSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;
        
        public CollisionCheckSystem(Contexts contexts)
        {
            _contexts = contexts;
        }
        
        public void Execute()
        {
            var entities = _contexts.gameplay
                .GetEntities()
                .Where(entity => entity.hasPosition && entity.hasSize).ToArray();

            if (entities.Length < 2)
            {
                return;
            }

            for (var i = 0; i < entities.Length; i++)
            {
                var entityA = entities[i];
                
                for (var j = i + 1; j < entities.Length; j++)
                {
                    var entityB = entities[j];

                    var dx = entityB.position.X - entityA.position.X;
                    var dy = entityB.position.Y - entityA.position.Y;
                    var dz = entityB.position.Z - entityA.position.Z;

                    var distanceSquared = dx * dx + dy * dy + dz * dz;
                    
                    var sizeSquaredAX = (entityA.size.X * entityA.size.X) / 2;
                    var sizeSquaredAY = (entityA.size.Y * entityA.size.Y) / 2;
                    var sizeSquaredAZ = (entityA.size.Z * entityA.size.Z) / 2;
                    
                    var sizeSquaredBX = (entityB.size.X * entityB.size.X) / 2;
                    var sizeSquaredBY = (entityB.size.Y * entityB.size.Y) / 2;
                    var sizeSquaredBZ = (entityB.size.Z * entityB.size.Z) / 2;

                    if (sizeSquaredAX + sizeSquaredBX > distanceSquared ||
                        sizeSquaredAY + sizeSquaredBY > distanceSquared ||
                        sizeSquaredAZ + sizeSquaredBZ > distanceSquared)
                    {
                        _contexts.gameplay.CreateEntity().ReplaceCollision(entityA, entityB);
                    }
                }
            }
        }
    }
}