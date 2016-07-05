﻿using UnityEngine;
using System.Collections;

public class PlatformDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject platformDestructionPoint;

	// Use this for initialization
	void Start ()
    {
        platformDestructionPoint = GameObject.Find("PlatformDestroyPoint");
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(transform.position.x < platformDestructionPoint.transform.position.x)
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
	}
}
