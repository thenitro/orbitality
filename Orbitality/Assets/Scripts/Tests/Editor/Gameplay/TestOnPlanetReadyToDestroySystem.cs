using Entitas;
using Gameplay;
using Gameplay.Systems;
using NUnit.Framework;

namespace Tests.Editor.Gameplay
{
    public class TestOnPlanetReadyToDestroySystem : AbstractTest
    {
        [Test]
        public void SmokeTest()
        {
            var system = new OnPlanetReadyToDestroySystem(C);

            var playersPlanet = C.gameplay.CreateEntity();
                playersPlanet.ReplaceGameObjectType(GameObjectType.Planet);
                playersPlanet.isPlayer = true;

            var notPlayerPlanet1 = C.gameplay.CreateEntity();
                notPlayerPlanet1.ReplaceGameObjectType(GameObjectType.Planet);
                notPlayerPlanet1.isReadyToDestroy = true;
                
            var notPlayerPlanet2 = C.gameplay.CreateEntity();
                notPlayerPlanet2.ReplaceGameObjectType(GameObjectType.Planet);
                notPlayerPlanet2.isReadyToDestroy = true;
            
            Assert.False(C.gameflow.hasGameOver);
                
            system.Execute();
            
            Assert.True(C.gameflow.hasGameOver);
            Assert.True(C.gameflow.gameOver.PlayerWon);
            
            Assert.AreEqual(3, C.gameplay.GetEntities(GameplayMatcher.ReadyToDestroy).Length);
        }
        
        [Test]
        public void AlreadyHasGameOver()
        {
            var system = new OnPlanetReadyToDestroySystem(C);

            var playersPlanet = C.gameplay.CreateEntity();
                playersPlanet.ReplaceGameObjectType(GameObjectType.Planet);
                playersPlanet.isPlayer = true;
                playersPlanet.isReadyToDestroy = true;

            var notPlayerPlanet1 = C.gameplay.CreateEntity();
                notPlayerPlanet1.ReplaceGameObjectType(GameObjectType.Planet);
                notPlayerPlanet1.isReadyToDestroy = true;
                
            var notPlayerPlanet2 = C.gameplay.CreateEntity();
                notPlayerPlanet2.ReplaceGameObjectType(GameObjectType.Planet);
                notPlayerPlanet2.isReadyToDestroy = true;
            
            C.gameflow.ReplaceGameOver(true);
                
            Assert.True(C.gameflow.hasGameOver);
                
            system.Execute();
            
            Assert.True(C.gameflow.hasGameOver);
            Assert.True(C.gameflow.gameOver.PlayerWon);
            
            Assert.AreEqual(3, C.gameplay.GetEntities(GameplayMatcher.ReadyToDestroy).Length);
        }
        
        [Test]
        public void OnlyOnePlanetDestroyed()
        {
            var system = new OnPlanetReadyToDestroySystem(C);

            var playersPlanet = C.gameplay.CreateEntity();
                playersPlanet.ReplaceGameObjectType(GameObjectType.Planet);
                playersPlanet.isPlayer = true;

            var notPlayerPlanet1 = C.gameplay.CreateEntity();
                notPlayerPlanet1.ReplaceGameObjectType(GameObjectType.Planet);
                notPlayerPlanet1.isReadyToDestroy = true;
                
            var notPlayerPlanet2 = C.gameplay.CreateEntity();
                notPlayerPlanet2.ReplaceGameObjectType(GameObjectType.Planet);
            
            Assert.False(C.gameflow.hasGameOver);
                
            system.Execute();
            
            Assert.False(C.gameflow.hasGameOver);
            Assert.AreEqual(1, C.gameplay.GetEntities(GameplayMatcher.ReadyToDestroy).Length);
        }
        
        [Test]
        public void PlayerIsDead()
        {
            var system = new OnPlanetReadyToDestroySystem(C);

            var playersPlanet = C.gameplay.CreateEntity();
                playersPlanet.ReplaceGameObjectType(GameObjectType.Planet);
                playersPlanet.isPlayer = true;
                playersPlanet.isReadyToDestroy = true;

            var notPlayerPlanet = C.gameplay.CreateEntity();
                notPlayerPlanet.ReplaceGameObjectType(GameObjectType.Planet);
                
            var notPlayerPlanet2 = C.gameplay.CreateEntity();
                notPlayerPlanet2.ReplaceGameObjectType(GameObjectType.Planet);
            
            Assert.False(C.gameflow.hasGameOver);
                
            system.Execute();
            
            Assert.True(C.gameflow.hasGameOver);
            Assert.False(C.gameflow.gameOver.PlayerWon);
            
            Assert.AreEqual(3, C.gameplay.GetEntities(GameplayMatcher.ReadyToDestroy).Length);
        }
    }
}