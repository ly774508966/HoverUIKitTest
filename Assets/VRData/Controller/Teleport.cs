using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers{
	
public class Teleport {

		public void teleporter(RaycastHit hitObject, SteamVR_Controller.Device Controller){

			if (Controller.GetPress (SteamVR_Controller.ButtonMask.Touchpad)) {
			
				Vector2 touchpad = (Controller.GetAxis (Valve.VR.EVRButtonId.k_EButton_Axis0));

				if (touchpad.x > -0.7 && touchpad.x < 0.7 && (hitObject.point != Vector3.zero)) {

					GameObject.Find ("Cube").transform.position = hitObject.point;

				}
			}
		}

	}
		
}
	

