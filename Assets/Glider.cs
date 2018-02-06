using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glider : MonoBehaviour {
	public Camera cam;
	public float movespeed;
	public float acceleration;
	public float turnspeed;

	Rigidbody rb;
	float speed;
	Vector3 movevector;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float turnH = Input.GetAxis ("Mouse X");
		float turnV = Input.GetAxis ("Mouse Y");
		//Debug.Log (turnH + "," + turnV);

		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");

		speed += moveV * acceleration;
		if (movevector == Vector3.zero) {
			speed = Mathf.Clamp (speed, -movespeed, movespeed);
		} else {
			speed = Mathf.Clamp (speed, 0f, movespeed);
		}

		movevector = transform.forward * speed;
		Debug.Log (movevector);
		rb.velocity = movevector;
		//rb.AddForce (movevector);
	}
}
