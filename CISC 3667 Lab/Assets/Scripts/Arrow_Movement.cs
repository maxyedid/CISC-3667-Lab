using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Movement : MonoBehaviour
{
    public Rigidbody2D arrow;
    public float speed = 4;

    public float deadZone = 6f;
    // Start is called before the first frame update
    void Start()
    {
        arrow.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > deadZone) {
            Destroy(gameObject);
        }
    }

}
