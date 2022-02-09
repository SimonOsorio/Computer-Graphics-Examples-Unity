using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ShieldVFX : MonoBehaviour
{
    [SerializeField] float radius = 4;
    [SerializeField] float duration = 4;
    [SerializeField] float speed = 1;

    ParticleSystem particleSystem;

    void Awake() { particleSystem = GetComponent<ParticleSystem>(); }

    public void StartShield()
    {
        //RadioActual * X = RadioDeseado
        //X = RadioDeseado / RadioActual
        transform.localScale = Vector3.one * (radius / 4);
        //DuracionDeseada * velocidad = lifetime 
        //velocidad = lifetime / DuracionDeseada 
        ParticleSystem.MainModule main = particleSystem.main;
        main.simulationSpeed = main.startLifetime.constantMax / (duration / speed);

        particleSystem.Play(withChildren: true);
    }
}
