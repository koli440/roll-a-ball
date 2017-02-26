using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class playerControler : MonoBehaviour {

    public float speed;
    public Text CountText;
    public Text WinText;

    private Rigidbody rb;
    private int count;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        WinText.text = String.Empty;
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetTouch(0).deltaPosition.x;
        float moveVertical = Input.GetTouch(0).deltaPosition.y;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);


        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pick up"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
            if (count == 12)
                WinText.text = "You got them all";
        }
    }

    private void setCountText()
    {
        CountText.text = String.Concat("Count: ", count.ToString());
    }
}
