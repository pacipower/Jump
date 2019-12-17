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
    public GameObject wall;
    public GameObject wall2;
    private int platformSize;
    public static float elevation=3.5f;
    public static float offset = 1;
    public static bool needNewLevel;
    public float newLevelPosition;
    private int platformCount;


    public static bool landscape;
    
    private float cameraBound;

    

    // Start is called before the first frame update
    void Start()
    {
        landscape = true;
        cameraBound = UnityEngine.Camera.main.orthographicSize*Screen.width/Screen.height;
        
        platformCount = 0;
        needNewLevel = false;
        AddLevel(elevation - offset);
        AddLevel(elevation - offset+14);

        
    }

    //public void AddLevel(float pos)
    //{
    //    for (int j = -1; j < 2; j += 2)
    //    {
    //        if (((pos-elevation+offset)/14)%2==0)
    //        {
    //            GameObject ins = Instantiate(wall);
    //            ins.transform.position = new Vector3(j * 14.23f, pos, 0);
    //        }
    //        else
    //        {
    //            GameObject ins = Instantiate(wall2);
    //            ins.transform.position = new Vector3(j * 14.23f, pos, 0);
    //        }

    //    }

    //    for (int i = -1; i < 3; i++)
    //    {



    //        if (platformCount + 1 > 90)
    //        {
    //            platformSize = 100;
    //        }
    //        else
    //            platformSize = Random.Range(platformCount + 1, 101);

    //        if (platformSize < 61)
    //        {
    //            Platform instance = Instantiate(platform);
    //            instance.transform.position = new Vector3(0, pos + i*elevation, 0);
    //        }

    //        else if (platformSize > 60 && platformSize < 100)
    //        {
    //            Platform instance = Instantiate(platform2);
    //            instance.transform.position = new Vector3(0, pos + i*elevation, 0);
    //        }

    //        else if (platformSize == 100)
    //        {
    //            Platform instance = Instantiate(platform3);
    //            instance.transform.position = new Vector3(0, pos + i*elevation, 0);
    //        }

    //        Coin instance2 = Instantiate(coin);
    //        instance2.transform.position = new Vector3(Random.Range(-11.5f, 11.5f), pos + i*elevation + elevation / 2, 0);



    //        if (Random.Range(0, 2) == 0)
    //        {
    //            Spike instance3 = Instantiate(spikeLeft);
    //            instance3.transform.position = new Vector3(12.38f, pos + i*elevation + elevation / 2, 0);
    //        }
    //        else
    //        {
    //            Spike instance3 = Instantiate(spikeRight);
    //            instance3.transform.position = new Vector3(-12.38f, pos + i*elevation + elevation / 2, 0);
    //        }
    //        platformCount++;
    //    }
    //}




        




    public void AddLevel(float pos)
    {
        for (int j = -1; j < 2; j += 2)
        {
            if (((pos - elevation + offset) / 14) % 2 == 0)
            {
                GameObject ins = Instantiate(wall);
                ins.transform.position = new Vector3(j * (cameraBound+1.85f), pos, 0);
            }
            else
            {
                GameObject ins = Instantiate(wall2);
                ins.transform.position = new Vector3(j * (cameraBound + 1.85f), pos, 0);
            }

        }

        for (int i = -1; i < 3; i++)
        {



            if (platformCount + 1 > 90)
            {
                platformSize = 100;
            }
            else
                platformSize = Random.Range(platformCount + 1, 101);

            if (landscape && platformSize < 61)
            {
                Platform instance = Instantiate(platform);
                instance.transform.position = new Vector3(0, pos + i * elevation, 0);
            }

            else if ((landscape && platformSize > 60 && platformSize < 100) || (!landscape && platformSize<71))
            {
                Platform instance = Instantiate(platform2);
                instance.transform.position = new Vector3(0, pos + i * elevation, 0);
            }

            else if ((landscape && platformSize == 100) || (!landscape && platformSize > 70))
            {
                Platform instance = Instantiate(platform3);
                instance.transform.position = new Vector3(0, pos + i * elevation, 0);
            }

            Coin instance2 = Instantiate(coin);
            instance2.transform.position = new Vector3(Random.Range(-cameraBound+1, cameraBound-1), pos + i * elevation + elevation / 2, 0);



            if (Random.Range(0, 2) == 0)
            {
                Spike instance3 = Instantiate(spikeLeft);
                instance3.transform.position = new Vector3(cameraBound, pos + i * elevation + elevation / 2, 0);
            }
            else
            {
                Spike instance3 = Instantiate(spikeRight);
                instance3.transform.position = new Vector3(-cameraBound, pos + i * elevation + elevation / 2, 0);
            }
            platformCount++;
        }
    }







    // Update is called once per frame
    void Update()
    {
        if (needNewLevel)
        {
            newLevelPosition = Camera.minPosition+1 + 28;
            Debug.Log(newLevelPosition);
            needNewLevel=false;
            AddLevel(newLevelPosition);
        }
    }
}
