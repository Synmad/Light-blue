using UnityEngine;

public class PlayerParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem landingParticle;
    [SerializeField] ParticleSystem deathParticle;

    void OnEnable()
    {
        NewerColliding.onLanded += PlayLanding;
        Health.onPlayerDeath += PlayDeath;
    }

    void PlayLanding()
    {
        landingParticle?.Play();
    }
    void PlayDeath()
    {
        deathParticle?.Play();
    }

    void OnDisable()
    {
        NewerColliding.onLanded -= PlayLanding;
        Health.onPlayerDeath -= PlayDeath;
    }
}
