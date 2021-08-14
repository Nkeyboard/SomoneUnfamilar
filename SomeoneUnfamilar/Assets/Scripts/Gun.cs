using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum State
    {
        Ready,
        Empty
    }

    public State state { get; private set; }

    public Transform fireTransfrom;

    private AudioSource gunAudioPlayer;
    public AudioClip shotClip;

    public float damage = 2;

    public int ammoMax = 60;
    public int ammoCurr = 60;

    public float timeBetFire = 0.5f;
    private float lastFireTime;

    private void Awake()
    {
        gunAudioPlayer = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        state = State.Ready;
        lastFireTime = 0;
    }

    public void Fire()
    {
        if(state == State.Ready && Time.time >= lastFireTime + timeBetFire)
        {
            lastFireTime = Time.time;
            Shot();
        }
    }

    public void Shot()
    {
        RaycastHit hit;
        Vector3 hitPosition = Vector3.zero;

        if(Physics.Raycast(fireTransfrom.position,fireTransfrom.forward, out hit){
            IDamageable target = hit.collider.GetComponent<IDamageable>();

            if(target != null)
            {
                target.OnDamage(damage, hit.point, hit.normal);
            }

            hitPosition = hit.point;
        }

        StartCoroutine(ShotEffect(hitPosition));

        ammoCurr--;
        if(ammoCurr <= 0)
        {
            state = State.Empty;
        }
    }

    private IEnumerator ShotEffect(Vector3 hitPosition)
    {

        yield return new WaitForSeconds(0.03f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
