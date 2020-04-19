using System.Collections.Generic;
using Entitas;
using Gameflow.Enums;

namespace GameInput.Systems
{
    public class OnPlayButtonClickSystem : ReactiveSystem<GameInputEntity>
    {
        private readonly Contexts _contexts;
        
        public OnPlayButtonClickSystem(Contexts contexts): base(contexts.gameInput)
        {
            _contexts = contexts;
        }
        
        protected override ICollector<GameInputEntity> GetTrigger(IContext<GameInputEntity> context)
        {
            return context.CreateCollector(GameInputMatcher.ButtonClick);
        }

        protected override bool Filter(GameInputEntity entity)
        {
            return entity.hasButtonClick &&
                   entity.buttonClick.ButtonName == InputButtons.Play;
        }

        protected override void Execute(List<GameInputEntity> entities)
        {
            foreach (var inputEntity in entities)
            {
                inputEntity.Destroy();
            }
            
            _contexts.gameflow.ReplaceState(GameState.Gameplay);
        }
    }
}