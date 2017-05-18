using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Controllers;

namespace Menu{

	public class ControllerHelpLeft : MonoBehaviour {

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

			scale = new Vector3 (
				1.0f / this.transform.localScale.x * 0.1f,
				1.0f / this.transform.localScale.y * 0.1f,
				1.0f / this.transform.localScale.z * 0.1f);

			trackedObj = GetComponent<SteamVR_TrackedObject>();

			InfoText.SetupDisplay ();

			InfoDisplay.DisplayInformation (InfoText.CanvasLeft, InfoText.ControllerInfoLeft);

			for (int i = 0; i < InfoText.ControllerInfoLeft.Length; i++) {

				InfoText.CanvasLeft [i].GetComponent<RectTransform> ().SetParent (this.transform, bworldPosition);

				InfoText.CanvasLeft [i].transform.localScale = scale;
			}
		}

		// Update is called once per frame
		void Update () {

			if (HelpInformation.menuDisplayOn &&  HelpInformation.timeRemaining == 10.0f){

				InfoText.SetupDisplay ();

				InfoDisplay.DisplayInformation (InfoText.CanvasLeft, InfoText.ControllerInfoLeft);

				for (int i = 0; i < InfoText.ControllerInfoLeft.Length; i++) {

					InfoText.CanvasLeft [i].GetComponent<RectTransform> ().SetParent (this.transform, bworldPosition);

					InfoText.CanvasLeft [i].transform.localScale = scale;

				}
			}				

		}
	}
}
