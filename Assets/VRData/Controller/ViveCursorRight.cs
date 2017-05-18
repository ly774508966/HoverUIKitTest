using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using AssemblyCSharp;


namespace Controllers{


	public class ViveCursorRight : MonoBehaviour {

		NodeInfo about = new NodeInfo();
		Pointer CursorProperties = new Pointer();
	

		private SteamVR_TrackedObject trackedObjRight;

		private SteamVR_Controller.Device ControllerRight
		{
			get { return SteamVR_Controller.Input((int)trackedObjRight.index); }
		}

	
		public Color color;

		public float thickness = 0.002f;    
		public float length = 1000f;

		public bool showCursor = true;

		public string about_node;

		public RaycastHit objectPosition;

		GameObject holder;
		GameObject pointer;
		GameObject cursor;

		Vector3 cursorScale = new Vector3(0.05f, 0.05f, 0.05f);
		float contactDistance = 0f;
		float actualLength;
		Transform contactTarget = null;


		// Use this for initialization
		void Start () {

			trackedObjRight = GetComponent<SteamVR_TrackedObject>();

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

			if (ControllerRight.GetHairTriggerDown() && hitObject.point != Vector3.zero) {

				GameObject canvas = new GameObject ();
				about_node = hitObject.collider.gameObject.GetComponent<ProfileData> ().profile;

				about.Display (canvas, "Node Name");
				about.Information (about_node, canvas.transform, "Node Name");

				canvas.name = "Node Name";
				bool bworldPosition = false;

				canvas.GetComponent<RectTransform> ().SetParent (this.transform, bworldPosition);
				canvas.transform.localPosition = new Vector3(0, 0.25f, 0); 
				canvas.transform.localScale = new Vector3 (
					1.0f / this.transform.localScale.x * 0.1f,
					1.0f / this.transform.localScale.y * 0.1f,
					1.0f / this.transform.localScale.z * 0.1f);
			}

			if (ControllerRight.GetHairTriggerUp ()) {

				Destroy (GameObject.Find ("Node Name"));

			}


			CursorProperties.SetPointerTransform(beamLength, thickness, pointer, cursor);

		}
	}
}
