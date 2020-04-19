using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameSettings, Unique]
public class PlanetsAmountComponent : IComponent
{
    public int Value;
}

[GameSettings, Unique]
public class PlanetsPhysicsComponent : IComponent
{
    public float Mass;
    public float MinDistanceFromSun;
    public float DistanceBetweenPlanets;
    public float MinVelocityY;
    public float MaxVelocityY;
    public float MinRotationSpeed;
    public float MaxRotationSpeed;
    public float Health;
}

[GameSettings, Unique]
public class SunPhysicsComponent : IComponent
{
    public float Mass;
}

[GameSettings, Unique]
public class RocketPhysicsComponent : IComponent
{
    public float Mass;
    public float Damage;
}