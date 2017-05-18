using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class DataIO
	{

		public string path;

		public string[][] source_target(string path){

			return  File.ReadAllLines (@path).Select (s => s.Split (",".ToCharArray ())).ToArray ().ToArray ();
				
		}
			

		public void create_node_list(string[][] source_target, string[] all_data){

			string[] source = new string[source_target.Length]; //For Source Data
			string[] target = new string[source_target.Length]; //For Target Data

			// Creates a source list

			for (int i = 0; i < source_target.Length; i++){

				if( source.Contains(source_target[i][0])){

					continue;
				}

				else{

					source[i] = source_target[i][0];
				}
			}

			//Creates a target list 

			for (int i = 0; i < source_target.Length; i++){

				if( target.Contains(source_target[i][1])){

					continue;
				}

				else{

					target[i] = source_target[i][1];
				}
			}

			//Puts all data in a single array
			source.CopyTo(all_data,0);
			target.CopyTo(all_data, source.Length);
			all_data =  all_data.Where(v => !string.IsNullOrEmpty(v)).ToArray();
		}


		public void nodeProfile(string[][] node_info, Node[] node){

			for(int i = 0; i < node.Length; i++){

				for (int j = 0; j < node_info.Length; j++) {

					if ( node [i].name == node_info [j] [0]) {

						node [i].description = node_info [j] [1];
				
					}
				}
			}

		}

	}
}

