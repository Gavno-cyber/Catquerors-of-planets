using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    public GameObject planetToCapture;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (planetToCapture.GetComponent<CaptureController>()._canspawn){
            Time.timeScale = 0;
            if (planetToCapture.GetComponent<Unit>().team == "player"){
                Debug.Log("You win!");
            }
            else
            {
                Debug.Log("You lose!");
            }
        }
    }
}
