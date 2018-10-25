using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SimpleShooting
{
    public class Destroyable : MonoBehaviour {

        public UnityEvent whenHit;

	    // Use this for initialization
	    void Start () {
		
	    }
	
	    // Update is called once per frame
	    void Update () {
		
	    }

        public void Hit()
        {
            whenHit.Invoke();
            Destroy(gameObject,0.05f);
        }

    }
}
