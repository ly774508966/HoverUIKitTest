using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementLeft : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;
	// 2
	private SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	private GameObject camera;


	// Use this for initialization
	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();

		camera = GameObject.Find("Cube");


	}

	// Update is called once per frame
	void Update () {


		Vector2 touchpad = (Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));


		if (touchpad.y > 0.7f)
		{
			camera.transform.position += new Vector3 (0, 4.0f, 0); 

		}

		else if (touchpad.y < -0.7f)
		{

			camera.transform.position -= new Vector3 (0, 4.0f, 0); 
		}

		if (touchpad.x > 0.7f)
		{
			camera.transform.position += new Vector3 (4.0f, 0, 0);

		}

		else if (touchpad.x < -0.7f)
		{

			camera.transform.position -= new Vector3 (4.0f, 0, 0);
		}




	}
}
