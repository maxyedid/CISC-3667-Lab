using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Movement : MonoBehaviour
{
    public Rigidbody2D birdBody;
    public float speed = 3;

    public int direction = -1;

    public float deadZone = 9f;
    // Start is called before the first frame update
    void Start()
    {
        birdBody.velocity = new Vector2(speed * direction, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (direction < 0 && transform.position.x <= deadZone * direction) {
            Destroy(gameObject);
        }
        else if (direction > 0 && transform.position.x >= deadZone * direction) {
            Destroy(gameObject);
        }
    }
}
