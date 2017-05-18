using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Controllers;

namespace AssemblyCSharp{

public class Pointer{

		public enum AxisType
		{
			XAxis,
			ZAxis
		}
			
		public AxisType facingAxis = AxisType.ZAxis;

		public bool showCursor = true;



		public float GetBeamLength(bool bHit, RaycastHit hit, float length, float contactDistance, Transform contactTarget)
		{
			float actualLength = length;

			//reset if beam not hitting or hitting new target
			if (!bHit || (contactTarget && contactTarget != hit.transform))
			{
				contactDistance = 0f;
				contactTarget = null;
			}

			//check if beam has hit a new target
			if (bHit)
			{
				if (hit.distance <= 0)
				{

				}
				contactDistance = hit.distance;
				contactTarget = hit.transform;
			}

			//adjust beam length if something is blocking it
			if (bHit && contactDistance < length)
			{
				actualLength = contactDistance;
			}

			if (actualLength <= 0)
			{
				actualLength = length;
			}

			return actualLength; ;
		}

		public void SetPointerTransform(float setLength, float setThicknes, GameObject pointer, GameObject cursor)
		{
			//if the additional decimal isn't added then the beam position glitches
			float beamPosition = setLength / (2 + 0.00001f);

			if (facingAxis == AxisType.XAxis)
			{
				pointer.transform.localScale = new Vector3(setLength, setThicknes, setThicknes);
				pointer.transform.localPosition = new Vector3(beamPosition, 0f, 0f);
				if (showCursor)
				{
					cursor.transform.localPosition = new Vector3(setLength - cursor.transform.localScale.x, 0f, 0f);
				}
			}

			else
			{
				pointer.transform.localScale = new Vector3(setThicknes, setThicknes, setLength);
				pointer.transform.localPosition = new Vector3(0f, 0f, beamPosition);

				if (showCursor)
				{
					cursor.transform.localPosition = new Vector3(0f, 0f, setLength - cursor.transform.localScale.z);
				}
			}
		}
		
		}
}


