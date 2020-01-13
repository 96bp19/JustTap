using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float smashSpeed =20f;
    float originalYPos;
    float minyPos = 0;

    Camera cam;
    [SerializeField] private float camOffset = 0;

    private void Start()
    {
        cam = Camera.main;
        originalYPos = transform.position.y;
        MyMath.GetRelativeCamToWorldPos(Camera.main, out cameraToScreenInfo caminfo);
        minyPos = caminfo.minY;
    }
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        if (Input.GetMouseButtonDown(0))
        {
            Tap();
        }
    }

    private void LateUpdate()
    {
        
        cam.transform.position = cam.transform.position.with(x: (transform.position.x+camOffset));
    }

    IEnumerator moveTowardsRoutine = null;
    void Tap()
    {
        if (moveTowardsRoutine == null)
        {
            moveTowardsRoutine = moveTowards(minyPos);
            StartCoroutine(moveTowardsRoutine);
        }
    }

    IEnumerator moveTowards(float moveYloc)
    {
        while (transform.position.y.Distance(moveYloc) >0)
        {
            float moveloc = Mathf.MoveTowards(transform.position.y, moveYloc, Time.deltaTime * smashSpeed);
            transform.position = transform.position.with(y: moveloc);
            yield return null;
        }

        while (transform.position.y.Distance(originalYPos) >0)
        {
            float moveloc = Mathf.MoveTowards(transform.position.y, originalYPos, Time.deltaTime * smashSpeed);
            transform.position = transform.position.with(y: moveloc);
            Debug.Log("second move");
            yield return null;
        }

        moveTowardsRoutine = null;
    }

    
}

public static class ExtensionClass
{
    public static float Distance(this float originalVal, float other)
    {
        
        return Mathf.Abs(originalVal - other);
    }

}