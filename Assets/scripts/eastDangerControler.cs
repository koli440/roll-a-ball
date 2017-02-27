using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class eastDangerControler : MonoBehaviour {
    public int StartRangeMinimum;
    public int StartRangeMaximum;

    private Rigidbody rb;
    System.Random random;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        random = new System.Random(DateTime.Now.Millisecond);
        int n = random.Next(StartRangeMinimum, StartRangeMaximum);

        rb.MovePosition(new Vector3(rb.position.x, rb.position.y, n));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
