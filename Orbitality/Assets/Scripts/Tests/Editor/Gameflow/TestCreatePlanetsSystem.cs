using System.Linq;
using Entitas;
using Gameflow.Systems;
using Gameplay;
using NUnit.Framework;

namespace Tests.Editor.Gameflow
{
    public class TestCreatePlanetsSystem : AbstractTest
    {
        [Test]
        public void SmokeTest()
        {
            var planetsAmount = 9;
            
            var system = new CreatePlanetsSystem(C);
            
            C.gameSettings.ReplacePlanetsAmount(planetsAmount);
            C.gameflow.isCreatePlanets = true;

            system.Execute();
            
            Assert.False(C.gameflow.isCreatePlanets);
            
            var gameObjects = C.gameplay.GetEntities(GameplayMatcher.GameObjectType);
            Assert.AreEqual(planetsAmount + 1, gameObjects.Length);

            var sun = gameObjects.FirstOrDefault(planet => planet.gameObjectType.Value == GameObjectType.Sun);
            Assert.NotNull(sun);

            var planets = gameObjects.Where(planet => planet.gameObjectType.Value == GameObjectType.Planet);
            Assert.AreEqual(planetsAmount, planets.Count());
        }
        
        [Test]
        public void NoSettingsTest()
        {
            var system = new CreatePlanetsSystem(C);
            
            C.gameflow.isCreatePlanets = true;
            
            system.Execute();
            
            Assert.True(C.gameflow.isCreatePlanets);

            var gameObjects = C.gameplay.GetEntities(GameplayMatcher.GameObjectType);
            Assert.AreEqual(0, gameObjects.Length);
        }
    }
}