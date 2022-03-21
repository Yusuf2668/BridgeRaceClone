using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    public List<GameObject> bridgeList;
    public Vector3 offset;
    private void Start()
    {
        offset = new Vector3(-0.383f, -0.37f, 0.1f);
        for (int i = 0; i < bridgeList.Count; i++)
        {
            bridgeList[i].transform.localPosition = offset;
            offset += new Vector3(0f, 0f, 0.621f);
        }
    }
}
