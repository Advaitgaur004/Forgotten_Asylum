using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class major_circle : MonoBehaviour
{
    public GameObject circleSpell;
    public ParticleSystem sparkParticleSystem;
    public GameObject magicspell1;
    public GameObject magicspell2;
    public GameObject magicspell3;
    public GameObject magicspell4;
    public GameObject magicspell5;
    public ParticleSystem magicspell1ParticleSystem;
    public ParticleSystem magicspell2ParticleSystem;
    public ParticleSystem magicspell3ParticleSystem;
    public ParticleSystem magicspell4ParticleSystem;
    public ParticleSystem magicspell5ParticleSystem;

    private void Start()
    {
        sparkParticleSystem = circleSpell.GetComponent<ParticleSystem>();
        sparkParticleSystem.Stop();
        magicspell1ParticleSystem = magicspell1.GetComponent<ParticleSystem>();
        magicspell2ParticleSystem = magicspell2.GetComponent<ParticleSystem>();
        magicspell3ParticleSystem = magicspell3.GetComponent<ParticleSystem>();
        magicspell4ParticleSystem = magicspell4.GetComponent<ParticleSystem>();
        magicspell5ParticleSystem = magicspell5.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (magicspell1ParticleSystem.isPlaying && magicspell2ParticleSystem.isPlaying && magicspell3ParticleSystem.isPlaying && magicspell4ParticleSystem.isPlaying && magicspell5ParticleSystem.isPlaying)
        {
            sparkParticleSystem.Play();
        }
    }
}
