using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    public Rigidbody2D myRigidBody;
    public float speed = 7.0f;
    public float movement;
    public bool jumpPressed;
    public float jumpForce = 500.0f;
    public bool facingRight = true;
    public bool isGrounded = true;
    public bool sprinting = false;
    public GameObject arrow;
    public float spawnRate = 2.0f;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Space)) {
            jumpPressed = true;
        }
        if (Input.GetKey(KeyCode.LeftShift)) {
            sprinting = true;
        } else {
            sprinting = false;
        }
        if (Input.GetKey(KeyCode.F)) {
            fireArrow();
        } 
    }

    private void FixedUpdate() {
        if (sprinting) {
            speed = 10;
        } else {
            speed = 7;
        }
        myRigidBody.velocity = new Vector2(speed * movement, myRigidBody.velocity.y);
        if (movement < 0 && facingRight || movement > 0 && !facingRight) {
            Flip();
        }
        if (jumpPressed && isGrounded) {
            Jump();
        } else {
            jumpPressed = false;
        }

        if (timer < spawnRate) {
            timer += Time.deltaTime;
        }

    }

    private void fireArrow() {
        if (timer >= spawnRate) {
            spawnArrow();
            timer = 0;
        }
    }
    private void spawnArrow() {
        Instantiate(arrow, new Vector2(transform.position.x, transform.position.y + 1), arrow.transform.rotation);
    }
    private void Flip() {
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
    }

    private void Jump() {
        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0);
        myRigidBody.AddForce(new Vector2(0, jumpForce));

        jumpPressed = false;
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("Ground")) {
            isGrounded = true;
        }
    }
}
