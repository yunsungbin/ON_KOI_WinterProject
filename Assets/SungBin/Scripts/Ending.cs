using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GetKey.keyGet == true && collision.CompareTag("Player") && GameSample.end == true)
        {
            SceneManager.LoadScene("Ending");
            GetKey.keyGet = false;
        }
        else if(GetKey.keyGet == true && collision.CompareTag("Player"))
        {
            GetKey.keyGet = false;
        }
    }
}
