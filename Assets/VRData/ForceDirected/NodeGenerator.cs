using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace AssemblyCSharp
{
	public class NodeGenerator
	{
		private float color = 1.0f;
		private float PI = 3.14159265f;

		public void node_generator (string[] all_data, Node[] reference, float side_length)
		{
			for (int i = 0; i < all_data.Length; i++) {

				reference [i] = new Node ();

				float theta = 2.0f * PI * UnityEngine.Random.Range(0, 1.0f);
				float phi = Mathf.Acos(1.0f - 2.0f * UnityEngine.Random.Range(0, 1.0f));
				float x = side_length * Mathf.Sin(phi) * Mathf.Cos(theta);
				float y = side_length * Mathf.Sin(phi) * Mathf.Sin(theta);
				float z = side_length * Mathf.Cos(phi);
				

				reference [i].position = new Vector3 (x, y, z);

				reference [i].node_color = new Color (UnityEngine.Random.Range (0, color),
					UnityEngine.Random.Range (0, color),
					UnityEngine.Random.Range (0, color));

				reference [i].name = all_data [i];
														

			}
		}

		public void weight_generator(string[][] source_target, Node[] reference, float side_length){

				for(int i = 0; i < reference.Length; i++){

					reference [i].weight = 1;
					reference [i].scale = 1;

					for(int j = 0; j < source_target.Length; j++){

						for(int k = 0; k < 2; k++){

							if(reference[i].name == source_target[j][k]){

								reference[i].weight++;
								reference [i].scale++ ;
							}
							

							else{

								continue;
							}
							
						reference [i].weight = Mathf.Sqrt ((side_length * side_length * side_length) / (float)reference [i].weight);

						}
					}					
				}
			}



		}
}


