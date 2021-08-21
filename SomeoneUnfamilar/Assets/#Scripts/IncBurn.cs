using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncBurn : MonoBehaviour
{
    public GameObject preButton;
    public GameObject actButton;

    public GameObject IncZone;
    

    void Start()
    {
        preButton = GameObject.Find("PrepareButton");
        actButton = GameObject.Find("ActiveButton");
        IncZone = GameObject.Find("IncinerateZone");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (/*!preButton.GetComponent<IncPrepare>().isPrepared &&*/ 
            actButton.GetComponent<IncActive>().isActive /*&& 
            !actButton.GetComponent<IncActive>().isCooldown &&
            !actButton.GetComponent<IncActive>().activeShutdown*/){
            Debug.Log(other + "¼Ò°¢");
            Destroy(other.gameObject);
        }
    }
}
