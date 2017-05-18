// ping-pong animate background color
using UnityEngine;
using System.Collections;

using AssemblyCSharp;

public class BackgroundColor : MonoBehaviour {

	float planeSc;
	public Color black = Color.black;
	Main planeScale = new Main();

	Camera camera;


	void Start() {

		planeSc = planeScale.plane_scale / 4.0f;
		camera = GetComponent<Camera>();
		camera.clearFlags = CameraClearFlags.SolidColor;

		GameObject plane = GameObject.CreatePrimitive (PrimitiveType.Plane);
		plane.GetComponent<MeshCollider> ().enabled = false;
		plane.transform.localScale = new Vector3 (planeSc, planeSc, planeSc);
		plane.transform.position = new Vector3 (0, -100, 0);
		plane.GetComponent<Renderer> ().material.color = Color.black;
	}

	void Update() {
		
		camera.backgroundColor = black;
	}
}
