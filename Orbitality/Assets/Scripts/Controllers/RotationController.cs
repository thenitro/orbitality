using UnityEngine;

public class RotationController : MonoBehaviour
{
    public float RotationSpeedX = 0f;
    public float RotationSpeedY = 0f;
    public float RotationSpeedZ = 0f;
    
    private void Update()
    {
        transform.Rotate(RotationSpeedX, RotationSpeedY, RotationSpeedZ);
    }
}