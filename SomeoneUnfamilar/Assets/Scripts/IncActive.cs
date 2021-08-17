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

    public bool activeShutdown;


    void Start()
    {
        preButton = GameObject.Find("PrepareButton");
        actButton = GameObject.Find("ActiveButton");
        IncZone = GameObject.Find("IncinerateZone");
        isCooldown = false;
        isActive = false;
        activeShutdown = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isCooldown)
        //{
        //    StartCoroutine(Cooldown());
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(preButton.GetComponent<IncPrepare>().isPrepared && !isCooldown && !isActive)
            {
                Debug.Log("�Ұ��� �۵�����");
                isActive = true;
                StartCoroutine(ShutdownCount());
            }
        }
    }

    IEnumerator ShutdownCount()
    {
        yield return new WaitForSeconds(2f);    // 2�ʰ� �Ұ� ����
        activeShutdown = true;
        Debug.Log("�Ұ�����");

        isCooldown = true;
        Debug.Log("�ð�����");
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2f);    // 2�ʰ� �ð�

        isCooldown = false;
        Debug.Log("�ð�����");
        preButton.GetComponent<IncPrepare>().isPrepared = false;
        isActive = false;
        Debug.Log("false");
    }
}
