using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class playerControler : MonoBehaviour {

    
    public Text CountText;
    public Text WinText;
    public float MinY;
    public int NumberOfPickups;

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
            float jump = 0;

            Debug.Log(Input.touchSupported);
            if (Input.touchSupported)
            {
                moveHorizontal = Input.GetTouch(0).deltaPosition.x;
                moveVertical = Input.GetTouch(0).deltaPosition.y;
                if (Input.GetTouch(0).phase == TouchPhase.Stationary)
                    jump = 9;
                speed = 2;
            }
            else
            {
                moveHorizontal = Input.GetAxis("Horizontal");
                moveVertical = Input.GetAxis("Vertical");
                if (Input.GetButtonDown("Jump"))
                    jump = 18;
                speed = 10;
            }
            Debug.Log(moveHorizontal);
            Debug.Log(moveVertical);

            Vector3 movement = new Vector3(moveHorizontal, jump, moveVertical);

            rb.AddForce(movement * speed);
        }
        if (rb.position.y <= MinY)
        {
            endGame();
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
            if (count == NumberOfPickups)
                winGame();
        }

        if (other.gameObject.CompareTag("danger"))
        {
            endGame();
        }
    }

    private void setCountText()
    {
        CountText.text = String.Concat("Count: ", count.ToString());
    }

    private void winGame()
    {
        WinText.text = "You got them all";
    }

    private void endGame()
    {
        gameOver = true;
        WinText.text = "Game Over";
        rb.velocity = new Vector3(0, 0, 0);
    }
}
