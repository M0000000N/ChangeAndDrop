using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : SingletonBehaviour<BallPool>
{
    public List<GameObject> ballPoolList;
    [SerializeField] Ball ballPrefeb;
    private int firstSpawn = 5;
    private int firstInstantiate = 100;

    void Start()
    {
        Initioalize();
    }
    private void Initioalize()
    {
        ballPoolList = new List<GameObject>();

        for (int i = 0; i < firstInstantiate; i++)
        {
            GameObject ballprefeb = Instantiate(ballPrefeb.gameObject);
            if (i < firstSpawn)
            {
                ballprefeb.SetActive(true);
            }
            else
            {
                ballprefeb.SetActive(false);
            }
            ballPoolList.Add(ballprefeb);
            ballprefeb.transform.SetParent(this.transform);
        }
    }
}
