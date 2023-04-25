using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawn : MonoBehaviour
{
    public GameObject bird;

    public float timer = 0;

    public float spawnRate;

    public 
    // Start is called before the first frame update
    void Start()
    {
        spawnRate = Random.Range(3, 6);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) {
            timer = timer + Time.deltaTime;
        } else {
            spawnBird();
            timer = 0;
            spawnRate = Random.Range(3, 6);
        }
    }


    [ContextMenu("Spawn Bird")]
    public void spawnBird() {
        Instantiate(bird, transform.position, transform.rotation);
    }
}
