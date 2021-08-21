using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    /*
    1��
    private Transform monstertr;
    private Transform playertr;

    private NavMeshAgent nvAgent;
    */
    public GameObject[] players;
    Transform[] PlayerTrs;
    float[] PlayerMonsterDist;

    private Transform monsterTr;
    private Transform targetTr;
    private int targerInt = 0;

    private NavMeshAgent nvAgent;

    // Start is called before the first frame update
    void Start()
    {
        /*
        1��
        monstertr = gameObject.GetComponent<Transform>();
        playertr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = gameObject.GetComponent<NavMeshAgent>();
        */
        nvAgent = GetComponent<NavMeshAgent>();

        players = GameObject.FindGameObjectsWithTag("Player");
        PlayerTrs = new Transform[players.Length];
        PlayerMonsterDist = new float[players.Length];

        for (int i = 0; i< players.Length; i++)
        {
            PlayerTrs[i] = players[i].GetComponent<Transform>();
        }

        targetTr = PlayerTrs[0];
        StartCoroutine(SearchTarget());

        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        1��
        nvAgent.destination = playertr.position;
        */
    }
    IEnumerator SearchTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            for(int i = 0; i <players.Length; i++)
            {
                PlayerMonsterDist[i] = Mathf.Abs(Vector3.Distance(PlayerTrs[i].position, this.transform.position));
            }
            targetTr = PlayerTrs[0];
            if(players.Length == 1)
            {

            }
            else
            {
                for(int i= 0; i<players.Length-1; i++)
                {
                    if(PlayerMonsterDist[targerInt] <= PlayerMonsterDist[i + 1])
                    {
                        targetTr = PlayerTrs[targerInt];
                    }
                    else
                    {
                        targerInt = i + 1;
                        targetTr = PlayerTrs[targerInt];
                    }
                }
            }
            nvAgent.destination = targetTr.position;
            targerInt = 0;
        }
    }
}
/*
 �ؾߵɰ�
 (210814)
 �÷��̾� �ټ��� ������ �ִܰ���� �÷��̾ ���󰡴� �˰���
 + https://blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=qkrghdud0&logNo=220940639773 ������ 21.08.16
 (210816)
 ���� ��Ƽ�÷��� ���������� ���������� ����
 */
