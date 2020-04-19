using Entitas;
using Gameflow.Enums;

namespace Gameflow.Systems
{
    public class InitGameSystem : IInitializeSystem
    {
        private readonly Contexts _contexts;
        
        public InitGameSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            _contexts.gameflow.ReplaceState(GameState.MainMenu);
        }
    }
}