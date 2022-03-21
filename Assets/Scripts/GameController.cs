using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    protected void CollectBrick(List<GameObject> brickList, GameObject brick, int brickLine)
    {
        brick.transform.DOMove(brickList[brickLine].transform.position, 0.2f).OnComplete(() => brick.gameObject.SetActive(false));
        brickList[brickLine].transform.gameObject.SetActive(true);
    }

    protected void TakeOffBrick(List<GameObject> brickList, int brickLine, GameObject collision, Material material)
    {
        brickList[brickLine].transform.gameObject.SetActive(false);
        collision.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        collision.gameObject.GetComponent<MeshRenderer>().material = material;
    }
}
