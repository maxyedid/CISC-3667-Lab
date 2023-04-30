using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{

    public Rigidbody2D rigidBody;
    public SpriteRenderer sprite;
    public float timer = 0;
    private float disappearingRate = 3f;
    private float aboutToDisappear = 5f;
    private float destroyRate = 6f;
    // Start is called before the first frame update
    void Update() {
        if (timer < destroyRate) {
            timer += Time.deltaTime;
        } else {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate() {
        if (timer >= aboutToDisappear) {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, .5f);
        } else if (timer >= disappearingRate) {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, .8f);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Ground")) {
            rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }
    
}
