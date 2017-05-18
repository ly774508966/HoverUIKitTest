using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menu{

	public class HelpInformation{

		public static bool menuDisplayOn { get; set;}
		public static float timeRemaining { get; set; }

		private static int N = 8;

		public string[] ControllerInfoLeft = new string[N];
		public string[] ControllerInfoRight = new string[N];

		public GameObject[] CanvasLeft = new GameObject[N];
		public GameObject[] CanvasRight = new GameObject[N];

		private string UpPositionLeft = "Moves the camera up. ";
		private string UpPositionRight = "Zooms the camera in. ";
		private string DownPositionLeft = "Moves the camera down. ";
		private string DownPositionRight = "Zooms the camera out. ";
		private string LeftPositionLeft = "Moves the camera to the right. ";
		private string LeftPositionRight = "";
		private string RightPositionLeft = "Moves the camera to the left. ";
		private string RightPositionRight = "";
		private string CenterLeft = "Teleports the user to the pointed node. ";
		private string CenterRight = "Recenters the camera to the origin. ";
		private string GripLeft = "Isolates for the selected node and all its connections. ";
		private string GripRight = "Shows all the nodes which were made invisible. ";
		private string TriggerLeft = "Selects a node into the memory and shows its name. ";
		private string TriggerRight = "Shows the information on the selected node. ";
		private string MenuLeft = "Shows the selected node's connections - color coded. ";
		private string MenuRight = "Displays controller information. ";


		public void SetupDisplay(){

			for (int i = 0; i < N; i++) {

				CanvasRight [i] = new GameObject ();
				CanvasLeft [i] = new GameObject ();
			}

			ControllerInfoLeft [0] = UpPositionLeft;
			ControllerInfoLeft [1] =  DownPositionLeft;
			ControllerInfoLeft [2] =  LeftPositionLeft;
			ControllerInfoLeft [3] =  RightPositionLeft;
			ControllerInfoLeft [4] =  CenterLeft;
			ControllerInfoLeft [5] =  GripLeft;
			ControllerInfoLeft [6] =  TriggerLeft;
			ControllerInfoLeft [7] =  MenuLeft;

			ControllerInfoRight [0] =  UpPositionRight;
			ControllerInfoRight [1] =  DownPositionRight;
			ControllerInfoRight [2] =  LeftPositionRight;
			ControllerInfoRight [3] =  RightPositionRight;
			ControllerInfoRight [4] =  CenterRight;
			ControllerInfoRight [5] =  GripRight;
			ControllerInfoRight [6] = TriggerRight;
			ControllerInfoRight [7] =  MenuRight;

			CanvasRight [0].transform.localPosition = new Vector3 (0, 0.25f, 1.0f);
			CanvasRight [1].transform.localPosition = new Vector3 (0, 0.25f, 0.5f);
			CanvasRight [2].transform.localPosition = new Vector3 (-1.0f, 0.25f, 0.7f);
			CanvasRight [3].transform.localPosition = new Vector3 (1.0f, 0.25f, 0.7f);
			CanvasRight [4].transform.localPosition = new Vector3 (0, 0.5f, 0.7f);
			CanvasRight [5].transform.localPosition = new Vector3 (-0.4f, -0.25f, 0.25f);
			CanvasRight [6].transform.localPosition = new Vector3 (0.7f, -0.25f, 0.25f);
			CanvasRight [7].transform.localPosition = new Vector3 (0, -0.2f, 0.7f);

			CanvasLeft [0].transform.localPosition = new Vector3 (0, 0.25f, 0.5f);
			CanvasLeft [1].transform.localPosition = new Vector3 (0, 0.25f, 1.0f);
			CanvasLeft [2].transform.localPosition = new Vector3 (0, 1.5f, 1.0f);
			CanvasLeft [3].transform.localPosition = new Vector3 (0, 1.5f, 1.0f);
			CanvasLeft [4].transform.localPosition = new Vector3 (0, 0.6f, 0.6f);
			CanvasLeft [5].transform.localPosition = new Vector3 (-1.0f, 0.25f, 0.3f);
			CanvasLeft [6].transform.localPosition = new Vector3 (0, -0.3f, 0.2f);
			CanvasLeft [7].transform.localPosition = new Vector3 (1.0f, 0.25f, 0.30f);
		}



	}



}
