using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Light;

    void Start()
    {
        //Light = GameObject.Find("Lights").transform.Find("Light1").gameObject;  // 활성화된 Empty 안의 비활성화된 오브젝트 찾기
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
