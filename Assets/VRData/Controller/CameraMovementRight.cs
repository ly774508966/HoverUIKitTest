using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class CameraMovementRight : MonoBehaviour {


	Main center = new Main();

	private SteamVR_TrackedObject trackedObj;
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

		Vector2 touchpad2 = (Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));

		if (touchpad2.y > 0.7f)
		{
			camera.transform.position += new Vector3 (0, 0, 4.0f); 

		}

		else if (touchpad2.y < -0.7f)
		{

			camera.transform.position -= new Vector3 (0, 0, 4.0f); 
		}

		if (Controller.GetPress (SteamVR_Controller.ButtonMask.Touchpad)) {


			Vector2 touchpad = (Controller.GetAxis (Valve.VR.EVRButtonId.k_EButton_Axis0));

			if (touchpad.x > 0.7f)
			{
				camera.transform.rotation *= Quaternion.Euler (0, 90, 0);

			}

			else if (touchpad.x < -0.7f)
			{

				camera.transform.rotation *= Quaternion.Euler (0, -90, 0);
			}

			if (touchpad.x > -0.7 && touchpad.x < 0.7 ) {

				GameObject.Find ("Cube").transform.position = center.center;

			}

		}

	}
}
