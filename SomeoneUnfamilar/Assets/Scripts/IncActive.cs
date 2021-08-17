using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncActive : MonoBehaviour
{
    public GameObject preButton;
    public GameObject actButton;

    public GameObject IncZone;

    public bool isCooldown;
    public bool isActive;


    void Start()
    {
        preButton = GameObject.Find("PrepareButton");
        actButton = GameObject.Find("ActiveButton");
        IncZone = GameObject.Find("IncinerateZone");
        isCooldown = false;
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(preButton.GetComponent<IncPrepare>().isPrepared && !isCooldown && !isActive)
            {
                Debug.Log("소각장 작동시작");
                isActive = true;
            }
        }
    }
}
