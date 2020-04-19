using UnityEngine;

namespace Controllers
{
    public class GameSettingsController : MonoBehaviour
    {
        [Header("Planets settings")]
        [SerializeField] private int PlanetsAmount = 9;
        
        [SerializeField] private float PlanetMass = 0.001f;

        [SerializeField] private float MinDistanceFromSun = 2f;
        [SerializeField] private float DistanceBetweenPlanets = 100f;
        
        [SerializeField] private float MinVelocityY = 0.14f;
        [SerializeField] private float MaxVelocityY = 0.28f;

        [SerializeField] private float MinRotationSpeed = 0.01f;
        [SerializeField] private float MaxRotationSpeed = 0.1f;

        [SerializeField] private float Health = 10f;

        [Header("Sun settings")]
        [SerializeField] private float SunMass = 100f;
        
        [Header("Rocket settings")]
        [SerializeField] private float RocketMass = 0.000000001f;

        [SerializeField] private float Damage = 1f;
        
        private void Awake()
        {
            var settings = Contexts.sharedInstance.gameSettings;
                settings.ReplacePlanetsAmount(PlanetsAmount);
                settings.ReplacePlanetsPhysics(
                    PlanetMass,
                    MinDistanceFromSun,
                    DistanceBetweenPlanets,
                    MinVelocityY,
                    MaxVelocityY,
                    MinRotationSpeed, 
                    MaxRotationSpeed,
                    Health);
                settings.ReplaceSunPhysics(SunMass);
                settings.ReplaceRocketPhysics(
                    RocketMass,
                    Damage);
        }
    }
}