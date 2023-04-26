using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Movement : MonoBehaviour
{
    public Rigidbody2D birdBody;

    public float speed = 3;

    public int direction = -1;

    public float deadZone = 9f;

    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
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

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Player")) {
            Destroy(other.gameObject);
            logic.gameOver();
        }
    }
}
