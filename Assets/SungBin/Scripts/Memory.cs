using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour
{
    public enum MemoryColor
    {
        None, Red, Blue
    }
    public MemoryColor memoryColor = MemoryColor.None;
    public List<GameObject> redMemory = new List<GameObject>();
    private int r;
    private bool rmemory = false;
    public List<GameObject> blueMemory = new List<GameObject>();
    private int b;
    private bool bmemory = false;
    // Start is called before the first frame update
    void Start()
    {
        r = 0;
        b = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (memoryColor)
        {
            case MemoryColor.Red:
                {
                    if(rmemory == true)
                    {
                        redMemory[r].gameObject.SetActive(false);
                        r++;
                        TMemories.RMAT = true;
                        MemoryAT.iRedAT = true;
                        rmemory = false;
                    }
                    break;
                }
            case MemoryColor.Blue:
                {
                    if (bmemory == true)
                    {
                        blueMemory[r].gameObject.SetActive(false);
                        b++;
                        TMemories.BMAT = true;
                        MemoryAT.iBlueAT = true;
                        bmemory = false;
                    }
                    break;
                }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && memoryColor == MemoryColor.Red)
        {
            rmemory = true;
        }
        if (collision.CompareTag("Player") && memoryColor == MemoryColor.Blue)
        {
            bmemory = true;
        }
    }
}
