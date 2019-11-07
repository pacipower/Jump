using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Platform platform;
    public Platform platform2;
    public Platform platform3;
    public Coin coin;
    public Spike spikeLeft;
    public Spike spikeRight;
    int platformSize;
    
    //public static Level level;

    //private void Awake()
    //{
    //    level = GameObject.FindGameObjectWithTag("Level").GetComponent<Level>();
    //}
    //[SerializeField]
    //private GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        

        for (int i = 0; i < 100; i++)
        {

            if (i+1>90)
            {
                platformSize = 100;
            }
            else
            platformSize = Random.Range(i+1, 101);

            if (platformSize < 76)
            {
                Platform instance = Instantiate(platform);
                instance.transform.position = new Vector3(0, i * 4.5f, 0);
            }

            else if (platformSize > 75 && platformSize < 100)
            {
                Platform instance = Instantiate(platform2);
                instance.transform.position = new Vector3(0, i * 4.5f, 0);
            }

            else if (platformSize == 100)
            {
                Platform instance = Instantiate(platform3);
                instance.transform.position = new Vector3(0, i * 4.5f, 0);
            }

            Coin instance2 = Instantiate(coin);
            instance2.transform.position = new Vector3(Random.Range(-8f,8f), i * 4.5f+2.25f, 0);

            
            if (Random.Range(0, 2) == 0)
            {
                Spike instance3 = Instantiate(spikeLeft);
                instance3.transform.position = new Vector3(8.8f, i * 4.5f + 2.25f, 0);
            }
            else
            {
                Spike instance3 = Instantiate(spikeRight);
                instance3.transform.position = new Vector3(-8.8f, i * 4.5f + 2.25f, 0);
            }

        }
    }

    //public static void EndGame2()
    //{
    //    level.EndGame();
    //}

    //public void EndGame()
    //{
    //    //GameOver.UpdateGameOverText();
    //    gameOverUI.SetActive(true);
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
