using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
using UnityEngine;


public class MapManager : MonoBehaviour
{
    //singleton
    static readonly MapManager _instance = new MapManager();
    public static MapManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public const int cDirtTileType = 0;
    public const int cSeaTileType = cDirtTileType + 1;
    public const int cMaxTileType = 2;

    public const int mapDimensionX = 10;
    public const int mapDimensionY = 10;
    public int[,] mCurrMapTileType;
    public Hashtable mTileTypeToTextureTable;

    public void InitTable()
    {
        mTileTypeToTextureTable = new Hashtable();
        mTileTypeToTextureTable.Add(cDirtTileType, (Texture2D)Resources.Load("dirt", typeof(Texture2D)));
        mTileTypeToTextureTable.Add(cSeaTileType, (Texture2D)Resources.Load("sea", typeof(Texture2D)));

        mCurrMapTileType = new int[mapDimensionX, mapDimensionY];
        //init map value
        for (int x = 0; x < mapDimensionX; ++x)
        {
            for (int y = 0; y < mapDimensionY; ++y)
            {
                mCurrMapTileType[x, y] = 1;
            }
        }
    }


    public void SaveMap(string fileName)
    {
        Debug.Log("Saving Map " + Application.persistentDataPath + fileName);
        StringBuilder sb = new StringBuilder();
        for (int x = 0; x < mapDimensionX; ++x)
        {
            for (int y = 0; y < mapDimensionY; ++y)
            {
                sb.Append(mCurrMapTileType[x, y].ToString() + ",");
            }
            sb.Remove(sb.Length - 1, 1); // remove last comma
            sb.AppendLine();
        }
        File.WriteAllText(Application.persistentDataPath + fileName, sb.ToString());
    }

    public void LoadMap(string fileName)
    {
        Debug.Log("Loading Map " + Application.persistentDataPath + fileName);
        FileStream fStream = File.OpenRead(Application.persistentDataPath + fileName);
        StreamReader streamReader = new StreamReader(fStream);
        int lineNumb = 0;
        while (!streamReader.EndOfStream)
        {
            string line = streamReader.ReadLine();
            string[] values = line.Split(',');
            for (int i = 0; i < values.Length; ++i)
            {
                mCurrMapTileType[lineNumb, i] = Int32.Parse(values[i]);
            }
            lineNumb++;
        }
    }




    // Use this for initialization
    void Start ()
    {
        		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
