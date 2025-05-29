using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class S_Scroll : MonoBehaviour
{
    private SteamVR_Behaviour_Pose pose;
    private SteamVR_Action_Boolean grabAction;
    public GameObject gameManager;

    string[][] possibleParts;
    public string[] currentParts;
    S_Manager manager;
    int rightParts = 0;
    // Start is called before the first frame update
    void Start()
    {
        possibleParts = new string[4][];
        currentParts = new string[4];
        possibleParts[0] = new string[] {"Iron", "Copper", "Tin"};
        possibleParts[1] = new string[] {"Round", "Diamond", "Cone"};
        possibleParts[2] = new string[] {"Cross", "Circle", "Diamond"};
        possibleParts[3] = new string[] {"Leather"};
  
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        grabAction = SteamVR_Actions.default_GrabGrip;
        manager = gameManager.GetComponent<S_Manager>();
 
        newParts();
    }

    // Update is called once per frame
    void Update()
    {
        if (pose != null) 
        {
            if (grabAction.GetStateDown(pose.inputSource)) // Called when grabbed
            {
                OnGrab();
            }
            else if (grabAction.GetStateUp(pose.inputSource)) // Called when released
            {
                OnRelease();
            }
        }
    }

    public void newParts() 
    {
        int randomIndex, arrCount, arrIndex = 0;
        Array.Clear(currentParts, 0, currentParts.Length);
        
        foreach (string[] part in possibleParts)
        {
            arrCount = part.Length;
            randomIndex = UnityEngine.Random.Range(0, arrCount);
            currentParts[arrIndex] = part[randomIndex];
            arrIndex++;
        }
    }

    private void OnGrab() { }
    
    private void OnRelease() { }
}
