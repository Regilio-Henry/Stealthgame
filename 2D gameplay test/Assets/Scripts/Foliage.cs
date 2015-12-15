using UnityEngine;
using System.Collections;

public class Foliage : MonoBehaviour {

	MeshFilter mesh;
	Vector3[] verts_ref;
	public int verti;
	public float vertposy;
	public float vertposx;




	// Use this for initialization
	void Start () {
	
	
	
	}
	
	// Update is called once per frame
	void Update () {
	Mesh mesh = GetComponent<MeshFilter>().mesh;
	Vector3[] vertices = mesh.vertices;
	vertices [verti] = new Vector3 (vertposx,vertposy, 0);
	mesh.vertices = vertices;
	mesh.RecalculateBounds();



		mesh.RecalculateNormals();
	}

}
