using Entitas;
using Managers;

namespace Gameflow.Systems
{
    public class InitSceneManagerSystem : IInitializeSystem
    {
        private readonly Contexts _contexts;

        public InitSceneManagerSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            _contexts.gameflow.ReplaceGameSceneManager(new CurrentSceneManager());
        }
    }
}