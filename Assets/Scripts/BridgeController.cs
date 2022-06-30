using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BridgeController : MonoBehaviour
{
    [SerializeField] GameObject restartPanel;

    public List<GameObject> bridgeList;
    public Vector3 offset;

    int redBrick;
    int blueBrick;
    int greenBrick;

    private void Start()
    {
        offset = new Vector3(-0.383f, -0.37f, 0.1f);
        for (int i = 0; i < bridgeList.Count; i++)
        {
            bridgeList[i].transform.localPosition = offset;
            offset += new Vector3(0f, 0f, 0.621f);
        }
    }

    private void Update()
    {
        redBrick = 0;
        blueBrick = 0;
        greenBrick = 0;
        for (int i = 0; i < transform.GetChild(2).childCount; i++)
        {
            if (transform.GetChild(2).transform.GetChild(i).transform.GetComponent<Renderer>().material.name == "RedMat (Instance)")
            {
                redBrick++;
            }
            if (transform.GetChild(2).transform.GetChild(i).transform.GetComponent<Renderer>().material.name == "BlueMat (Instance)")
            {
                blueBrick++;
            }
            if (transform.GetChild(2).transform.GetChild(i).transform.GetComponent<Renderer>().material.name == "GreenMat (Instance)")
            {
                greenBrick++;
            }
        }

        if (redBrick == 10)
        {
            Time.timeScale = 0;
            restartPanel.transform.GetChild(0).transform.gameObject.GetComponent<Text>().text = "Player Red Win!!";
            restartPanel.transform.gameObject.SetActive(true);
        }
        if (blueBrick == 10)
        {
            Time.timeScale = 0;
            restartPanel.transform.GetChild(0).transform.gameObject.GetComponent<Text>().text = "Player Blue Win!!";
            restartPanel.transform.gameObject.SetActive(true);
        }
        if (greenBrick == 10)
        {
            Time.timeScale = 0;
            restartPanel.transform.GetChild(0).transform.gameObject.GetComponent<Text>().text = "Player Green Win!!";
            restartPanel.transform.gameObject.SetActive(true);
        }
    }
}
