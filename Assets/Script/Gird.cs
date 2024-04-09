using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using ApollosScripts;
/// <summary>
/// 格子的脚本实现
/// </summary>
public class Gird
{
    private int width;
    private int height;
    private int cellsize;//格子大小
    private int[,] gird;
    //debug
    private TextMesh[,] DebugTextArray;
    public Gird(int height, int width, int cellsize)
    {
        this.width = width;
        this.height = height;
        this.cellsize = cellsize;
        this.DebugTextArray = new TextMesh[width, height];
        //debug
        this.gird = new int[width, height];
    }
    //在dbug中显示格子
    public void ShowGird()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                //debug
                DebugTextArray[j,i] = ApoCLs.CreateWorldText(gird[j, i].ToString(), getWorldPosition(j, i) + new Vector3(1, 1, 0) * (cellsize / 2));
                Debug.DrawLine(getWorldPosition(j, i), getWorldPosition(j + 1, i), Color.white, 100f);
                Debug.DrawLine(getWorldPosition(j, i), getWorldPosition(j, i + 1), Color.white, 100f);
            }
        }
        Debug.DrawLine(getWorldPosition(width, 0), getWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(getWorldPosition(0, height), getWorldPosition(width, height), Color.white, 100f);
    }
    //获取格子的世界坐标
    public Vector3 getWorldPosition(int x, int y)
    {
        return new Vector3(x, y, 0) * cellsize;
    }
    //通过世界坐标获取格子的坐标
    public void getXY(Vector3 worldPosition, out int x, out int y)
    {
        x=Mathf.FloorToInt(worldPosition.x/cellsize);
        y=Mathf.FloorToInt(worldPosition.y/cellsize);
    }
    //获取格子的值
    public int getValue(int x,int y)
    {
        return gird[x, y];
    }
    public int getValue(Vector3 worldPosition)
    {
        int x, y;
        getXY(worldPosition, out x, out y);
        return getValue(x, y);
    }
    //设置格子的值
    public void setValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            this.gird[x, y] = value;
            //debug
            DebugTextArray[x,y].text=value.ToString();
        }
    }
    public void setValue(Vector3 worldPosition,int value)
    {
        int x, y;
        getXY(worldPosition, out x, out y);
        setValue(x, y, value);
    }
}
