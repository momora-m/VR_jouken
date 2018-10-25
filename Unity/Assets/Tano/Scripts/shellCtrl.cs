using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleShooting
{
    public class shellCtrl : MonoBehaviour {

        [SerializeField] float destroyTime = 2;

        AudioSource audioSource;

	    void Start () {
            audioSource = GetComponent<AudioSource>();

            Destroy(gameObject, destroyTime);
	    }

        private void OnCollisionEnter(Collision collision)
        {
            audioSource.Play();
        }
    }
}


