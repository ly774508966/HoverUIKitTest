using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hover.Core.Utils;
using Hover.Core.Items;
using Hover.Core.Items.Types;
using Hover.Core.Items.Managers;
using Hover.Core.Renderers.Shapes.Arc;
using System;
using System.IO;




public class HoverCastMultiRadio : MonoBehaviour {

	GameObject[] radioButtons;
	string[] nameButtons;

	// Use this for initialization
	void Start () {


		string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Google Drive/Projects/";

		string[] files = Directory.GetDirectories(@filepath);



		nameButtons = new string[files.Length];
		radioButtons = new GameObject[files.Length];

		for (int i = 0; i < files.Length; i++) {

			nameButtons[i] = files [i].Replace (filepath,"");
			radioButtons[i] = new GameObject (nameButtons[i]);
			radioButtons[i].AddComponent<HoverItemDataRadio> ().Label = nameButtons[i];
			HoverItemBuilder builder = radioButtons[i].AddComponent<HoverItemBuilder> ();
			builder.PerformBuild ();
			radioButtons[i].AddComponent<HoverShapeArc> ();
			radioButtons[i].transform.parent = gameObject.transform;
			radioButtons[i].transform.localPosition = Vector3.zero;

		}

		for (int i = 0; i < files.Length; i++) {

			Debug.Log (files[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
