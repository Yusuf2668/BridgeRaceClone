using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> brickList;
    public List<Vector3> brickPositionList;

    public GameObject[] bridgePointList;
    public GameObject[] playerList;

    int randomNumber;

    private void Start()
    {
        bridgePointList = GameObject.FindGameObjectsWithTag("FinishPoint");
        playerList = GameObject.FindGameObjectsWithTag("Player");

        BridgeAssignment();

        //added the brick to the brickpositionlist
        for (int i = 0; i < brickList.Count; i++)
        {
            brickPositionList.Add(brickList[i].transform.localPosition);
        }
        //we distribute their localpositions randomly
        for (int j = 0; j < brickList.Count; j++)
        {
            randomNumber = Random.Range(0, brickPositionList.Count);
            brickList[j].transform.localPosition = brickPositionList[randomNumber];
            brickPositionList.RemoveAt(randomNumber);
        }
    }

    void BridgeAssignment()
    {
        for (int i = 0; i < bridgePointList.Length -1; i++)
        {
            playerList[i].GetComponent<PlayerAI>().BridgeTarget = bridgePointList[i].gameObject;
        }
    }
}
