using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Furnace : MonoBehaviour
{
    Vector3 myVector = new Vector3(0.4f, 0.08f, 5.7f);
    public GameObject Processed_Ore;
    public GameObject Fuel;
    private bool isFired = false;
    public int fuelReserve = 0;
    private bool reduceFireTime;

    IEnumerator fireDelay()
    {
        reduceFireTime = false;
        yield return new WaitForSecondsRealtime(20);
        fuelReserve -= 1;
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
            fireDelay();
        }
        Debug.Log(isFired);
    }
private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RawOre" && isFired)
        {
            Instantiate(Processed_Ore, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "Coal")
        {
            Destroy(other.gameObject);
            fuelReserve += 1;
            isFired = true;
            Instantiate(Fuel, myVector, Quaternion.identity);
        }
        while (fuelReserve > 0)
        {
            fuelReserve -= 1;
            if (fuelReserve == 0)
            {
                isFired = false;
            }
            
        }
    }
}
