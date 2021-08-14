using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    private Transform monstertr;
    private Transform playertr;
    private NavMeshAgent nvAgent;
    // Start is called before the first frame update
    void Start()
    {
        monstertr = gameObject.GetComponent<Transform>();
        playertr = GameObject.FindWithTag("Player").GetComponent<Transform>();

        nvAgent = gameObject.GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        nvAgent.destination = playertr.position;
    }
}
/*
 �ؾߵɰ�(210814)
 �÷��̾� �ټ��� ������ �ִܰ���� �÷��̾ ���󰡴� �˰���
 */