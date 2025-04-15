using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class LaserInput : MonoBehaviour
{
    public static GameObject currentObject;
    int currentID;

    // Start is called before the first frame update
    void Start()
    {
        currentObject = null;
        currentID = 0;
    }

    void Update()
    {
        // Sends out a Raycast and returns an array filled with everything it hit 
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);

        // Goes through all the hit objects and checks if any of them were our button 
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];

            // Use the object Id to determine if I have already run the code for this object 
            int id = hit.collider.gameObject.GetInstanceID();

            // If I haven't then I will run it again but If I have it is unnecessary to keep running it 
            if (currentID != id)
            {
                currentID = id;
                currentObject = hit.collider.gameObject;

                // Checks based off the tag
                string tag = currentObject.tag;
                if (tag == "Button" && SteamVR_Actions.default_InteractUI.GetStateDown(SteamVR_Input_Sources.RightHand)) // Check for trigger input
                {
                    ExecuteEvents.Execute(currentObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                }
            }
        }
    }
}