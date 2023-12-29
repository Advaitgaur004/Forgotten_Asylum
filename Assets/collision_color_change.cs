using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_color_change : MonoBehaviour
{
    public GameObject magicSpell;
    public GameObject Dragon;
    public float radius = 1f;
    private bool isSparkEnabled = false;
    public ParticleSystem sparkParticleSystem;

    private void Start()
    {
        sparkParticleSystem = magicSpell.GetComponent<ParticleSystem>();
        sparkParticleSystem.Stop(); // Initially disable spark particle system
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Dragon.transform.position);
        if (distance <= radius && !isSparkEnabled)
        {
            // Enable spark particle system
            isSparkEnabled = true;
            sparkParticleSystem.Play();
        }
        else if (distance > radius && isSparkEnabled)
        {
            // Disable spark particle system
            isSparkEnabled = false;
            sparkParticleSystem.Stop();
        }
    }
}
