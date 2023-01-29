using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBreak : MonoBehaviour
{
    public static bool RedArea = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            RedArea = true;
        }
    }
}
