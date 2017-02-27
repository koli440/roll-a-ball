using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class playerControler : MonoBehaviour {

    
    public Text CountText;
    public Text WinText;

    private Rigidbody rb;
    private int count;
    private float speed;
    private bool gameOver = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        WinText.text = String.Empty;
    }

    private void FixedUpdate()
    {
        if (!gameOver)
        {
            float moveHorizontal = 0;
            float moveVertical = 0;

            Debug.Log(Input.touchSupported);
            if (Input.touchSupported)
            {
                moveHorizontal = Input.GetTouch(0).deltaPosition.x;
                moveVertical = Input.GetTouch(0).deltaPosition.y;
                speed = 2;
            }
            else
            {
                moveHorizontal = Input.GetAxis("Horizontal");
                moveVertical = Input.GetAxis("Vertical");
                speed = 10;
            }
            Debug.Log(moveHorizontal);
            Debug.Log(moveVertical);

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(movement * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("pick up"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
            if (count == 12)
                WinText.text = "You got them all";
        }

        if (other.gameObject.CompareTag("danger"))
        {
            gameOver = true;
            WinText.text = "Game Over";
        }
    }

    private void setCountText()
    {
        CountText.text = String.Concat("Count: ", count.ToString());
    }
}
