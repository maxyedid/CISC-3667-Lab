using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{

    public GameObject arrow;
    public float timer = 0;
    public float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) {
            timer += Time.deltaTime;
        } else {
            spawnArrow();
            timer = 0;
            spawnRate = (float)Random.Range(2f, 4f);
        }
    }

    void spawnArrow() {
        Instantiate(arrow, new Vector2((float)Random.Range(-7.75f, 7.75f), 5.5f), arrow.transform.rotation);
    }
}
