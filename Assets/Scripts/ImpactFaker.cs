using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactFaker : MonoBehaviour
{
    public static ImpactFaker ImpactFakerInstance
    {
        get
        {
            if (_ImpactFaker == null)
            {
                _ImpactFaker = FindObjectOfType<ImpactFaker>();
            }
            return _ImpactFaker;
        }
    }
    private static ImpactFaker _ImpactFaker;
  
    
    public void SimulateFakeImpact(float impactStartinSec, float impactDuration, int impactCount)
    {
       
        ImpactFakerInstance.StopAllCoroutines();
        ImpactFakerInstance.StartCoroutine(SimulateImpact(impactStartinSec, impactDuration, impactCount));
       
    }


  
    private float _timeAtCurrentFrame;
    private float _timeAtLastFrame;
    private float _fakeDelta;

   
    void Update()
    {
        // Calculate a fake delta time, so we can Shake while game is paused.
        _timeAtCurrentFrame = Time.realtimeSinceStartup;
        _fakeDelta = _timeAtCurrentFrame - _timeAtLastFrame;
        _timeAtLastFrame = _timeAtCurrentFrame;
    }

    

    public IEnumerator SimulateImpact(float startduration, float impactDelay , int impactCount)
    {

        Debug.Log("fake impact");
        float currentdelay = impactDelay;
        float secondDelay = impactDelay;
        while (impactCount>0)
        {
            currentdelay = impactDelay;
            secondDelay = impactDelay;
            while (currentdelay>0)
            {
                Time.timeScale = Mathf.Lerp(Time.timeScale, 0, (impactDelay / (impactDelay - currentdelay)));
                currentdelay -= _fakeDelta;
                yield return null;
            }
           while(secondDelay >0)
            {
                Time.timeScale = Mathf.Lerp(Time.timeScale, 0, (impactDelay / (impactDelay - secondDelay)));
                secondDelay -= _fakeDelta;
                yield return null;
            }
            impactCount--;
            yield return null;
        }

        Time.timeScale = 1;
    }

}



    

