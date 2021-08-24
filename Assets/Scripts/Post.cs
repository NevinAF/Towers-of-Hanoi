using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Post : MonoBehaviour
{
    public Stack<GameObject> disks;

	void Start()
    {
        disks = new Stack<GameObject>();
	}
}
