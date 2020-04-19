using Gameplay;
using Gameplay.Systems;
using NUnit.Framework;

namespace Tests.Editor.Gameplay
{
    public class TestOnPlanetCreatedSystem : AbstractTest
    {
        [Test]
        public void SmokeTest()
        {
            var mass = 0.1f;
            var minDistanceFromSun = 1;
            var distanceBetweenPlanets = 10;
            var minVelocityY = 10f;
            var maxVelocityY = 100f;
            var minRotationSpeed = 10f;
            var maxRotationSpeed = 100f;
            var health = 10f;
            
            var system = new OnPlanetCreatedSystem(C);

            C.gameSettings.ReplacePlanetsPhysics(
                mass,
                minDistanceFromSun,
                distanceBetweenPlanets,
                minVelocityY,
                maxVelocityY,
                minRotationSpeed,
                maxRotationSpeed,
                health);
            
            var sunE = C.gameplay.CreateEntity();
                sunE.ReplaceGameObjectType(GameObjectType.Sun);
                sunE.ReplacePosition(0, 0, 0);

            var planetE = C.gameplay.CreateEntity();
                planetE.ReplaceGameObjectType(GameObjectType.Planet);
            
            Assert.False(planetE.hasPosition);
            Assert.False(planetE.hasRotationSpeed);
            Assert.False(planetE.hasMass);
            Assert.False(planetE.hasVelocity);
            Assert.False(planetE.isPlayer);
            Assert.False(planetE.hasHealth);
                
            system.Execute();
            
            Assert.True(planetE.hasPosition);
            Assert.GreaterOrEqual(planetE.position.X, minDistanceFromSun);
            Assert.AreEqual(sunE.position.Y, planetE.position.Y);
            Assert.AreEqual(sunE.position.Z, planetE.position.Z);

            Assert.True(planetE.hasRotationSpeed);
            Assert.LessOrEqual(planetE.rotationSpeed.Value, maxRotationSpeed);
            Assert.GreaterOrEqual(planetE.rotationSpeed.Value, minRotationSpeed);
            
            Assert.True(planetE.hasMass);
            Assert.AreEqual(mass, planetE.mass.Value);
            
            Assert.True(planetE.hasVelocity);
            Assert.AreEqual(0, planetE.velocity.X);
            Assert.LessOrEqual(planetE.velocity.Y, maxVelocityY);
            Assert.GreaterOrEqual(planetE.velocity.Y, minVelocityY);
            Assert.AreEqual(0, planetE.velocity.Z);
            
            Assert.True(planetE.isPlayer);
            
            Assert.True(planetE.hasHealth);
            Assert.AreEqual(health, planetE.health.Value);
        }
        
        [Test]
        public void NotPlanet([Values] GameObjectType type)
        {
            if (type == GameObjectType.Planet)
            {
                return;
            }
            
            var system = new OnPlanetCreatedSystem(C);

            //C.gameflow.ReplaceGameSettings(0, 0, 0, 0, 0, 0, 0);
            
            var sunE = C.gameplay.CreateEntity();
                sunE.ReplaceGameObjectType(GameObjectType.Sun);
                sunE.ReplacePosition(0, 0, 0);

            var planetE = C.gameplay.CreateEntity();
                planetE.ReplaceGameObjectType(type);
            
            Assert.False(planetE.hasPosition);
            Assert.False(planetE.hasRotationSpeed);
            Assert.False(planetE.hasMass);
            Assert.False(planetE.hasVelocity);
            Assert.False(planetE.isPlayer);
            Assert.False(planetE.hasHealth);
                
            system.Execute();
            
            Assert.False(planetE.hasPosition);
            Assert.False(planetE.hasRotationSpeed);
            Assert.False(planetE.hasMass);
            Assert.False(planetE.hasVelocity);
            Assert.False(planetE.isPlayer);
            Assert.False(planetE.hasHealth);
        }
    }
}