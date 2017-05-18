using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Controllers{

	public class NodeRelationships : MonoBehaviour {

		private string line;

		public static GameObject[] spheres;
		public static LineRenderer[] lines;

		private SteamVR_TrackedObject trackedObj;

		private SteamVR_Controller.Device Controller
		{
			get { return SteamVR_Controller.Input((int)trackedObj.index); }
		}

		// Use this for initialization
		void Awake()
		{

			spheres = FindObjectsOfType (typeof(GameObject)) as GameObject[];
			lines = FindObjectsOfType (typeof(LineRenderer)) as LineRenderer[];

			trackedObj = GetComponent<SteamVR_TrackedObject>();

		}


		// Update is called once per frame
		void Update() {


			if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
			{

				for (int i = 0; i < spheres.Length; i++) { 

					for (int j = 0; j < lines.Length; j++) { 


						if ((!spheres[i].name.Contains(node.node_name) && (spheres[i].tag == "Node")))
						{

							spheres[i].GetComponent<MeshRenderer>().enabled = false;
							spheres[i].GetComponent<SphereCollider>().enabled = false;
						}


					}
				}

				for (int i = 0; i < spheres.Length; i++)
				{

					for (int j = 0; j < lines.Length; j++)

					{

						line = lines[j].name.Replace(node.node_name, "");
						line = line.Replace(".", "");

						if (spheres[i].name.Contains(line) && (spheres[i].tag == "Node"))
						{

							spheres[i].GetComponent<MeshRenderer>().enabled = true;
							spheres[i].GetComponent<SphereCollider>().enabled = true;
						}
					}
				}

				for (int i = 0; i < lines.Length; i++)
				{

					if (!lines[i].name.Contains(node.node_name))
					{

						lines[i].GetComponent<LineRenderer>().enabled = false;

					}

					else
						lines[i].GetComponent<LineRenderer>().enabled = true;
				}
			}

		}
	}
}
