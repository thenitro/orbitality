using Gameplay;
using Gameplay.Systems;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Editor.Gameplay
{
    public class TestOnRocketCreatedSystem : AbstractTest
    {
        [Test]
        public void SmokeTest()
        {
            var mass = 1f;
            var damage = 1f;
            
            var system = new OnRocketCreatedSystem(C);

            var rocketE = C.gameplay.CreateEntity();
                rocketE.ReplaceGameObjectType(GameObjectType.Rocket);

            var sunE = C.gameplay.CreateEntity();
                sunE.ReplaceGameObjectType(GameObjectType.Sun);
                sunE.ReplacePosition(0f, 0f, 0f);
                
            var playerPlanetE = C.gameplay.CreateEntity();
                playerPlanetE.ReplaceGameObjectType(GameObjectType.Planet);
                playerPlanetE.isPlayer = true;
                playerPlanetE.ReplacePosition(1f, 1f, 1f);
                playerPlanetE.ReplaceSize(1f, 1f, 1f);

            var go = new GameObject();
            var camera = go.AddComponent<Camera>();
            
            C.gameflow.ReplaceGameplayCamera(camera);
            C.gameInput.ReplaceMousePosition(new Vector3(10, 10, 10));
            C.gameSettings.ReplaceRocketPhysics(mass, damage);
            
            system.Execute();
            
            Assert.True(rocketE.hasMass);
            Assert.AreEqual(mass, rocketE.mass.Value);
            
            Assert.True(rocketE.hasDamageToDeal);
            Assert.AreEqual(damage, rocketE.damageToDeal.Value);
        }
    }
}