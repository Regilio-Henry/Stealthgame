using UnityEngine;
using System.Collections;

public class Player_controler : MonoBehaviour {

	public float speed;
	float moveH;
	float moveV;
	public float jumpheight;
	Rigidbody2D rb;
	Animator anim;
	bool grounded;
	public LayerMask Ground;
	public Transform OnGround;
	public Transform OnCeiling;
	public Transform OnLedge1;
	public Transform OnLedge2;
	public float rad = 2.0f;
	public float ceilrad = 2.0f;
	public float area = 0.5f;
	bool fr = true;
	bool Ceilingcrawl;
	private float varspeed = 10;



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		grounded = true;
		Ceilingcrawl = false;
		varspeed = 10;
	}


	void Update() {

		var tst = Mathf.MoveTowards(0, 4,Time.deltaTime * 2);
		Debug.Log(varspeed);
        speed = varspeed;


        //Ceiling crawl script
        if (Physics2D.OverlapArea (OnLedge1.position, OnLedge2.position, Ground)) {
			//Debug.Log ("Got ledge sir");
			Ceilingcrawl = true;
			Disablegravity ();	
		} else {
			Enablegravity();
		}
		if (Ceilingcrawl = true && Input.GetKey("down")) {
			Enablegravity();
		}

		//Sprinting

		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			varspeed = varspeed * 0.5f;
		} else {
			varspeed = 10f;
		}

        Debug.Log(transform.position);

		//Ground Detection
		if (Physics2D.OverlapCircle(OnGround.position,rad,Ground)) {
			Debug.Log("Red leader has landed");
            grounded = true;
		}
		else {
			grounded = false;
		}

			

	}

	// Update is called once per frame
	void FixedUpdate () {

		//Movement variable
		moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
		rb.velocity = new Vector2 (moveH*speed, rb.velocity.y);

		//Jump
		if (moveV > 0) {
            Debug.Log("ik stink naar kaas");
             //&& grounded
            rb.AddForce(transform.up*jumpheight);
		}

		//Check if facing direction
		if (moveH > 0 && !fr) {
			Flip();
		}
		else if (moveH < 0 && fr) {
			Flip();
		}






	}


	void OnDrawGizmos () {
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere (OnGround.position, rad);

	}


	//Script for flipping sprites
	void Flip() 
	{
		fr = !fr;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	//Enabeling/Disabling gravity 
	void Disablegravity()
	{
		rb.gravityScale = 0f;
	}

	void Enablegravity()
	{
		rb.gravityScale = 1f;
	}






}
