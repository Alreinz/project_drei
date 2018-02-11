using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour {

    public GameObject target;
    public GameObject target2;
    public float trackSpeed;
	
	// Update is called once per frame
	void Update () {
		if ( target2 ) {
			Vector3 target1Pos = target.transform.position;
			Vector3 target2Pos = target2.transform.position;
			Vector3 middle = (target1Pos - target2Pos);
			middle.x = middle.x / 2;
			middle.y = middle.y / 2;
			Vector3 pos = transform.position;
			pos = Vector3.MoveTowards(pos,  target1Pos - middle, Time.deltaTime * trackSpeed);
			pos.z = -10;
			transform.position = pos;
		}else if ( target ) {
			Vector3 pos = transform.position;
			pos = Vector3.MoveTowards(pos, target.transform.position, Time.deltaTime * trackSpeed);
			pos.z = -10;
			transform.position = pos;
		}
	}
}
