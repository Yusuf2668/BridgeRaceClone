using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GameController
{
    [SerializeField] List<GameObject> _brickList;
    [SerializeField] Material material;
    [SerializeField] string brickTag;
    [SerializeField] string bridgeBrickTag;
    [SerializeField] int bridgeLayerNumber;


    public int bridgeCounter;
    public bool canTakeBrick { get { return _brickLine != _brickList.Count - 1; } }
    public bool canTakeOff { get { return _brickLine > 0; } }
    public int brickLine
    {
        get
        {
            if (_brickLine < _brickList.Count)
            {
                return _brickLine;
            }
            else
            {
                return _brickLine = 0;
            }
        }
        set
        {
            if (0 > _brickLine)
            {
                _brickLine = value;
            }
        }

    }

    private float brickPosition;
    public int _brickLine = 0;

    private void Start()
    {
        //To align the brick on our backs
        brickPosition = 0f;
        for (int i = 0; i < _brickList.Count; i++)
        {
            _brickList[i].transform.localPosition = new Vector3(0f, brickPosition, 0f);
            brickPosition += 0.2f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Collect to the brick
        if (other.gameObject.CompareTag(brickTag) && canTakeBrick)
        {
            CollectBrick(_brickList, other.gameObject, brickLine);
            _brickLine++;
        }
        if (other.gameObject.CompareTag("BridgeBrick") && canTakeOff)
        {
            _brickLine--;
            bridgeCounter++;
            TakeOffBrick(_brickList, brickLine, other.gameObject, material);
            other.gameObject.layer = bridgeLayerNumber;
        }
    }
}
