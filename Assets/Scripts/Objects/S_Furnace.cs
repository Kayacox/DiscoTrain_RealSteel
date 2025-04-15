using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Furnace : MonoBehaviour
{
    Vector3 myVector = new Vector3(2.81f, 2f, 5.275f);
    Vector3 respawnOre = new Vector3(-12.54f, 19.881f, 2f);
    public GameObject Processed_Ore;
    public GameObject Raw_Ore;
    public GameObject Fuel;
    public bool isFired = false;
    public int fuelReserve = 0;
    public bool reduceFireTime = true;

    IEnumerator fireDelay()
    {
        reduceFireTime = false;
        isFired = true;
        yield return new WaitForSecondsRealtime(20);
        fuelReserve -= 1;
        isFired = false;
        reduceFireTime = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (reduceFireTime && fuelReserve > 0)
        {
            StartCoroutine(fireDelay());
        }
    }
private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RawOre" && isFired)
        {
            Instantiate(Raw_Ore, respawnOre, Quaternion.identity);
            Instantiate(Processed_Ore, respawnOre, Quaternion.identity);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Coal")
        {
            Destroy(other.gameObject);
            fuelReserve += 1;
            isFired = true;
            Instantiate(Fuel, myVector, Quaternion.identity);
        }
    }
}
