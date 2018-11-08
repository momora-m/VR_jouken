using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleShooting
{
    public class PlayerOffsetCtrl : MonoBehaviour {
        [SerializeField] float moveVal;
        [SerializeField] float rotateVal;
	
	    void Update () {
            //位置調整
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(moveVal * Time.deltaTime, 0, 0, Space.World);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-moveVal * Time.deltaTime, 0, 0, Space.World);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, 0, moveVal * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, 0, -moveVal * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0,rotateVal * Time.deltaTime,0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -rotateVal * Time.deltaTime, 0);
            }
        }
    }
}

