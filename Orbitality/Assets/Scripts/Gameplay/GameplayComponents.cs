using Entitas;
using Gameplay;
using UnityEngine;

[Gameplay]
public class GameObjectTypeComponent : IComponent
{
    public GameObjectType Value;
}

[Gameplay]
public class ViewComponent : IComponent
{
    public GameObject View;
}

[Gameplay]
public class PositionComponent : IComponent
{
    public float X;
    public float Y;
    public float Z;
}

[Gameplay]
public class VelocityComponent : IComponent
{
    public float X;
    public float Y;
    public float Z;
}

[Gameplay]
public class MassComponent : IComponent
{
    public float Value;
}

[Gameplay]
public class RotationSpeedComponent : IComponent
{
    public float Value;
}

[Gameplay]
public class PlayerComponent : IComponent
{
}

[Gameplay]
public class SizeComponent : IComponent
{
    public float X;
    public float Y;
    public float Z;
}

[Gameplay]
public class CollisionComponent : IComponent
{
    public GameplayEntity entityA;
    public GameplayEntity entityB;
}

[Gameplay]
public class ReadyToDestroyComponent : IComponent
{
}

[Gameplay]
public class DamageToDealComponent : IComponent
{
    public float Value;
}

[Gameplay]
public class HealthComponent : IComponent
{
    public float Value;
}