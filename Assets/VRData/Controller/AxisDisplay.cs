using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Controllers{
	
public class AxisDisplay : MonoBehaviour {

		private GameObject[] axis;
		private GameObject holder;

		private SteamVR_TrackedObject trackedObj;

		private SteamVR_Controller.Device Controller {
				get { return SteamVR_Controller.Input ((int)trackedObj.index); }
			}

	// Use this for initialization
		void Awake()
		{

			trackedObj = GetComponent<SteamVR_TrackedObject> ();

		}

		void Start(){


			axis = new GameObject[3];
			holder = new GameObject ("Axis");
			holder.transform.parent = this.transform;
			holder.transform.localPosition = Vector3.zero;

			for (int i = 0; i < axis.Length; i++) {

				axis [i] = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
				axis [i].transform.localScale = new Vector3 (0.025f, .1f, 0.025f);
				axis [i].GetComponent<CapsuleCollider> ().enabled = false;

			}

			axis [0].tag = "AxisX";
			axis [0].name = "Axis X";
			axis [0].transform.rotation = Quaternion.Euler (0, 0, 90);
			axis [0].transform.position = new Vector3(0.1f, 250f, 0.15f);
			axis [0].GetComponent<Renderer> ().material.color = Color.red;

			axis [1].tag = "AxisY";
			axis [1].name = "Axis Y";
			axis [1].transform.rotation = Quaternion.Euler (0, 0, 0);
			axis [1].transform.position = new Vector3(0, 250.1f, 0.15f);
			axis [1].GetComponent<Renderer> ().material.color = Color.green;

			axis [2].tag = "AxisZ";
			axis [2].name = "Axis Z";
			axis [2].transform.rotation = Quaternion.Euler (90, 0, 0);
			axis [2].transform.position = new Vector3(0, 250f, 0.25f);
			axis [2].GetComponent<Renderer> ().material.color = Color.blue;



		}

	
	// Update is called once per frame
	void Update () {

			for (int i = 0; i < axis.Length; i++) {

				axis [i].transform.parent = holder.transform;

			}


		
		}
	}
}
