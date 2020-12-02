using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
	void Update()
	{
		Vector3 p = Camera.main.transform.position;
		p.z = p.z * -1;
		transform.LookAt(p);
	}
}
