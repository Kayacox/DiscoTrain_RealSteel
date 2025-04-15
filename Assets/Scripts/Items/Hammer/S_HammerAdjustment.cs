using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class S_HammerAdjustment : MonoBehaviour
{
    private Hand currentHand;
    private bool left = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHand(Hand hand)
    {
        currentHand = hand;
        CheckHoldingHand();
    }

    void CheckHoldingHand()
    {
        if (currentHand != null)
        {
            if (currentHand.handType == SteamVR_Input_Sources.LeftHand && !left)
            {
                left = true;
                transform.localPosition = new Vector3(-0.019f, 0.008f, 0.011f);
                transform.localRotation = Quaternion.Euler(-0.125f, 28.186f, -390.431f);
            }
            else if (currentHand.handType == SteamVR_Input_Sources.RightHand && left)
            {
                left = false;
                transform.localPosition = new Vector3(0.019f, -0.008f, -0.011f);
                transform.localRotation = Quaternion.Euler(0.125f, -28.186f, 390.431f);
            }
        }
    }
}
