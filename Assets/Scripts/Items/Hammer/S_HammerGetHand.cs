using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class S_HammerGetHand : MonoBehaviour
{
    public GameObject childHammer;
    private Hand currentHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnGrab(Hand hand)
    {
        currentHand = hand;

        S_HammerAdjustment hammerscript = childHammer.GetComponent<S_HammerAdjustment>();
        if (hammerscript != null)
        {
            hammerscript.SetHand(currentHand);
        }
    }
    public void OnRelease(Hand hand)
    {
        currentHand = null;
        S_HammerAdjustment hammerscript = childHammer.GetComponent<S_HammerAdjustment>();
        if (hammerscript != null)
        {
            hammerscript.SetHand(null);
        }
    }
}
