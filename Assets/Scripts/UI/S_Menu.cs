using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Menu : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("RealSteelScene");
    }
}
