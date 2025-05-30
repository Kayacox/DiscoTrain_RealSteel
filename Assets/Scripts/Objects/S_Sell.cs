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
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.CompareTag("Sword"))
        {
            
            S_SwordScript swordS = other.GetComponent<S_SwordScript>();
            weaponParts = swordS.parts;
            currentParts = scrollKA.currentParts;
            currentParts[1] = "Diamond";
            currentParts[2] = "Diamond";
            Debug.Log("Pre grab");
            if (!swordS.isGrabbed)
            {
                Debug.Log("not grabbed");
                Debug.Log($"currentParts.Length: {currentParts.Length}");
                Debug.Log($"weaponParts.Length: {weaponParts.Length}");
                for (int i = 0; i < currentParts.Length; i++)
                {
                    Debug.Log($"Index {i}: currentParts[{i}] = {currentParts[i]}, weaponParts[{i}] = {weaponParts[i]}");
                    Debug.Log($"loop {i}, currentPart: {currentParts[i]}, weaponPart: {weaponParts[i]}");
                    if (currentParts[i] == weaponParts[i])
                    {
                        score++;
                        Debug.Log("same");
                    }
                }
                Debug.Log("nope");
                Destroy(other.gameObject);
                manager.gold += score * 25;
                scrollKA.newParts();
            }
        }
    }
}