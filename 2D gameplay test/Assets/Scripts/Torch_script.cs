using UnityEngine;
using System.Collections;

public class Torch_script : MonoBehaviour {

	public Light lt;
	public float smoothing;
	private float intenso;
	private float lo = 1.5f; 
	private float hi = 2.5f;
	private float target;
	// Use this for initialization
	void Start () {
	lt = GetComponent<Light> ();
		target = hi;
	}
	
	// Update is called once per frame
	void Update () {
		if (target == hi) target = lo;
			
		if (target == lo) target = hi;



		intenso = Mathf.PingPong (Time.time, target);
	

		lt.intensity = intenso;

		Debug.Log (target);

	}
}
