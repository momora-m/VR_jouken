using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour {
    public float baseScale;
    public float scaleParRange;

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
        //lineRenderer.SetPosition(1, new Vector3(0,100,0));

        if(Physics.Raycast(transform.position,transform.transform.up,out hit, Mathf.Infinity))
        {
            meshRenderer.enabled = true;
            meshRenderer.transform.position = hit.point;
            //meshRenderer.transform.localScale = new Vector3 (baseScale + transform.localPosition.x * scaleParRange, baseScale + transform.localPosition.y * scaleParRange, baseScale + transform.localPosition.z * scaleParRange);
        }
        else
        {
            meshRenderer.enabled = false;
        }
    }
}
