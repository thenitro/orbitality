using Entitas;
using Entitas.Unity;
using Gameplay.Systems;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Editor.Gameplay
{
    public class TestDestroySystem : AbstractTest
    {
        [Test]
        public void SmokeTest()
        {
            var system = new DestroySystem(C);

            var go = new GameObject();
            
            var entityToDestroy = C.gameplay.CreateEntity();
                entityToDestroy.ReplaceView(go);
                entityToDestroy.isReadyToDestroy = true;

            go.Link(entityToDestroy);
            
            system.Execute();
            
            Assert.Zero(C.gameplay.GetEntities(GameplayMatcher.View).Length);
            Assert.Zero(C.gameplay.GetEntities(GameplayMatcher.ReadyToDestroy).Length);
        }
    }
}