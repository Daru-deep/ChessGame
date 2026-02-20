using System;
using UnityEngine;

public class BordMaker : MonoBehaviour
{
    [SerializeField]GameObject square;
    GameObject[,] pieces;//オブジェクトを管理する配列
    GameObject[,] bordSprite;//

    [SerializeField] Transform anker;
    float masSize = 1;
    [SerializeField,Range(1,100)]
    int height;
    [SerializeField,Range(1,100)]
    int whide;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        if(height>0&&whide>0)
        {
            pieces = new GameObject[height,whide];
            InstanceBord();
        }
    }

    void InstanceBord()
    {
        bordSprite = new GameObject[height,whide];
        int num = 1;
        for(int y = 0; y < height; y++)
        {
            for(int x = 0; x < whide; x++)
            {
                Vector3 tr = new(x * masSize, y * masSize, 0);
                int squareIndex = (x + y) % 2;
                bordSprite[y,x] = Instantiate(square,anker.position + tr,Quaternion.identity,anker);
                if(squareIndex == 0) bordSprite[y,x].GetComponent<SpriteRenderer>().color = Color.gray;
                bordSprite[y,x].name = $"Mas{num}";
                num++;
            }
        }
    }

    public void ChengeBord(Vector2Int pos,GameObject piece)
    {
        if(pos.x < whide && pos.y < height) pieces[pos.y,pos.x] = piece;
    }
}
