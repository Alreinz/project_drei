using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour {

    public GameObject target;
    public float trackSpeed;
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos = Vector3.MoveTowards(pos, target.transform.position, Time.deltaTime * trackSpeed);
        pos.z = -10;
        transform.position = pos;
	}
}
