using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class S_SwordScript : Interactable
{
    public bool soaked = false;
    private HashSet<Collider> currentTriggers = new HashSet<Collider>();
    public int TriggerCount => currentTriggers.Count;
    public string[] parts;
    public GameObject RPommel;
    public GameObject DPommel;
    public GameObject CGuard;
    public GameObject DGuard;

    Renderer RPRend;
    Renderer DPRend;
    Renderer CGRend;
    Renderer DGRend;

    bool pommel;
    bool guard;

    public bool isGrabbed = false;
    public bool isWrapped;
    private bool hasBeenWrapped;
    // Start is called before the first frame update
    protected override void Start()
    {

        string lowerName = gameObject.name.ToLower().Trim();
        pommel = false;
        guard = false;
        isWrapped = false;
        hasBeenWrapped = false;
        parts = new string[4];
        if (lowerName.Contains("tin"))
            parts[0] = "Tin";
        else if (lowerName.Contains("iron"))
            parts[0] = "Iron";
        else if (lowerName.Contains("copper"))
            parts[0] = "Copper";
        else
        {
            parts[0] = "Unknown";
            Debug.LogWarning("Unknown sword material: " + gameObject.name);
        }
        parts[1] = "Diamond";
        parts[2] = "Diamond";

        foreach (char c in lowerName)
        {
            Debug.Log("Character: '" + c + "'");  // Check for any unexpected characters
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (isWrapped && !hasBeenWrapped)
        {
            parts[3] = "Leather";
            hasBeenWrapped = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            currentTriggers.Add(other);
        }
        if (other.gameObject.name.Contains("Soak"))
        {
            soaked = true;
        }
        /*if (other.gameObject == RPommel && !pommel)
        {
            RPRend.enabled = true;
            pommel = true;
            parts[1] = "Round";
            Destroy(other.gameObject);
            Instantiate(other.gameObject, new Vector3(-3.742f, 1.238f, -0.959f), Quaternion.identity);
        }
        if (other.gameObject == DPommel && !pommel) 
        { 
            DPRend.enabled = true;
            pommel = true;
            parts[1] = "Diamond";
            Destroy(other.gameObject);
            Instantiate(other.gameObject, new Vector3(-3.41604f, 1.239f, -0.987f), Quaternion.identity);
        }
        if (other.gameObject == CGuard && !guard) 
        {
            CGRend.enabled = true;
            guard = true;
            parts[3] = "Curved";
            Destroy(other.gameObject);
            Instantiate(other.gameObject, new Vector3(-3.41604f, 1.227f, -1.202f), Quaternion.identity);
        }
        if (other.gameObject == DGuard && !guard) 
        { 
            DGRend.enabled = true;
            guard = true;
            parts[3] = "Curved";
            Destroy(other.gameObject);
            Instantiate(other.gameObject, new Vector3(-3.721f, 1.226f, -1.25f), Quaternion.identity);
        }*/
    }
    private void OnTriggerExit(Collider other)
    {
        currentTriggers.Remove(other);
    }

    protected override void OnAttachedToHand(Hand hand)
    {
        base.OnAttachedToHand(hand);
        isGrabbed = true;
    }

    protected override void OnDetachedFromHand(Hand hand)
    {
        base.OnDetachedFromHand(hand);
        isGrabbed = false;
    }
}
