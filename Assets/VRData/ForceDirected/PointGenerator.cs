using System;
using UnityEngine;

namespace AssemblyCSharp
{

	public class PointGenerator
	{
		DataIO description = new DataIO();
		float scale;

		public void GeneratePoints(Node[] node, GameObject[] sphere){


			for (int i = 0; i < node.Length; i++) {

				sphere [i] = GameObject.CreatePrimitive (PrimitiveType.Sphere);
				sphere [i].AddComponent<ProfileData> ().profile = node [i].description;
				sphere [i].tag = "Node";
				sphere [i].name = node [i].name;

				scale = node [i].scale/ 4.0f;

				sphere [i].transform.localScale = new Vector3 (scale, scale, scale);
				sphere [i].GetComponent<Renderer> ().material.color = node [i].node_color;
				sphere [i].transform.position = node [i].position;


			}
				

		}

	}
}

