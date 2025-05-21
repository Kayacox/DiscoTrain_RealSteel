using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class S_SwordScript : Interactable
{
    public bool soaked = false;
    private HashSet<Collider> currentTriggers = new HashSet<Collider>();
    public int TriggerCount => currentTriggers.Count;
    public string[] parts;

    public bool isGrabbed = false;
    // Start is called before the first frame update
    protected override void Start()
    {
        parts = new string[] {"Iron", "Round", "Cross", "Leather"};
    }

    // Update is called once per frame
    protected override void Update()
    {
        
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
