using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiController : Singleton<ConfettiController>
{

    [SerializeField] private ParticleSystem[] WinParticleSystems;
    [SerializeField] private ParticleSystem[] FailParticleSystems;
    
    public void ShowConfetti()
    {
        for (int i = 0; i < WinParticleSystems.Length; i++)
        {
            WinParticleSystems[i].Play();
        }
    }
    
    public void ShowLoseConfetti()
    {
        for (int i = 0; i < FailParticleSystems.Length; i++)
        {
            FailParticleSystems[i].Play();
        }
    }
    
}
