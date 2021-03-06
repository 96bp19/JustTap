﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float smashSpeed =20f;

    [SerializeField] private float camOffset = 0;

    [SerializeField] private Slider healthbar;

    private float minyPos = 0, maxypos;

    private float originalYPos;
    private Camera cam;
    private IEnumerator moveTowardsRoutine = null;

    private bool gameOver = false;

    [SerializeField] private float maxHealth =5f;
    private float currentHealth;
    
    private void Start()
    {
        cam = Camera.main;
        originalYPos = transform.position.y;
        MyMath.GetRelativeCamToWorldPos(Camera.main, out cameraToScreenInfo caminfo);
        minyPos = caminfo.minY;
        maxypos = caminfo.maxY;
        currentHealth = maxHealth;
    }
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        if (Input.GetMouseButtonDown(0))
        {
            Tap(0);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Tap(1);
        }
        UpdatehealthSlider();
        OnGameOver();
    }

    private void LateUpdate()
    {  
        cam.transform.position = cam.transform.position.with(x: (transform.position.x+camOffset));
    }

    void Tap(int val)
    {
        Smash(val);
    }

    IEnumerator moveTowards(float moveYloc)
    {
        while (transform.position.y.Distance(moveYloc) >0)
        {
            float moveloc = Mathf.MoveTowards(transform.position.y, moveYloc, Time.deltaTime * smashSpeed);
            transform.position = transform.position.with(y: moveloc);
            yield return null;
        }
        moveTowardsRoutine = null;
        if (moveYloc != originalYPos)
        {
            BounceBack();
        }
    }

    void BounceBack()
    {
        if (moveTowardsRoutine != null)
        {
            StopCoroutine(moveTowardsRoutine);
            moveTowardsRoutine = null;
            
        }
        if (moveTowardsRoutine  == null)
        {
            moveTowardsRoutine = moveTowards(originalYPos);
            StartCoroutine(moveTowardsRoutine);

        }
    }

    void Smash(int val)
    {
        if (moveTowardsRoutine == null)
        {
            if (val == 0)
            {
                moveTowardsRoutine = moveTowards(minyPos);

            }
            else
            {

                moveTowardsRoutine = moveTowards(maxypos);
            }
            StartCoroutine(moveTowardsRoutine);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("triggered");
        if (collision.CompareTag("Pickables"))
        {
            BounceBack();
            currentHealth = maxHealth;
            if (collision.GetComponentInChildren<Renderer>().sharedMaterial == GetComponentInChildren<Renderer>().sharedMaterial)
            {
                collision.gameObject.SetActive(false);

            }
        }
    }

    void UpdatehealthSlider()
    {
        if (healthbar == null)
        {
            return;
        }
        currentHealth -= Time.deltaTime;
        healthbar.value = currentHealth / maxHealth;
     
    }

    public void SetGameOver(bool val)
    {
        gameOver = val;
    }

    void OnGameOver()
    {
        if (gameOver == false)
        {
            return;
        }
        if (moveTowardsRoutine != null)
        {
            StopCoroutine(moveTowardsRoutine);
            moveTowardsRoutine = null;

        }
        moveSpeed = 0;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }


}

public static class ExtensionClass
{
    public static float Distance(this float originalVal, float other)
    {  
        return Mathf.Abs(originalVal - other);
    }

}