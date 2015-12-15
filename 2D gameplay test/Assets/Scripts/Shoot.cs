using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	Rigidbody2D rb;
	public float strength;
	public Transform bow;
	public Vector2 weight;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce(transform.right*strength,ForceMode2D.Impulse);

	

	}


	void FixedUpdate () {

	}


	void Update () {
        Quaternion.LookRotation(rb.velocity);
        //Vector2.Angle(new Vector2(,))
	
	
	}
}
