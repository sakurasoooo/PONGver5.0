using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControls : MonoBehaviour
{
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("Goball", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
 
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Player")) {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (other.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
        }
    }

    void Goball(){
        float rand = Random.Range(0,2);
        if (rand < 1) {
            rb2d.AddForce(new Vector2(20,-15));
        } else {
            rb2d.AddForce(new Vector2(-20,-15));
        }
    }

    void ResetBall (){
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame() {
        ResetBall();
        Invoke("Goball", 2);
    }
}
