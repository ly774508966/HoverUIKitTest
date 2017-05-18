using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace AssemblyCSharp
{

	 

	public class FruchtermanReingold
	{


		private float mag;
		private float spring;
		private float j = 0;

		private Vector3 diff;

		private float t = 0.9f;

		private float fa(ref float x){

			return (x * x) / spring;
		}

		private float fr(ref float x){

			return (spring * spring) / x;
		}

		public void fruchtermanreingold(Node[][] node_references, Node[] node_list, float plane_scale){

			spring = Mathf.Sqrt (plane_scale * plane_scale * plane_scale / node_list.Length);

				t = 1.0f - (float)j / (float)50000;
				t *= t;
				j++;

				for (int i = 0; i < node_list.Length; i++) {

					node_list [i] .displacement = new Vector3 (0.0f, 0.0f, 0.0f);

					for (int k = 0; k < node_list.Length; k++) {

						if (i != k) {

							diff = node_list [i].position - node_list [k].position;

							mag = diff.magnitude;

							if (mag != 0) {

								node_list [i].displacement +=  diff / diff.magnitude * fr (ref mag);

							}
						}
					}
				}
				
				
				for (int i = 0; i < node_references.Length; i++) {

					diff = node_references [i] [0].position - node_references [i] [1].position;

					mag = diff.magnitude;

					node_references [i] [0].displacement -=  diff  * fa (ref mag) * node_references [i] [0].weight;
					
					node_references [i] [1].displacement +=  diff  * fa (ref mag) * node_references [i] [0].weight;


				}
				
				for (int i = 0; i < node_list.Length; i++) {

					node_list[i].position = node_list[i].position + node_list[i].displacement / node_list[i].displacement.magnitude 
							* Mathf.Min(node_list[i].displacement.magnitude,t);

					node_list[i].position.x = Mathf.Min(plane_scale/2.0f, Mathf.Max(-plane_scale/2.0f, node_list[i].position.x));
					node_list[i].position.y = Mathf.Min(plane_scale/2.0f, Mathf.Max(-plane_scale/2.0f, node_list[i].position.y));
					node_list[i].position.z = Mathf.Min(plane_scale/2.0f, Mathf.Max(-plane_scale/2.0f, node_list[i].position.z));


				}


			}

		
		}

	}
//}

