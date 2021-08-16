using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    /*
    1번
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
        1번
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
        1번
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
 해야될거
 (210814)
 플레이어 다수가 있을때 최단경로의 플레이어를 따라가는 알고리즘
 + https://blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=qkrghdud0&logNo=220940639773 참고함 21.08.16
 (210816)
 포톤 멀티플레이 적용했을때 문제없도록 수정
 */
