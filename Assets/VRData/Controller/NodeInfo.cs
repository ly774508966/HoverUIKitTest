using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

using AssemblyCSharp;

namespace Controllers{

	public class NodeInfo {

		private string information = System.String.Empty;

		public void Display(GameObject canvas, string name){

			Canvas info = canvas.AddComponent<Canvas> ();
			info.renderMode = RenderMode.WorldSpace;
			CanvasScaler cs = canvas.AddComponent<CanvasScaler> ();
			cs.scaleFactor = 20.0f;
			cs.dynamicPixelsPerUnit = 20f;
			canvas.GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, 3.0f);
			canvas.GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, 3.0f);
			canvas.name = name;

		}

		public void ControllerInformation(string info, Transform trans, string name){

			GameObject info_text = new GameObject ();
			info_text.name = name;
			info_text.transform.parent = trans;
			Text text = info_text.AddComponent<Text> ();
			info_text.GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, 10.0f);
			info_text.GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, 3.0f);
			text.alignment = TextAnchor.MiddleCenter;
			text.horizontalOverflow = HorizontalWrapMode.Wrap;
			text.verticalOverflow = VerticalWrapMode.Overflow;
			Font ArialFont = (Font)Resources.GetBuiltinResource (typeof(Font), "Arial.ttf");
			text.font = ArialFont;
			text.fontSize = 1;
			text.text = info; 
			text.enabled = true;
			text.color = Color.green;


		}


		public void Information(string info, Transform trans, string name){

			GameObject info_text = new GameObject ();
			info_text.name = name;
			info_text.transform.parent = trans;
			Text text = info_text.AddComponent<Text> ();
			info_text.GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, 10.0f);
			info_text.GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, 3.0f);
			text.alignment = TextAnchor.MiddleCenter;
			text.horizontalOverflow = HorizontalWrapMode.Wrap;
			text.verticalOverflow = VerticalWrapMode.Overflow;
			Font ArialFont = (Font)Resources.GetBuiltinResource (typeof(Font), "Arial.ttf");
			text.font = ArialFont;
			text.fontSize = 1;
			text.text = info; 
			text.enabled = true;
			text.color = Color.green;

		}

		public void Connection(string info, Transform trans, string name){

			GameObject info_text = new GameObject ();
			info_text.name = name;
			info_text.transform.parent = trans;
			Text text = info_text.AddComponent<Text> ();
			info_text.GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, 10.0f);
			info_text.GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, 3.0f);
			text.alignment = TextAnchor.MiddleCenter;
			text.horizontalOverflow = HorizontalWrapMode.Wrap;
			text.verticalOverflow = VerticalWrapMode.Overflow;
			text.supportRichText = true;
			Font ArialFont = (Font)Resources.GetBuiltinResource (typeof(Font), "Arial.ttf");
			text.font = ArialFont;
			text.fontSize = 1;
			text.text = info; 
			text.enabled = true;

		}

		string ColorToHex(Color32 color)
		{
			string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
			return " <color=#" + hex + ">";
		}
			

		public string ColorCoding(string node_name, Node[][] node_references){

			if (!information.Contains (node.node_name) && (node.node_name != null) && (information != null)) {

				for (int i = 0; i < Reference.node_references.Length; i++) {

					if (Reference.node_references [i] [0].name.Contains(node.node_name)) {

						information += ColorToHex (Reference.node_references [i] [1].node_color) +
						Reference.node_references [i] [1].name + "</color> \n";  
					} 

					else if(Reference.node_references [i] [1].name.Contains(node.node_name)){

						information += ColorToHex (Reference.node_references [i] [0].node_color) +
						Reference.node_references [i] [0].name + "</color> \n";  

					}

				}
			}

			return information;
		}
	}
}
