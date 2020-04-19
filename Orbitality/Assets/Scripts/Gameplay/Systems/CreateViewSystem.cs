using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Gameplay.Systems
{
    public class CreateViewSystem : ReactiveSystem<GameplayEntity>
    {
        private readonly Contexts _contexts;
        
        public CreateViewSystem(Contexts contexts) : base(contexts.gameplay)
        {
            _contexts = contexts;
        }
        
        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(GameplayMatcher.GameObjectType);
        }

        protected override bool Filter(GameplayEntity entity)
        {
            return entity.hasGameObjectType &&
                   !entity.hasView &&
                   _contexts.gameflow.hasGameAssets;
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            var assets = _contexts.gameflow.gameAssets.Value;
            
            foreach (var gameplayEntity in entities)
            {
                var prefab = assets.GetPrefabByGameObjectType(gameplayEntity.gameObjectType.Value);
                if (prefab == null)
                {
                    gameplayEntity.Destroy();
                    continue;
                }

                var go = Object.Instantiate(prefab);
                    go.Link(gameplayEntity);
                    
                gameplayEntity.ReplaceView(go);
            }
        }
    }
}