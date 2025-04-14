using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public class ParticleManager : Singleton<ParticleManager>
{

    public GameObject[] particlePrefabs;
    public bool spawnRandom;
    public bool spawnInCanvas;
    public GameObject canvas;
    public GameObject confettiPrefab;

    private void Start()
    {
        canvas = GameObject.Find("Canvas");
        if (canvas == null)
        {
            spawnInCanvas = false;
        }
        else
        {
            spawnInCanvas = false;
        }
    }


    public void Spawn()
    {
        GameObject Go;

        if (spawnInCanvas)
        {
            if (!spawnRandom)
            {
                Go = Instantiate(particlePrefabs[0], Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);

            }
            else
            {
                Go = Instantiate(particlePrefabs[Random.Range(0, particlePrefabs.Length)], Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            }

            Go.transform.SetParent(canvas.transform);
            Go.transform.SetAsFirstSibling();
        }
        else
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;
            if (!spawnRandom)
            {
              Go =  Instantiate(particlePrefabs[0], Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            }
            else
            {
               Go = Instantiate(particlePrefabs[Random.Range(0, particlePrefabs.Length)], Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            }
            Go.transform.position = new Vector3(Go.transform.position.x, Go.transform.position.y,0);
        }


    }

    public void SpawnConfetti()
    {
        Instantiate(confettiPrefab);
    }
}
