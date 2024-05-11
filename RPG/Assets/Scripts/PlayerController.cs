using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    private NavMeshAgent navMeshAgent;
    private Ray ray;
    private RaycastHit objectHit;


    // Start is called before the first frame update
    void Start()  {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()  {
        
        if(Input.GetMouseButtonDown(0)) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out objectHit)) {
                navMeshAgent.destination = objectHit.point;
            }

        }

    }
}
