using Gameflow.Systems;
using Gameplay.Systems;

namespace Gameflow
{
    public class GameflowFeature : Feature
    {
        public GameflowFeature(Contexts contexts) : base("Gameflow feature")
        {
            Add(new CreatePlanetsSystem(contexts));
            
            Add(new InitSceneManagerSystem(contexts));
            Add(new InitGameSystem(contexts));
            Add(new SwapSceneSystem(contexts));
            
            Add(new OnGameplayStateSystem(contexts));

            Add(new ZoomCameraSystem(contexts));

            Add(new OnGameOverSystem(contexts));
        }
    }
}