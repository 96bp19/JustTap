using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    int count = 0;
    

    private void OnDisable()
    {
        CameraShaker.Shake(0.1f, 1f);
        ImpactFaker.ImpactFakerInstance.SimulateFakeImpact(0, 0.03f, 1);
        GetComponentInChildren<ParticlePlayer>().PlayParticle(GetComponent<Renderer>().sharedMaterial);
        Debug.Log("destoyed count : " + count);
    }
}
