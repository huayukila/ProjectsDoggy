using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class BallGimmick : MonoBehaviour
{
    public List<GameObject> BallList = new List<GameObject>();

    private int _allGimmickBallCnt = 0;

    public int AllGimmickBallCnt
    {
        get => _allGimmickBallCnt;
        set
        {
            _allGimmickBallCnt = value; 
            if(_allGimmickBallCnt > BallList.Count)
            {
                _allGimmickBallCnt = BallList.Count;
            }
        } 
    }

    void Start()
    {
        IniBallGimmick();
    }

    public void IniBallGimmick()
    {
        foreach (GameObject obj in BallList)
        {
            //obj.GetComponent<Renderer>().enabled = false;
            obj.SetActive(false);
        }
    }
    public void UpdateBallGimmick(int addValue)
    {
        AllGimmickBallCnt += addValue;

        for(int i = 0; i < AllGimmickBallCnt; i++)
        {
            //BallList[i].GetComponent<Renderer>().enabled = true;
            BallList[i].SetActive(true);
        }
    }
}
