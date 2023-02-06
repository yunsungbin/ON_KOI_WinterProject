using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryAT : MonoBehaviour
{
    public static bool iRedAT = false;
    public List<GameObject> IRed = new List<GameObject>();
    public List<GameObject> DRed = new List<GameObject>();
    private int AT;
    public static bool iBlueAT = false;
    public List<GameObject> IBlue = new List<GameObject>();
    public List<GameObject> DBlue = new List<GameObject>();
    private int BAT;
    // Start is called before the first frame update
    void Start()
    {
        AT = 0;
        BAT = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(iRedAT == true)
        {
            DRed[AT].gameObject.SetActive(false);
            IRed[AT].gameObject.SetActive(true);
            AT++;
            iRedAT = false;
        }
        if(iBlueAT == true)
        {
            DBlue[BAT].gameObject.SetActive(false);
            IBlue[BAT].gameObject.SetActive(true);
            BAT++;
            iBlueAT = false;
        }
    }
}
