using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Movement : MonoBehaviour
{

    public Rigidbody2D balloon;
    public float speed = 5;

    public int direction = -1;

    // Start is called before the first frame update
    void Start()
    {
        balloon.velocity = new Vector2(speed * direction, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        balloon.velocity = new Vector2(speed * direction, 0);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("Wall")) {
            direction = 0 - direction;
        }
    }
}
