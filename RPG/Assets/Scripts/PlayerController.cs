using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private Ray ray;
    private RaycastHit objectHit;

    private float xSpeed;
    private float zSpeed;
    private float speed;


    // Start is called before the first frame update
    void Start()  {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()  {

        //calculate player speed
        xSpeed = navMeshAgent.velocity.x;
        zSpeed = navMeshAgent.velocity.z;
        speed = xSpeed + zSpeed;
        
        if(Input.GetMouseButtonDown(0)) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out objectHit)) {
                navMeshAgent.destination = objectHit.point;
            }

        }

        if(speed != 0) {
            animator.SetBool("sprinting", true);
        }

        if(speed ==0) {
            animator.SetBool("sprinting", false);
        }

    }
}
