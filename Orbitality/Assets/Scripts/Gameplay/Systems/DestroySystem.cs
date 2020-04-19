using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Gameplay.Systems
{
    public class DestroySystem : ReactiveSystem<GameplayEntity>
    {
        public DestroySystem(Contexts contexts) : base(contexts.gameplay)
        {
        }

        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(GameplayMatcher.ReadyToDestroy);
        }

        protected override bool Filter(GameplayEntity entity)
        {
            return entity.isReadyToDestroy;
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            foreach (var gameplayEntity in entities)
            {
                if (gameplayEntity.hasView)
                {
                    var go = gameplayEntity.view.View;
                        go.Unlink();

                    if (Application.isEditor)
                    {
                        Object.DestroyImmediate(go);
                    }
                    else
                    {
                        Object.Destroy(go);
                    }
                    
                }
                
                gameplayEntity.Destroy();
            }
        }
    }
}