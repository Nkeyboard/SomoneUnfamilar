using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Light;

    void Start()
    {
        //Light = GameObject.Find("Lights").transform.Find("Light1").gameObject;  // Ȱ��ȭ�� Empty ���� ��Ȱ��ȭ�� ������Ʈ ã��
        //Light = GameObject.Find("Lights");
        Light = GameObject.Find("Lights").transform.Find("Lights1").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            Light.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            Light.SetActive(false);
        }
    }
}
