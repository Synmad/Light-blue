using UnityEngine;
using Cinemachine;

public class CameraShakeController : MonoBehaviour
{
    [SerializeField] CinemachineImpulseSource playerImpulseSource;
    [SerializeField] float dashShakeForce;
    [SerializeField] float deathShakeForce;

    void Awake()
    {
        Dashing.onDash += DashShake;
        Health.onPlayerDeath += DeathShake; 
    }

    void DashShake()
    {
        playerImpulseSource.GenerateImpulseWithForce(dashShakeForce);
    }

    void DeathShake()
    {
        playerImpulseSource.GenerateImpulseWithForce(deathShakeForce);
    }
}
