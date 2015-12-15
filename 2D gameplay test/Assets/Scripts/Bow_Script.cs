using UnityEngine;
using System.Collections;

public class Bow_Script : MonoBehaviour {

	public float tst;
	public GameObject Arrow;
	Animator anim;
	// Use this for initialization
	void Start () {
		 //var Prefabs = Resources.Load("Arrow") as GameObject;
		anim = GetComponent<Animator> ();
	}
	
	void Update () {


		// aiming
		var pos = Camera.main.WorldToScreenPoint(transform.position);
		var dir = Input.mousePosition - pos;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		Physics2D.IgnoreLayerCollision (10, 11);

		if (Input.GetMouseButtonDown (0)) {
			anim.SetBool ("use", true);
		
		} 

		if (Input.GetMouseButtonUp(0)){
		Instantiate(Arrow, transform.position, transform.rotation);
		anim.SetBool("use", false);
		}




	}
}
