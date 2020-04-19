using GameInput.Systems;

namespace GameInput
{
    public class GameInputFeature : Feature
    {
        public GameInputFeature(Contexts contexts):base("Game Input Feature")
        {
            Add(new OnMouseScrollWheelSystem(contexts));
            Add(new OnMouseClickSystem(contexts));
            
            Add(new OnPlayButtonClickSystem(contexts));
        }
    }
}