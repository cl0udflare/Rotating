using UnityEngine;

public class GrateLine : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    public void PlayParticles()
    {
        _particleSystem.Play();
    }
}
