using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Sell : MonoBehaviour
{
    private string[] currentParts;
    private string[] weaponParts;
    public int score;
    S_Scroll scrollKA;
    public S_Manager manager;
    // Start is called before the first frame update
    void Start()
    {
        scrollKA = GetComponentInParent<S_Scroll>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.ToLower().Contains("sword"))
        {
            score = 0;
            S_SwordScript swordS = other.GetComponent<S_SwordScript>();
            weaponParts = swordS.parts;
            currentParts = scrollKA.currentParts;
            if (!swordS.isGrabbed)
            {
                for (int i = 0; i < currentParts.Length; i++)
                {
                    if (currentParts[i] == weaponParts[i])
                    {
                        score++;
                    }
                }
                Destroy(other.gameObject);
                manager.gold += score * 25;
                scrollKA.newParts();
            }
        }
    }
}