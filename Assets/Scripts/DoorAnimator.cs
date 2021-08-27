using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    public ParticleSystem doorParticle;
    void Start()
    {
        
    }

    public void PlayParticle()
    {
        doorParticle.Play();
    }

    public void StopParticle()
    {
        doorParticle.Stop();
    }
}
