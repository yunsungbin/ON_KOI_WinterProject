using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMemories : MonoBehaviour
{
    public List<GameObject> rMAT = new List<GameObject>();
    public static int RM;
    public static bool RMAT = false;
    public List<GameObject> bMAT = new List<GameObject>();
    public static int BM;
    public static bool BMAT = false;
    // Start is called before the first frame update
    void Start()
    {
        RM = 0;
        BM = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(RMAT == true)
        {
            rMAT[RM].gameObject.SetActive(true);
            RM++;
            RMAT = false;
        }
        if(BMAT == true)
        {
            bMAT[BM].gameObject.SetActive(true);
            BM++;
            BMAT = false;
        }
    }
}
