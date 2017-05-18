using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace AssemblyCSharp{

	public class Reference{

		public static Node[][] node_references{ get; set; }

	}

	
public class Main : MonoBehaviour {

		DataIO data = new DataIO ();
		NodeGenerator generator = new NodeGenerator ();
		FruchtermanReingold fruchrein = new FruchtermanReingold ();
		PointGenerator draw_nodes = new PointGenerator ();
		EdgeGenerator draw_edges = new EdgeGenerator ();
		ReferenceGenerator reference = new ReferenceGenerator ();

		string[][] data_points;
		string[][] data_info;
		string[] all_data_temp;

		public Node[] node_list;

		private GameObject[] sphere;
		private GameObject[] line;
		private LineRenderer[] lines;

		private int N = 2;

		public float plane_scale = 1000.0f;

		public Vector3 center = new Vector3 (0, 400, 0);



	// Use this for initialization
		void Start () {

			//Finds number of edges as well as inputs data to arrays to be able to mold
			data_points = data.source_target ("NodeData/edge_data_nf.csv");

			//Information about the data points
			data_info = data.source_target ("NodeData/node_data_nf.csv");

			//Finds the number of nodes, and seperates them into a seperate list which will be used to create references
			all_data_temp = new string[data_points.Length * N];
			data.create_node_list(data_points, all_data_temp);
			all_data_temp = all_data_temp.Where(v => !string.IsNullOrEmpty(v)).ToArray();
			all_data_temp = all_data_temp.Distinct ().ToArray ();


			//Generates data for the nodes given to the list that is a reference list, which gets after
			node_list = new Node[all_data_temp.Length];

			generator.node_generator (all_data_temp, node_list, plane_scale);
			generator.weight_generator (data_points, node_list, plane_scale);
			data.nodeProfile (data_info, node_list);

			Reference.node_references = new Node[data_points.Length][];

			for (int i = 0; i < data_points.Length; i++) {

				Reference.node_references [i] = new Node[N];
			}

			reference.pointers (data_points, node_list, Reference.node_references);

			sphere = new GameObject[node_list.Length];
			line = new GameObject[Reference.node_references.Length];
			lines = new LineRenderer[Reference.node_references.Length];

			//Draws Edges and Nodes
			draw_nodes.GeneratePoints (node_list, sphere);
			draw_edges.DrawEdges (Reference.node_references, lines, line);

		}


	// Update is called once per frame
		void Update () {

			fruchrein.fruchtermanreingold (Reference.node_references, node_list, plane_scale);

			for (int i = 0; i < sphere.Length; i++) {

				node_list [i].position += center - node_list [0].position;
				sphere [i].transform.position = node_list [i].position;
			}

			for (int i = 0; i < lines.Length; i++) {

				lines [i].SetPosition (0, Reference.node_references [i] [0].position);
				lines [i].SetPosition (1, Reference.node_references [i] [1].position);

				
			}
		}
	}
}
