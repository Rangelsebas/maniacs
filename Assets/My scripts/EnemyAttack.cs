using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject chaseMusic; 
    [SerializeField] Animator anim;
    [SerializeField] Transform player;
    [SerializeField] GameObject enemy;
    [SerializeField] int maxChecks = 3;
    [SerializeField] float maxRange = 35.0f;
    [SerializeField] float chaseSpeed = 5.0f ;
    [SerializeField] float walkSpeed = 1.6f;
    [SerializeField] float attackDistance = 2.3f;
    [SerializeField] float attackRotateSpeed = 2.0f;
    [SerializeField] float checkTime = 3.0f;
    [SerializeField] GameObject hurtUI;


    private NavMeshAgent nav;
    private NavMeshHit hit;

    //booleans
    private bool blocked = false;
    private bool runToPlayer = false;
    private bool isChecking = true;

    // floats
    private float distanceToPlayer;

    //integers
    private int failedChecks = 0;

    void Start()
    {
        nav = GetComponentInParent<NavMeshAgent>();
        chaseMusic.SetActive(false);
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(player.position, enemy.transform.position);
        if (distanceToPlayer < maxRange)
        {
            if (isChecking == true)
            {
                isChecking = false;

                blocked = NavMesh.Raycast(transform.position, player.position, out hit, NavMesh.AllAreas);

                if (blocked == false)
                {
                    Debug.Log("I can see the player");
                    runToPlayer = true;
                    failedChecks = 0;
                }
                if (blocked == true)
                {
                    Debug.Log("Where did the player go??");
                    runToPlayer = false;
                    anim.SetInteger("State", 1);
                    failedChecks++;
                }

                StartCoroutine(TimedChecked());
            }
        }

        if (runToPlayer == true)
        {
            enemy.GetComponent<EnemyMove>().enabled = false;
            chaseMusic.SetActive(true);
            if (distanceToPlayer > attackDistance)
            {
                nav.isStopped = false;
                anim.SetInteger("State", 2);
                nav.acceleration = 24;
                nav.SetDestination(player.position);
                nav.speed = chaseSpeed;
                hurtUI.SetActive(false);

            }
            if (distanceToPlayer < attackDistance - 0.5f)
            {
                nav.isStopped = true;
                Debug.Log("I am attacking");
                anim.SetInteger("State", 3);
                nav.acceleration = 180;
                hurtUI.SetActive(true);

                Vector3 pos = (player.position - enemy.transform.position).normalized;
                Quaternion posRotation = Quaternion.LookRotation(new Vector3(pos.x, 0, pos.z));
                enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, posRotation, Time.deltaTime * attackRotateSpeed);
            }
        }
        else if (runToPlayer == false)
        {
            nav.isStopped = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            runToPlayer = true;
        }
    }

    IEnumerator TimedChecked()
    {
        yield return new WaitForSeconds(checkTime);
        isChecking = true;

        if (failedChecks > maxChecks)
        {
            enemy.GetComponent<EnemyMove>().enabled = true;
            nav.isStopped = false;
            nav.speed = walkSpeed;
            failedChecks = 0;
            chaseMusic.SetActive(false);
        }
    }
}
