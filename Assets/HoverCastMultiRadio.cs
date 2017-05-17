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
	string filepath;
	string path;
	string OS;


	// Use this for initialization
	void Start () {

		OS = Environment.OSVersion.ToString ();
		path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

		if (OS.Contains ("Unix")) {

			if (Directory.Exists(path + "/Documents/Projects/")) {

				filepath = path + "/Documents/Projects/";

			} else{

				Directory.CreateDirectory (path + "/Documents/Projects");
				filepath = path + "/Documents/Projects/";
			}

		} else {

			if (Directory.Exists(path + "/Projects/")) {

						filepath = path + "/Projects/";

					} else{

						Directory.CreateDirectory (path + "/Projects/");
						filepath = path + "/Projects/";
					}
		}

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

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
