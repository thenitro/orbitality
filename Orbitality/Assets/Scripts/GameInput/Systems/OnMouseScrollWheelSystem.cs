using System.Collections.Generic;
using Entitas;
using Gameflow.Enums;

namespace GameInput.Systems
{
    public class OnMouseScrollWheelSystem : ReactiveSystem<GameInputEntity>
    {
        private readonly Contexts _contexts;
        
        public OnMouseScrollWheelSystem(Contexts contexts) : base(contexts.gameInput)
        {
            _contexts = contexts;
        }
        
        protected override ICollector<GameInputEntity> GetTrigger(IContext<GameInputEntity> context)
        {
            return context.CreateCollector(GameInputMatcher.MouseScrollWheel);
        }

        protected override bool Filter(GameInputEntity entity)
        {
            return entity.hasMouseScrollWheel &&
                   _contexts.gameflow.hasState;
        }

        protected override void Execute(List<GameInputEntity> entities)
        {
            foreach (var gameInputEntity in entities)
            {
                if (_contexts.gameflow.state.Value == GameState.Gameplay)
                {
                    _contexts.gameflow.CreateEntity().ReplaceCameraZoom(gameInputEntity.mouseScrollWheel.Value);
                }
                
                gameInputEntity.Destroy();
            }
        }
    }
}