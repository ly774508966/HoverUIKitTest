using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hover.Core.Utils;
using Hover.Core.Items;
using Hover.Core.Items.Types;
using Hover.Core.Items.Managers;
using Hover.Core.Renderers.Shapes.Arc;
using System.IO;



public class HoverCastMultiRadio : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GameObject radioButton = new GameObject("Project1");
		radioButton.AddComponent<HoverItemDataRadio> ().Label = "Project1";
		HoverItemBuilder builder = radioButton.AddComponent<HoverItemBuilder> ();
		builder.PerformBuild();
		radioButton.AddComponent<HoverShapeArc> ();
		radioButton.transform.parent = gameObject.transform;
		radioButton.transform.localPosition = Vector3.zero;


		string[] files = Directory.GetDirectories(@"/Users/robert/GitHub");

		for (int i = 0; i < files.Length; i++) {

			Debug.Log (files.Length);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
