using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatrulhaPorWaypoint : State
{

    public Transform[] waypoints;

    SteerableBehaviour steerable;
    // float angle = 0;

    public override void Awake()
    {
        base.Awake();

        Transition ToAtacando = new Transition();
        ToAtacando.condition = new ConditionDistLT(transform, 
            GameObject.FindWithTag("Player").transform, 
            2.0f);
        ToAtacando.target = GetComponent<StateAtaque>();
        transitions.Add(ToAtacando);

        steerable = GetComponent<SteerableBehaviour>();
    }
    
    private void Start() {
        waypoints[0].position = transform.position;
        waypoints[1].position = GameObject.FindWithTag("Player").transform.position;
    }

    public void Update() // WARNING
    {
        if(Vector3.Distance(transform.position, waypoints[1].position) > 0.1f) {
            Vector3 direction = waypoints[1].position - transform.position;
            direction.Normalize();
            steerable.Thrust(direction.x, direction.y);
        } else {
            waypoints[1].position = GameObject.FindWithTag("Player").transform.position;
        }

    }
}   
