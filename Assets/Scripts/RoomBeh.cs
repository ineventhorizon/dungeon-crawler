using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBeh : MonoBehaviour
{
    public GameObject[] walls;
    public GameObject[] doors;



    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateRoom(bool[] status)
    {
        for(int i = 0; i < status.Length; i++)
        {
            doors[i].SetActive(status[i]);
            walls[i].SetActive(!status[i]);
        }
    }
}
