using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour {
    LineRenderer lineRenderer;
    MeshRenderer meshRenderer;
	// Use this for initialization
	void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        meshRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        lineRenderer.SetPosition(1, new Vector3(0,100000,0));

        if(Physics.Raycast(transform.position,transform.transform.up,out hit, Mathf.Infinity))
        {
            meshRenderer.enabled = true;
            meshRenderer.transform.position = hit.point;
        }
        else
        {
            meshRenderer.enabled = false;
        }
    }
}
