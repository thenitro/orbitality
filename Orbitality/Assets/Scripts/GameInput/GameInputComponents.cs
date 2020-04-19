using Entitas;
using Entitas.CodeGeneration.Attributes;
using GameInput;
using UnityEngine;

[GameInput]
public class ButtonClickComponent : IComponent
{
    public InputButtons ButtonName;
}

[GameInput]
public class MouseScrollWheelComponent : IComponent
{
    public float Value;
}

[GameInput]
public class MouseClickComponent : IComponent
{
}

[GameInput, Unique]
public class MousePositionComponent : IComponent
{
    public Vector3 Value;
}