using System.Collections.Generic;
using Entitas;

namespace Gameflow.Systems
{
    public class ZoomCameraSystem : ReactiveSystem<GameflowEntity>
    {
        private readonly Contexts _contexts;
        
        public ZoomCameraSystem(Contexts contexts) : base(contexts.gameflow)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameflowEntity> GetTrigger(IContext<GameflowEntity> context)
        {
            return context.CreateCollector(GameflowMatcher.CameraZoom);
        }

        protected override bool Filter(GameflowEntity entity)
        {
            return entity.hasCameraZoom &&
                   _contexts.gameflow.hasGameplayCamera;
        }

        protected override void Execute(List<GameflowEntity> entities)
        {
            foreach (var zoomEntity in entities)
            {
                var position = _contexts.gameflow.gameplayCamera.Value.transform.position;
                    position.z += zoomEntity.cameraZoom.Value * 100;

                _contexts.gameflow.gameplayCamera.Value.transform.position = position;
                
                zoomEntity.Destroy();
            }
        }
    }
}
