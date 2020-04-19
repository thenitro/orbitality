using Entitas;
using Gameflow.Enums;
using GameInput;
using GameInput.Systems;
using NUnit.Framework;

namespace Tests.Editor.GameInput
{
    public class TestOnPlayButtonClickSystem : AbstractTest
    {
        [Test]
        public void SmokeTest()
        {
            var system = new OnPlayButtonClickSystem(C);
            
            C.gameInput.CreateEntity().ReplaceButtonClick(InputButtons.Play);
            C.gameInput.CreateEntity().ReplaceButtonClick(InputButtons.Play);
            C.gameInput.CreateEntity().ReplaceButtonClick(InputButtons.Play);
            C.gameInput.CreateEntity().ReplaceButtonClick(InputButtons.Play);
            
            Assert.False(C.gameflow.hasState);
            
            system.Execute();
            
            Assert.True(C.gameflow.hasState);
            Assert.AreEqual(GameState.Gameplay, C.gameflow.state.Value);
            
            Assert.AreEqual(0, C.gameInput.GetEntities(GameInputMatcher.ButtonClick).Length);            
        }
        
        [Test]
        public void WrongButton([Values] InputButtons inputButton)
        {
            if (inputButton == InputButtons.Play)
            {
                return;
            }
            
            var system = new OnPlayButtonClickSystem(C);
            
            C.gameInput.CreateEntity().ReplaceButtonClick(inputButton);
            
            Assert.False(C.gameflow.hasState);
            
            system.Execute();
            
            Assert.False(C.gameflow.hasState);
            Assert.AreEqual(1, C.gameInput.GetEntities(GameInputMatcher.ButtonClick).Length);            
        }
    }
}