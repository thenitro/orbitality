using System.Collections.Generic;
using Entitas;
using Gameplay;

namespace Gameflow.Systems
{
    public class CreatePlanetsSystem : ReactiveSystem<GameflowEntity>
    {
        private readonly Contexts _contexts;
        
        public CreatePlanetsSystem(Contexts contexts) : base(contexts.gameflow)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameflowEntity> GetTrigger(IContext<GameflowEntity> context)
        {
            return context.CreateCollector(GameflowMatcher.CreatePlanets);
        }

        protected override bool Filter(GameflowEntity entity)
        {
            return _contexts.gameflow.isCreatePlanets &&
                   _contexts.gameSettings.hasPlanetsAmount;
        }

        protected override void Execute(List<GameflowEntity> entities)
        {
            _contexts.gameflow.isCreatePlanets = false;
            _contexts.gameplay.CreateEntity().ReplaceGameObjectType(GameObjectType.Sun);

            var planetsAmount = _contexts.gameSettings.planetsAmount.Value;

            for (int i = 0; i < planetsAmount; i++)
            {
                _contexts.gameplay.CreateEntity().ReplaceGameObjectType(GameObjectType.Planet);
            }
        }
    }
}