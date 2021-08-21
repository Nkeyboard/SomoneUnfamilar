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
        Debug.Log("�Ұ��� �غ����");
        yield return new WaitForSeconds(2f);    // 2�ʰ� �غ�
        Debug.Log("�Ұ��� �غ�Ϸ�");
        isPrepared = true;
    }
}
