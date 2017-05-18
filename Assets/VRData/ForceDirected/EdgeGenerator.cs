using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class EdgeGenerator
	{
		private float alpha = 1.0f;

		public void DrawEdges(Node[][] node_references, LineRenderer[] lines, GameObject[] line){

			for(int i = 0; i < node_references.Length; i++){

				line [i] = new GameObject (node_references [i] [0].name + "." + node_references [i] [1].name);
				lines [i] = line [i].AddComponent<LineRenderer> ();
				lines [i].widthMultiplier = 0.5f;
				lines [i].material = new Material (Shader.Find ("Particles/Additive"));
				Gradient gradient = new Gradient ();
				gradient.SetKeys (
					new GradientColorKey[] {
						new GradientColorKey (node_references [i] [0].node_color, 0.0f),
						new GradientColorKey (node_references [i] [1].node_color, 1.0f)},
					new GradientAlphaKey[]{ 
						new GradientAlphaKey (alpha, 0.0f), 
						new GradientAlphaKey (alpha, 1.0f) });
				
				lines [i].colorGradient = gradient;
				lines [i].SetPosition (0, node_references [i] [0].position);
				lines [i].SetPosition (1, node_references [i] [1].position);

		
			}


		}
	}
}
