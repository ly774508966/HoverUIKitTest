using System;

namespace AssemblyCSharp
{
	public class ReferenceGenerator
	{
		public void pointers(string[][] raw_data, Node[] all_data, Node[][] source_target){

			for (int i = 0; i < raw_data.Length; i++){

				for(int j = 0; j < 2; j++){

					for(int k = 0; k < all_data.Length; k++){

						if(raw_data[i][j] == all_data[k].name){

							source_target[i][j] = new Node();
							source_target[i][j] = all_data[k];
						}

						else{

							continue;
						}
					}
				}
			}
		}
	}
}

