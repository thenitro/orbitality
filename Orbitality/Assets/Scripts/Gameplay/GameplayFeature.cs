using Gameplay.Systems;

namespace Gameplay
{
    public class GameplayFeature : Feature
    {
        public GameplayFeature(Contexts contexts) : base("Gameplay feature")
        {
            Add(new CreateViewSystem(contexts));
            Add(new InitSizeSystem(contexts));
            
            Add(new ApplyVelocitySystem(contexts));
            Add(new CollisionCheckSystem(contexts));
            Add(new OnRocketCollisionSystem(contexts));
            Add(new OnHealthChangeSystem(contexts));
            Add(new ApplyGravitationSystem(contexts));
            
            Add(new ApplyPositionSystem(contexts));
            Add(new ApplyRotationSpeedSystem(contexts));
            
            Add(new OnSunCreatedSystem(contexts));
            Add(new OnPlanetCreatedSystem(contexts));
            Add(new OnRocketCreatedSystem(contexts));
            
            Add(new OnPlanetReadyToDestroySystem(contexts));
            Add(new DestroySystem(contexts));
        }
    }
}