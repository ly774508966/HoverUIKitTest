using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


using AssemblyCSharp;

namespace Controllers{

	public class node{

		public static string node_name { get; set; }

	}

	public class ViveCursorLeft: MonoBehaviour {

		NodeInfo about = new NodeInfo();
		Pointer CursorProperties = new Pointer();
		Teleport teleport = new Teleport();

		private string information = "";

		public Color color;

		float thickness = 0.002f;
		float length = 100f;
		float contactDistance = 0f;


		public bool showCursor = true;
		public bool bworldPosition = false;

		public RaycastHit objectPosition;

		private SteamVR_TrackedObject trackedObj;
		private SteamVR_Controller.Device Controller
		{
			get { return SteamVR_Controller.Input((int)trackedObj.index); }
		}


		GameObject holder;
		GameObject pointer;
		GameObject cursor;
		GameObject canvas;


		Vector3 cursorScale = new Vector3(0.05f, 0.05f, 0.05f);
		Vector3 scale;

		Transform contactTarget = null;


		// Use this for initialization
		void Start () {

			scale = new Vector3 (
				1.0f / this.transform.localScale.x * 0.1f,
				1.0f / this.transform.localScale.y * 0.1f,
				1.0f / this.transform.localScale.z * 0.1f);

			trackedObj = GetComponent<SteamVR_TrackedObject>();

			Material newMaterial = new Material(Shader.Find("Unlit/Color"));
			newMaterial.SetColor("_Color", color);

			holder = new GameObject();
			holder.transform.parent = this.transform;
			holder.transform.localPosition = Vector3.zero;

			pointer = GameObject.CreatePrimitive(PrimitiveType.Cube);
			pointer.transform.parent = holder.transform;
			pointer.GetComponent<MeshRenderer>().material = newMaterial;

			pointer.GetComponent<BoxCollider>().isTrigger = true;
			pointer.AddComponent<Rigidbody>().isKinematic = true;
			pointer.layer = 2;

			if (showCursor)
			{
				cursor = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				cursor.transform.parent = holder.transform;
				cursor.GetComponent<MeshRenderer>().material = newMaterial;
				cursor.transform.localScale = cursorScale;

				cursor.GetComponent<SphereCollider>().isTrigger = true;
				cursor.AddComponent<Rigidbody>().isKinematic = true;
				cursor.layer = 2;
			}

			CursorProperties.SetPointerTransform (length, thickness, pointer, cursor);        
		}


		void Update () {

			Ray raycast = new Ray(transform.position, transform.forward);

			RaycastHit hitObject;

			bool rayHit = Physics.Raycast(raycast, out hitObject);

			float beamLength = CursorProperties.GetBeamLength(rayHit, hitObject, length, contactDistance, contactTarget);

			canvas = new GameObject ();

			if (Controller.GetHairTriggerDown() && hitObject.point != Vector3.zero) {

				if (node.node_name == null) {
					
					node.node_name = "No Node Selected";
				}

				node.node_name = hitObject.collider.gameObject.name;

				about.Display (canvas, "Node Name");
				about.Information (node.node_name, canvas.transform, "Node Name");

				canvas.GetComponent<RectTransform> ().SetParent (this.transform, bworldPosition);
				canvas.transform.localPosition = new Vector3(0, 0.25f, 0); 
				canvas.transform.localScale = scale;
			}

			if (Controller.GetHairTriggerUp ()) {

				Destroy (GameObject.Find ("Node Name"));

			}

			teleport.teleporter (hitObject, Controller);

			if (Controller.GetPressDown (SteamVR_Controller.ButtonMask.ApplicationMenu) && information != null) {
				
				information = about.ColorCoding (node.node_name, Reference.node_references);
				about.Display (canvas, "Connections");
				about.Connection (information, canvas.transform, "Connections");

				canvas.GetComponent<RectTransform> ().SetParent (this.transform, bworldPosition);
				canvas.transform.localPosition = new Vector3(0, 1.5f, 1.0f); 
				canvas.transform.localScale = scale;
		
			}



			if(Controller.GetPressUp((SteamVR_Controller.ButtonMask.ApplicationMenu))){

				Destroy(GameObject.Find("Connections"));
				information = "";


			}

			CursorProperties.SetPointerTransform (beamLength, thickness, pointer, cursor);
		}
	}
}
