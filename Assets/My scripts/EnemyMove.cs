using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class EnemyMove : MonoBehaviour
{
    //targets
    [SerializeField] Transform target1;
    [SerializeField] Transform target2;
    [SerializeField] Transform target3;
    [SerializeField] Transform target4;
    [SerializeField] Transform target5;
    [SerializeField] Transform target6;
    [SerializeField] Transform target7;
    [SerializeField] Transform target8;
    [SerializeField] Transform target9;
    [SerializeField] Transform target10;

    [SerializeField] float stopDistance = 2.0f;
    [SerializeField] int maxTargets = 10;
    [SerializeField] float waitTime = 2.0f;

    private NavMeshAgent nav;
    private Animator anim;
    private Transform theTarget;

    private float distanceToTarget;
    private int targetNumber = 1;
    private bool hasStopped = false; 
    private bool randomizer = true;
    private int nextTargetNumber;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        theTarget = target1;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(theTarget.position, transform.position);
        if (distanceToTarget > stopDistance)
        {
            nav.SetDestination(theTarget.position);
            anim.SetInteger("State", 0);
            nav.isStopped = false;
            nextTargetNumber = targetNumber;
        }

        if (distanceToTarget < stopDistance)
        {
            nav.isStopped = true;
            anim.SetInteger("State", 1);
            StartCoroutine(LookAround());         
        }
    }

    void SetTarget()
    {
        if (targetNumber == 1)
        {
            theTarget = target1;
        }
        if (targetNumber == 2)
        {
            theTarget = target2;
        }
        if (targetNumber == 3)
        {
            theTarget = target3;
        }
        if (targetNumber == 4)
        {
            theTarget = target4;
        }
        if (targetNumber == 5)
        {
            theTarget = target5;
        }
        if (targetNumber == 6)
        {
            theTarget = target6;
        }
        if (targetNumber == 7)
        {
            theTarget = target7;
        }
        if (targetNumber == 8)
        {
            theTarget = target8;
        }
        if (targetNumber == 9)
        {
            theTarget = target9;
        }
        if (targetNumber == 10)
        {
            theTarget = target10;
        }
    }

    IEnumerator LookAround()
    {
        yield return new WaitForSeconds(waitTime);

        if (hasStopped == false)
        {
            hasStopped = true;
            //random targets
            if (randomizer == true)
            {
                randomizer = false;
                targetNumber = Random.Range(1, maxTargets);

                if (targetNumber == nextTargetNumber)
                {
                    targetNumber++; 
                    
                    if (targetNumber >= maxTargets)
                    {
                        targetNumber = 1;
                    }
                }
            }
            SetTarget();

            yield return new WaitForSeconds(waitTime);
            hasStopped = false;
            randomizer = true;
        }
    }   
}
