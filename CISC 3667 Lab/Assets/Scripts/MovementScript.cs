using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D myRigidBody;
    public float speed = 7.0f;
    public float movement;
    public bool jumpPressed;
    public float jumpForce = 500.0f;
    public bool facingRight = true;
    public bool isGrounded = true;
    public bool sprinting = false;
    public GameObject arrow;
    public float spawnRate = 1.0f;
    public float timer = 0;
    public int numArrows;
    public LogicScript logic;
    public KeyCode fireKey;
    public KeyCode jumpKey;
    public KeyCode sprintKey;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        fireKey = (KeyCode) PlayerPrefs.GetInt("fireKey",(int)(KeyCode.F));
        jumpKey = (KeyCode) PlayerPrefs.GetInt("jumpKey", (int)KeyCode.Space);
        sprintKey = (KeyCode) PlayerPrefs.GetInt("sprintKey", (int) KeyCode.LeftShift);
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        numArrows = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!logic.paused && !isDead) {
            movement = Input.GetAxis("Horizontal");
            animator.SetFloat("Speed", Mathf.Abs(movement));
            if (Input.GetKey(jumpKey)) {
                jumpPressed = true;
            }
            if (Input.GetKey(sprintKey)) {
                speed = 10;
            } else {
                speed = 7;
            }
            if (Input.GetKey(fireKey)) {
                fireArrow();
            } 
        }
    }

    private void FixedUpdate() {
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
        if (timer >= spawnRate && numArrows > 0) {
            animator.Play("Fire");
            spawnArrow();
            timer = 0;
            numArrows--;
            logic.updateArrows(numArrows);
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
        animator.Play("Jump");
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

    public void die() {
        movement = 0;
        animator.Play("Death");
        isDead = true;
    }
    public void changeKeys() {
        fireKey = (KeyCode) PlayerPrefs.GetInt("fireKey",(int)(KeyCode.F));
        jumpKey = (KeyCode) PlayerPrefs.GetInt("jumpKey", (int)KeyCode.Space);
        sprintKey = (KeyCode) PlayerPrefs.GetInt("sprintKey", (int) KeyCode.LeftShift);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Bird")) {
            die();
            logic.gameOver();
        } else if (other.gameObject.tag.Equals("Power Up")) {
            Debug.Log("Got to power up");
            numArrows++;
            if (numArrows > 10) {
                numArrows = 10;
            }
            logic.updateArrows(numArrows);
            Destroy(other.gameObject);
        }
    }
}
