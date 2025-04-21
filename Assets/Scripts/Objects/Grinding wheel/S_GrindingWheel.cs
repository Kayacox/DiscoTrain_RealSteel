using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GrindingWheel : MonoBehaviour
{
    private bool playerIsNear = false;
    public Transform wheel;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsNear) 
        {
            wheel.Rotate(new Vector3(0, 20, 0) * Time.deltaTime * 20);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        playerIsNear = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.IsChildOf(player))
        {
            playerIsNear = true;
        }
    }
}
