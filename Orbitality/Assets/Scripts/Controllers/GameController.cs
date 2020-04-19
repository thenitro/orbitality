using Entitas;
using Gameflow;
using GameInput;
using Gameplay;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Systems _systems;
    
    private void Start()
    {
        var contexts = Contexts.sharedInstance;
        
        _systems = new Systems();

        _systems
            .Add(new GameflowFeature(contexts))
            .Add(new GameInputFeature(contexts))
            .Add(new GameplayFeature(contexts));
        
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
}
