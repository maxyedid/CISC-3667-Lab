using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Balloon_Movement : MonoBehaviour
{

    public Rigidbody2D balloon;
    public float speed = 5;
    public int direction = -1;
    public AudioSource hit;
    public AudioSource pop;
    public int currentScore;
    public int count = 0;
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        currentScore = 100;
        balloon.velocity = new Vector2(speed * direction, 0);
        InvokeRepeating("growBalloon", 5f/(logic.level), 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.y > .27f) {
            AudioSource.PlayClipAtPoint(pop.clip, new Vector2(0, 0), PlayerPrefs.GetFloat("volume", 1f));
            Destroy(gameObject);
            logic.gameOver();
        }
    }

    private void FixedUpdate() {
        balloon.velocity = new Vector2(speed * direction, 0);
    }
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("Wall")) {
            direction = 0 - direction;    
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Projectile") && !logic.gameIsOver) {
            AudioSource.PlayClipAtPoint(hit.clip, new Vector2(0, 0), PlayerPrefs.GetFloat("volume", 1f));
            logic.addScore(currentScore);
            logic.winScreen();
            Destroy(gameObject);
        } else if (other.gameObject.tag.Equals("Wall")) {
            direction = 0 - direction;    
        }
    }

    [ContextMenu("Grow Balloon")]
    void growBalloon() {
        currentScore -= 5;
        count++;
        transform.localScale = new Vector2(transform.localScale.x + .01f, transform.localScale.y + .01f);
        transform.position = new Vector2(transform.position.x, transform.position.y - .05f);
    }
}
