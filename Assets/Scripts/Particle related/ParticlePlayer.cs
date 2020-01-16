using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    [SerializeField] private GameObject particleprefab;

    public void PlayParticle( Material matToUse)
    {
        GameObject particle =  Instantiate(particleprefab) as GameObject;
        particle.GetComponent<ParticleSystem>().GetComponent<Renderer>().sharedMaterial = matToUse;
        particle.transform.position = transform.position;
    }
}
