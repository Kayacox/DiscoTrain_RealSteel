using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Furnace : MonoBehaviour
{
    Vector3 respawnCoal = new Vector3(2.81f, 2f, 5.275f);
    Vector3 respawnIronOre = new Vector3(-20.782f, 19.465f, 6.785f);
    Vector3 respawnCopperOre = new Vector3(-5.357f, 0.726f, 9.484f);
    Vector3 respawnTinOre = new Vector3(-5.357f, 0.726f, 10.526f);
    public GameObject Processed_Iron_Ore;
    public GameObject Raw_Iron_Ore;
    public GameObject Processed_Tin_Ore;
    public GameObject Raw_Tin_Ore;
    public GameObject Processed_Copper_Ore;
    public GameObject Raw_Copper_Ore;
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

        if (other.gameObject.tag == "Coal")
        {
            Destroy(other.gameObject);
            fuelReserve += 1;
            isFired = true;
            Instantiate(Fuel, respawnCoal, Quaternion.identity);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.ToLower() == "iron ore" && isFired)
        {
            Instantiate(Raw_Iron_Ore, respawnIronOre, Quaternion.identity);
            Instantiate(Processed_Iron_Ore, (transform.position + Vector3.up * 0.6f + Vector3.left * 0.7f), Quaternion.identity);
            Destroy(other.gameObject);
        }
        if (other.gameObject.name.ToLower() == "copper" && isFired)
        {
            Instantiate(Raw_Copper_Ore, respawnCopperOre, Quaternion.identity);
            Instantiate(Processed_Copper_Ore, (transform.position + Vector3.up * 0.6f + Vector3.left * 0.7f), Quaternion.identity);
            Destroy(other.gameObject);
        }
        if (other.gameObject.name.ToLower() == "tin" && isFired)
        {
            Instantiate(Raw_Tin_Ore, respawnTinOre, Quaternion.identity);
            Instantiate(Processed_Tin_Ore, (transform.position + Vector3.up * 0.6f + Vector3.left * 0.7f), Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
