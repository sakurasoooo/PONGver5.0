using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SuperAbility : MonoBehaviour
{
    public TextMeshProUGUI blueUI;
    public TextMeshProUGUI redUI;
    public bool locked = true;
    public GameObject player1;
    public GameObject player2;
    public GameObject ball1;
    public GameObject ball2;
    public KeyCode p1key = KeyCode.A;
    public KeyCode p2key = KeyCode.RightArrow;

    private float p1Energy = 0;
    private float p2Energy = 0;

    private float recoverSpeed = 1.0f;
    private float maxEnergy = 10.0f;

    private float acceleration = 10.0f;
    private float cost = 5.0f;
    // Update is called once per frame

    private void Awake()
    {
        locked = true;
        p1Energy = maxEnergy;
        p2Energy = maxEnergy;
    }
    void Update()
    {
        blueUI.text = $"{(int)p1Energy}";
        redUI.text = $"{(int)p2Energy}";
        // recovery energy
        if (p1Energy < maxEnergy)
        {
            p1Energy += recoverSpeed * Time.deltaTime;
        }

        if (p2Energy < maxEnergy)
        {
            p2Energy += recoverSpeed * Time.deltaTime;
        }
        if (!locked)
        {
            if (Input.GetKey(p1key) && p1Energy > 0)
            {
                p1Energy -= cost * Time.deltaTime;
                Rigidbody2D rb2d = ball1.GetComponent<Rigidbody2D>();
                Vector2 direction = (player1.transform.position - ball1.transform.position);
                direction = direction.normalized;
                rb2d.AddForce(direction * cost * acceleration * Time.deltaTime);
            }

            if (Input.GetKey(p2key) && p2Energy > 0)
            {
                p2Energy -= cost * Time.deltaTime;
                Rigidbody2D rb2d = ball2.GetComponent<Rigidbody2D>();
                Vector2 direction = (player2.transform.position - ball2.transform.position);
                direction = direction.normalized;
                rb2d.AddForce(direction * cost * acceleration * Time.deltaTime);
            }
        }
    }

    void LockControl()
    {
        locked = true;
    }

    void UnLockControl()
    {
        locked = false;
    }
}
