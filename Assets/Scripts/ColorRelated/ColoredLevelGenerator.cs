using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredLevelGenerator : MonoBehaviour
{
    public ColorGenerator colorGenerator;

    public GameObject player;
    public GameObject pickablePrefab;
    List<GameObject> objectsToChangemat = new List<GameObject>();
    public int noTogenerate;

    cameraToScreenInfo caminfo;
    private void Start()
    {
        MyMath.GetRelativeCamToWorldPos(Camera.main, out caminfo);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Generate();
        }
    }

    void RemoveOldObjects()
    {
        foreach (var item in objectsToChangemat)
        {
                Destroy(item);
        }
        objectsToChangemat.Clear();
    }

    void Generate()
    {
        RemoveOldObjects();
        Transform spawnedobj;

       
        for (int i = 0; i < noTogenerate; i++)
        {
            spawnedobj = Instantiate(pickablePrefab).transform;
            spawnedobj.SetParent(transform);
            float ypos = MyMath.RandomBool() ? caminfo.maxY - 5 : caminfo.minY + 5;
            spawnedobj.position = transform .position.with(y : 0)  + new Vector3(8*i +15, ypos, 0);
            objectsToChangemat.Add(spawnedobj.gameObject);

        }
        
        colorGenerator.AssignRandomMaterials(objectsToChangemat,player);
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Generate();
        }
        GetComponent<ParticlePlayer>().PlayParticle(GetComponentInChildren<Renderer>().sharedMaterial);

        //   Destroy(gameObject);
        GetComponent<MeshRenderer>().enabled = false;
        ImpactFaker.ImpactFakerInstance.SimulateFakeImpact(0, 0.04f, 1);
        CameraShaker.Shake(0.05f, 0.5f);
    }


}
