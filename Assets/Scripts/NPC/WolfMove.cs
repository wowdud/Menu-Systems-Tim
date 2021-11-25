using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class WolfMove : Attributes
{
    [Header("Health and stuff")]
    public Gradient healthColour;
    public Canvas healthCanvas;
    Transform cam;
    [Header("AI")]
    public Transform target;
    public Transform player;
    public int difficulty;
    public int maxDifficulty;

    public enum AIStates
    {
        Patrol,
        Seek,
        Attack,
        Die
    }
    public AIStates state;
    public Transform waypointParent;
    public Transform[] waypoints;
    public int currentPoint;
    public bool isDead;
    public float distanceToPoint, changePoint;
    public float walkSpeed, runSpeed, attackSpeed, attackRange, sightRange, baseDamage, turnSpeed;
    public Animator anim;
    public NavMeshAgent agent;
    public Material[] enemyMaterials;
    public Renderer rend;

    public void FaceTarget()
    {
        Vector3 turnTowardsTarget = agent.steeringTarget;

        Vector3 direction = (turnTowardsTarget - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public virtual void Start()
    {
        difficulty = Random.Range(0, maxDifficulty+1);
        difficulty++;
        rend.material = enemyMaterials[difficulty];
        cam = Camera.main.transform;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = walkSpeed;
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        currentPoint = 1;
        Patrol();
    }

    void Patrol()
    {
        //don't continue if no waypoints, dead, or player in range
        if (waypoints.Length <= 0 || isDead || Vector3.Distance(player.position, transform.position) <= sightRange)
        {
            if (Vector3.Distance(player.position, transform.position) <= sightRange)
            {
                Seek();
            }
            else
            {
                return;
            }
        }
        state = AIStates.Patrol;
        anim.SetBool("Walk", true);
        agent.speed = walkSpeed;
        agent.stoppingDistance = 0;
        //set agent to target(?)
        agent.destination = waypoints[currentPoint].position;
        //are we at waypoint?
        distanceToPoint = Vector3.Distance(transform.position, waypoints[currentPoint].position);
        if (distanceToPoint <= changePoint)
        {
            //if yes, next waypoint
            if (currentPoint < waypoints.Length-1)
            {
                currentPoint++;
            }
            //if at end of patrol, go to start
            else
            {
                currentPoint = 1;
            }
        }


    }
    void Seek()
    {
        //if player not within sight range
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance > sightRange)
        {
            //stop seeking
            Patrol();
        }
        else
        {
            //set ai state
            state = AIStates.Seek;
            //set animation
            anim.SetBool("Walk", false);
            anim.SetBool("Run", true);
            //target is player
            agent.destination = player.position;
            if (Vector3.Distance(player.position, transform.position) <= attackRange)
            {
                Attack();
            }
        }

    }
    void Attack()
    {
        //if player is in attack range
        distanceToPoint = Vector3.Distance(player.position, transform.position);
        if (distanceToPoint <= attackRange)
        {
            //set ai state
            state = AIStates.Attack;
            //play animation
            anim.SetBool("Run", false);
            anim.SetBool("Attack", true);
            //hurt player   - triggered by animation
            agent.stoppingDistance = distanceToPoint;
            
        }

    }
    void Die()
    {
        //don't run if we are alive
        if (attributes[0].currentValue > 0 || isDead)
        {
            return;
        }
        else
        {
            //set ai state
            state = AIStates.Die;
            //set animation
            anim.SetTrigger("Die");
            //is dead
            isDead = true;
            //stop moving
            agent.speed = 0;
        }

    }

    public virtual void Update()
    {
        SetHealth();
        healthCanvas.transform.LookAt(healthCanvas.transform.position + cam.forward);
        anim.SetBool("Walk", false);
        anim.SetBool("Run", false);
        anim.SetBool("Attack", false);

        Patrol();
        Seek();
        Attack();
        Die();
    }

    public void SetHealth()
    {
        attributes[0].displayImage.fillAmount = Mathf.Clamp01(attributes[0].currentValue / attributes[0].maxValue);
        attributes[0].displayImage.color = healthColour.Evaluate(attributes[0].displayImage.fillAmount);
    }
}
