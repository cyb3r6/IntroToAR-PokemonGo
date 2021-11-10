using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MonsterGenerator : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public GameObject monster;

    private bool isMonsterPlaced = false;

    void Start()
    {
        
    }

    
    void Update()
    {
        foreach(ARPlane plane in planeManager.trackables)
        {
            if(!isMonsterPlaced && plane.alignment == PlaneAlignment.HorizontalUp)
            {
                isMonsterPlaced = true;
                Instantiate(monster, plane.transform.position, Quaternion.identity);
            }
        }
    }
}
