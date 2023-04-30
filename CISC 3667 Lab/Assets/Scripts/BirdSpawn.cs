using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawn : MonoBehaviour
{
    public GameObject bird;
    public float speed = 3;
    public float timer = 0;
    public float minTime = 3f;
    public float maxTime = 6f;
    public float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        spawnRate = (float)Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) {
            timer = timer + Time.deltaTime;
        } else {
            spawnBird();
            timer = 0;
            spawnRate = Random.Range(minTime, maxTime);
        }
    }


    [ContextMenu("Spawn Bird")]
    public void spawnBird() {
        Bird_Movement current = bird.GetComponent<Bird_Movement>();
        current.speed = this.speed;
        Instantiate(bird, transform.position, bird.transform.rotation);
    }
}
