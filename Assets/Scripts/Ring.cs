using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public static float speed = 3f;
    public static SolveTowers SolveTowers;

    private Queue<Vector3> targets;
    private Vector3 currentTarget;
    private bool moving;

	// Use this for initialization
	void Start ()
    {
        moving = false;
	}

    public void MoveTo(Queue<Vector3> queue)
    {
        targets = queue;
        currentTarget = targets.Dequeue();
        moving = true;
    }

	// Update is called once per frame
	void Update ()
    {
		if(moving)
        {

            transform.position = Vector3.MoveTowards(
                    current: transform.position,
                    target: currentTarget,
                    maxDistanceDelta: speed * Time.deltaTime
                );
            if(currentTarget == transform.position)
            {
                if (targets.Count != 0)
                    currentTarget = targets.Dequeue();
                else
                {
                    moving = false;
                    SolveTowers.MoveNext();
                }
            }
        }
	}
}
