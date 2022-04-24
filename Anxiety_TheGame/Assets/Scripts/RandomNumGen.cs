using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumGen : MonoBehaviour
{
    public int randomNum = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makeRandomNum(int min, int max)
    {
        randomNum = UnityEngine.Random.Range(min, max);
    }

    public int returnRandomNum()
    {
        return randomNum;
    }
}
