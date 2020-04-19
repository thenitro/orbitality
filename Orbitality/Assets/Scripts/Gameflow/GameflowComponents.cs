using Controllers;
using Gameflow.Enums;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Managers;
using UnityEngine;

[Gameflow, Unique]
public class StateComponent : IComponent
{
    public GameState Value;
}

[Gameflow, Unique]
public class GameSceneManagerComponent : IComponent
{
    public ICurrentSceneManager Value;
}

[Gameflow, Unique]
public class GameAssetsComponent : IComponent
{
    public IGameAssets Value;
}

[Gameflow, Unique]
public class CreatePlanetsComponent : IComponent
{
}

[Gameflow, Unique]
public class GameplayCameraComponent : IComponent
{
    public Camera Value;
}

[Gameflow]
public class CameraZoomComponent : IComponent
{
    public float Value;
}

[Gameflow, Unique]
public class GameOverComponent : IComponent
{
    public bool PlayerWon;
}