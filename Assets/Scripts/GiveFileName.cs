using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveFileName : MonoBehaviour
{
    public static string filename;
    // Start is called before the first frame update
    void Start()
    {
        filename = "User_" + System.DateTime.Now.Ticks.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
