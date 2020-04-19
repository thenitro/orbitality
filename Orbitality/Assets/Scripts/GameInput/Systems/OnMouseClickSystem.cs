using System.Collections.Generic;
using Entitas;
using Gameflow.Enums;
using Gameplay;

namespace GameInput.Systems
{
    public class OnMouseClickSystem : ReactiveSystem<GameInputEntity>
    {
        private readonly Contexts _contexts;
        
        public OnMouseClickSystem(Contexts contexts) : base(contexts.gameInput)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameInputEntity> GetTrigger(IContext<GameInputEntity> context)
        {
            return context.CreateCollector(GameInputMatcher.MouseClick);
        }

        protected override bool Filter(GameInputEntity entity)
        {
            return entity.isMouseClick &&
                   _contexts.gameflow.hasState;
        }

        protected override void Execute(List<GameInputEntity> entities)
        {
            foreach (var inputEntity in entities)
            {
                if (_contexts.gameflow.state.Value == GameState.Gameplay)
                {
                    var rocketE = _contexts.gameplay.CreateEntity();
                        rocketE.ReplaceGameObjectType(GameObjectType.Rocket);
                }
                
                inputEntity.Destroy();
            }
        }
    }
}