using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endScene : MonoBehaviour
{
    public List<GameObject> endingcrdit = new List<GameObject>();
    int EC;
    // Start is called before the first frame update
    void Start()
    {
        EC = 0;
        StartCoroutine(end());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator end()
    {
        endingcrdit[EC].gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        endingcrdit[EC].gameObject.SetActive(false);
        if (EC == 3)
        {
            SceneManager.LoadScene("Title");
            StopCoroutine(end());
        }
        EC++;
        StartCoroutine(end());

    }
}
