using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncPrepare : MonoBehaviour
{
    public GameObject preButton;
    public GameObject actButton;

    public GameObject IncZone;

    public bool isPrepared;

    
    void Start()
    {
        preButton = GameObject.Find("PrepareButton");
        actButton = GameObject.Find("ActiveButton");
        IncZone = GameObject.Find("IncinerateZone");
        isPrepared = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!isPrepared && 
                !actButton.GetComponent<IncActive>().isCooldown && 
                !actButton.GetComponent<IncActive>().isActive)
            {
                StartCoroutine(Prepare());
            }
        }
    }
    
    IEnumerator Prepare()
    {
        Debug.Log("소각장 준비시작");
        yield return new WaitForSeconds(2f);    // 2초간 준비
        Debug.Log("소각장 준비완료");
        isPrepared = true;
    }
}
