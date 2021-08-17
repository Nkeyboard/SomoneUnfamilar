using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
    GameObject player;
    GameObject Door;

    // Start is called before the first frame update
    void Start()
    {
        Door = GameObject.Find("Field").transform.Find("Door").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Door.activeSelf)
            {
                Door.SetActive(false);
            }
            else if (!Door.activeSelf)
            {
                Door.SetActive(true);
            }
        }
    }
}
