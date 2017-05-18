using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controllers;


namespace Menu{

	public class HelpInformationDisplay {

		NodeInfo Information = new NodeInfo ();
		HelpInformation InfoText = new HelpInformation ();


		public void DisplayInformation(GameObject[] canvas, string[] ControllerInfo){

			for (int i = 0; i < ControllerInfo.Length; i++) {

				Information.Display (canvas [i], "ControllerHelp");

				Information.ControllerInformation (ControllerInfo [i], canvas [i].transform, "ControllerHelp");


			}


		}


	}
}
