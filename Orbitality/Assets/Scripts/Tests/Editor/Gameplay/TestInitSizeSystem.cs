using Gameplay.Systems;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Editor.Gameplay
{
    public class TestInitSizeSystem : AbstractTest
    {
        [Test]
        public void SmokeTest()
        {
            var system = new InitSizeSystem(C);

            var entity = C.gameplay.CreateEntity();
                entity.ReplaceView(new GameObject());
            
            system.Execute();
            
            Assert.True(entity.hasSize);
            Assert.AreEqual(1, entity.size.X);
            Assert.AreEqual(1, entity.size.Y);
            Assert.AreEqual(1, entity.size.Z);
        }
        
        [Test]
        public void AlreadyHasSize()
        {
            var system = new InitSizeSystem(C);

            var entity = C.gameplay.CreateEntity();
                entity.ReplaceView(new GameObject());
                entity.ReplaceSize(1, 2, 3);
            
            system.Execute();
            
            Assert.True(entity.hasSize);
            Assert.AreEqual(1, entity.size.X);
            Assert.AreEqual(2, entity.size.Y);
            Assert.AreEqual(3, entity.size.Z);
        }
    }
}