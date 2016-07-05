using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform platformGenerator;

    private Vector3 platformStartPoint;

    [SerializeField]
    private PlayerController player;
    private Vector3 playerStartPoint;

    private PlatformDestroy[] platformList;
    private ScoreManager scoreManager;

	// Use this for initialization
	void Start ()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;
        scoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void Restart()
    {
        StartCoroutine("RestartGameCo");
    }

    public IEnumerator RestartGameCo()
    {
        scoreManager.scoreIncrease = false;
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformDestroy>();

        for(int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        player.gameObject.SetActive(true);

        scoreManager.scoreCount = 0;
        scoreManager.scoreIncrease = true;
    }
}
