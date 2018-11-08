using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


namespace SimpleShooting
{
    public class MachineGun : GunBase {

	
	    // Update is called once per frame
	    override protected void Update () {

            //握られていたら
            if (interactable.attachedToHand)
            {

                //thisHandに現在握っている手を代入
                hand = interactable.attachedToHand;

                if (FireButton.GetState(hand.handType))
                {
                    Fire();
                }
            }
        }
    }
}
