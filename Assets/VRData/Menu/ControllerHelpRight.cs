using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controllers;

namespace Menu{

	public class ControllerHelpRight : MonoBehaviour {


		NodeInfo Information = new NodeInfo ();
		HelpInformation InfoText = new HelpInformation ();
		HelpInformationDisplay InfoDisplay = new HelpInformationDisplay();

		public bool bworldPosition = false;

		private SteamVR_TrackedObject trackedObj;
		private SteamVR_Controller.Device Controller{

			get { return SteamVR_Controller.Input((int)trackedObj.index); }
		}

		Vector3 scale;


		// Use this for initialization
		void Start () {

			HelpInformation.timeRemaining = 10.0f;
			HelpInformation.menuDisplayOn = true;

			scale = new Vector3 (
				1.0f / this.transform.localScale.x * 0.1f,
				1.0f / this.transform.localScale.y * 0.1f,
				1.0f / this.transform.localScale.z * 0.1f);

			trackedObj = GetComponent<SteamVR_TrackedObject>();

			InfoText.SetupDisplay ();

			InfoDisplay.DisplayInformation (InfoText.CanvasRight, InfoText.ControllerInfoRight);

			for (int i = 0; i < InfoText.ControllerInfoRight.Length; i++) {

				InfoText.CanvasRight [i].GetComponent<RectTransform> ().SetParent (this.transform, bworldPosition);
				InfoText.CanvasRight [i].transform.localScale = scale;
			}
		}

		// Update is called once per frame
		void Update () {

			if (HelpInformation.menuDisplayOn)
			{

				HelpInformation.timeRemaining -= Time.deltaTime;
			}


			if (Controller.GetPressDown (SteamVR_Controller.ButtonMask.ApplicationMenu) && HelpInformation.menuDisplayOn == false){

				InfoText.SetupDisplay ();

				InfoDisplay.DisplayInformation (InfoText.CanvasRight, InfoText.ControllerInfoRight);

				for (int i = 0; i < InfoText.ControllerInfoRight.Length; i++) {

					InfoText.CanvasRight [i].GetComponent<RectTransform> ().SetParent (this.transform, bworldPosition);

					InfoText.CanvasRight [i].transform.localScale = scale;

					HelpInformation.menuDisplayOn = true;
				}
			}

			if (HelpInformation.timeRemaining <= 0.0f)
			{
				HelpInformation.timeRemaining = 10.0f;
				HelpInformation.menuDisplayOn = false;

			}

			if (!HelpInformation.menuDisplayOn)
			{

				Destroy(GameObject.Find("ControllerHelp"));

			}


		}
	}
}

