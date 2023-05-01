using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody rigidBodyComponent;
    bool jump;
    bool touchGround;
    private float horizontal;
    public static int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent= GetComponent<Rigidbody>();
        jump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && touchGround == true)
        {
            jump = true;
        }
        horizontal = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            rigidBodyComponent.AddForce(6 * Vector3.up, ForceMode.VelocityChange);
            jump = false;
            touchGround = false;
        }
        rigidBodyComponent.velocity = new Vector3(4 * horizontal, rigidBodyComponent.velocity.y, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        touchGround = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ShrinkCoin"))
        {
            Destroy(other.gameObject);
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
            rigidBodyComponent.velocity = new Vector3(6 * horizontal, rigidBodyComponent.velocity.y, 0);
            if (jump)
            {
                rigidBodyComponent.AddForce(9 * Vector3.up, ForceMode.VelocityChange);
                jump = false;
                touchGround = false;
            }
        }
        if (other.CompareTag("Coin"))
        { 
            points += 1;
            Destroy(other.gameObject);
        }
    }
}
