using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

namespace AssemblyCSharp
{
	public class Node
	{
		public Vector3 position;
		public Vector3 displacement;
		public Color node_color;
		public string name;
		public string description;
		public float weight;
		public float scale;



		public Node ()
		{
			name = "N/A";

		}

		public Node (Vector3 position, Color node_color, string name, string description, int weight )
		{
			this.position = position;
			this.node_color = node_color;
			this.description = description;
			this.weight = weight;

		}

		//For Debugging Purposes 

		public void PrintChild(){

			Console.WriteLine ("{0}, {1}, {2}, {3}", position, name, description, weight);
		}
	}	
}
