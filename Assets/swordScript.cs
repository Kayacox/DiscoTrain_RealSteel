using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class swordScript : MonoBehaviour
{
    private Interactable interacts;
    // Start is called before the first frame update
    void Start()
    {
        interacts = GetComponent<Interactable>();
    }
    private void LateUpdate()
    {
        if (interacts.attachedToHand!=null)
        {
            SteamVR_Input_Sources source = interacts.attachedToHand.handType;
            Debug.Log("Source: " + source.ToString());
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
