using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour {

    public GameObject target;
    public float trackSpeed;
	
	// Update is called once per frame
	void Update () {
		if ( target ) {
			Vector3 pos = transform.position;
			pos = Vector3.MoveTowards(pos, target.transform.position, Time.deltaTime * trackSpeed);
			pos.z = -10;
			transform.position = pos;
		} else {
			Vector3 pos = transform.position;
			pos = Vector3.MoveTowards(pos, new Vector3(0, 5, 0), Time.deltaTime * trackSpeed);
			pos.z = -10;
			transform.position = pos;
		}
	}
}
