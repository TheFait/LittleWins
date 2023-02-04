using UnityEngine;

public class DestroyOnParticleSystemComplete : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (!_particleSystem.IsAlive())
        {
            if(transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
    }
}
