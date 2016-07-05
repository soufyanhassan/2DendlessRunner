using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject thePlatform;

    [SerializeField]
    private Transform generationPoint;

    [SerializeField]
    private float distanceBetween;

    private float platformWidth;

    [SerializeField]
    private float distanceBetweenMin;

    [SerializeField]
    private float distanceBetweenMax;

    [SerializeField]
    private GameObject[] thePlatforms;

    private int platformSelector;
    private float[] platformsWidth;

    private float minHeight;

    [SerializeField]
    private Transform maxHeightP;

    private float maxHeight;

    [SerializeField]
    private float maxHeightChange;

    private float heightChange;

	// Use this for initialization
	void Start ()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        platformsWidth = new float[thePlatforms.Length];
        for(int i = 0; i < thePlatforms.Length; i++)
        {
            platformsWidth[i] = thePlatforms[i].GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightP.position.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            platformSelector = Random.Range(0, thePlatforms.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            } 
            else if(heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (platformsWidth[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);
            Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);

            transform.position = new Vector3(transform.position.x + (platformsWidth[platformSelector] / 2), transform.position.y, transform.position.z);
        }
	}
}
