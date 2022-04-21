using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControls : MonoBehaviour
{
    private Vector2 bornPos = Vector2.zero;
    private Rigidbody2D rb2d;
    private GameObject HUD;
    // Start is called before the first frame update
    void Start()
    {
        bornPos = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
        HUD = GameObject.FindGameObjectWithTag("GameController");
        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.tag == "Ball_blue")
        {
            if (other.collider.CompareTag("Player_blue"))
            {
                Vector2 vel;
                vel.x = rb2d.velocity.x;
                vel.y = (rb2d.velocity.y / 2) + (other.collider.attachedRigidbody.velocity.y / 3);
                rb2d.velocity = vel;
            } else if (other.collider.CompareTag("Player_red")) {
                 HUD.GetComponent<GameControls>().RespawnPlayer(other.gameObject.tag);// hide player
                GameControls.Score(other.gameObject.tag);
                HUD.GetComponent<GameControls>().Restart();
            }
        }
        else if (gameObject.tag == "Ball_red")
        {
            if (other.collider.CompareTag("Player_red"))
            {
                Vector2 vel;
                vel.x = rb2d.velocity.x;
                vel.y = (rb2d.velocity.y / 2) + (other.collider.attachedRigidbody.velocity.y / 3);
                rb2d.velocity = vel;
            }else if (other.collider.CompareTag("Player_blue")) {
                HUD.GetComponent<GameControls>().RespawnPlayer(other.gameObject.tag);// hide player
                GameControls.Score(other.gameObject.tag);
                HUD.GetComponent<GameControls>().Restart();
            }
        }
        
    }

    void Goball()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            if (gameObject.tag == "Ball_blue")
            {
                rb2d.AddForce(new Vector2(20, -15));
            }
            else if (gameObject.tag == "Ball_red")
            {
                rb2d.AddForce(new Vector2(-20, 15));
            }
        }
        else
        {
            if (gameObject.tag == "Ball_blue")
            {
                rb2d.AddForce(new Vector2(20, 15));
            }
            else if (gameObject.tag == "Ball_red")
            {
                rb2d.AddForce(new Vector2(-20, -15));
            }
        }
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = bornPos;
    }

    void  RestartGame()
    {
        ResetBall();
        Invoke("Goball", 2);
    }
}
