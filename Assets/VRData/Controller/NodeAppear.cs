using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
	public class NodeAppear : MonoBehaviour
	{

		private SteamVR_TrackedObject trackedObj;

		private SteamVR_Controller.Device Controller
		{
			get { return SteamVR_Controller.Input((int)trackedObj.index); }
		}

		// Use this for initialization
		void Awake()
		{

			trackedObj = GetComponent<SteamVR_TrackedObject>();

		}

		// Update is called once per frame
		void Update()
		{


			if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
			{

				for (int i = 0; i < NodeRelationships.spheres.Length; i++)
				{

					if (NodeRelationships.spheres[i].tag == "Node")
					{
						NodeRelationships.spheres[i].GetComponent<MeshRenderer>().enabled = true;
						NodeRelationships.spheres[i].GetComponent<SphereCollider>().enabled = true;
					}


				}


				for (int i = 0; i < NodeRelationships.lines.Length; i++)
				{

					NodeRelationships.lines[i].GetComponent<LineRenderer>().enabled = true;
				}
			}
		}
	}
}
