using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public GameObject preButton;
    public GameObject actButton;
    
    public GameObject thisObject;
    void Start()
    {
        preButton = GameObject.Find("PrepareButton");
        actButton = GameObject.Find("ActiveButton");
    }


    // Update is called once per frame
    void Update()
    {
        switch (thisObject.name)
        {
            case "Active":
                thisObject.SetActive(!actButton.GetComponent<IncActive>().isActive);
                return;
            case "Cooldown":
                thisObject.SetActive(!actButton.GetComponent<IncActive>().isCooldown);
                return;
            case "Prepare":
                thisObject.SetActive(!preButton.GetComponent<IncPrepare>().isPrepared);
                return;
        }
    }
}
