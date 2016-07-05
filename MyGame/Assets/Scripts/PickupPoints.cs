using UnityEngine;
using System.Collections;

public class PickupPoints : MonoBehaviour
{
    public int giveScore;
    private ScoreManager scoreManager;

	// Use this for initialization
	void Start ()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.name == "Player")
        {
            scoreManager.AddScore(giveScore);
            Destroy(gameObject);
        }
    }
}
