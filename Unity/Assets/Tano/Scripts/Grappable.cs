using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace SimpleShooting
{  
    public class Grappable : MonoBehaviour
    {
        [EnumFlags]
        [Tooltip("The flags used to attach this object to the hand.")]
        public Hand.AttachmentFlags attachmentFlags = Hand.AttachmentFlags.ParentToHand | Hand.AttachmentFlags.DetachFromOtherHand | Hand.AttachmentFlags.TurnOnKinematic;

        public SteamVR_Action_Boolean GrabButton;

        public Interactable interactable;

        // Use this for initialization
        void Awake()
        {
            interactable = GetComponent<Interactable>();
        }

        protected virtual void OnHandHoverBegin(Hand hand)
        {
            GrabTypes startingGrabType = hand.GetGrabStarting();

            if (startingGrabType != GrabTypes.None)
            {
                hand.AttachObject(gameObject, GrabTypes.Trigger, attachmentFlags, interactable.handFollowTransform);
                hand.HideGrabHint();
            }
        }

        protected virtual void HandHoverUpdate(Hand hand)
        {
            GrabTypes startingGrabType = hand.GetGrabStarting();

            if (startingGrabType != GrabTypes.None)
            {
                hand.AttachObject(gameObject,GrabTypes.Trigger,attachmentFlags,  interactable.handFollowTransform);
                hand.HideGrabHint();
            }
        }

        protected virtual void HandAttachedUpdate(Hand hand)
        {


            if (GrabButton.GetStateDown(hand.handType) )
            {
                hand.DetachObject(gameObject, false);
            }
        }



    }
}

