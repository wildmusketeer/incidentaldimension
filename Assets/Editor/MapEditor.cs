using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Text;
using System.IO;
using System;

public class MapEditor : EditorWindow
{
    [MenuItem("Map_Editor/mapEdit")]
    static void Init()
    {
        MapEditor window = (MapEditor)EditorWindow.GetWindow(typeof(MapEditor));
    }

    
    void OnEnable()
    {
        //initialize
        MapManager.Instance.InitTable();
    }

   
    

    void OnGUI()
    {
        string fileName = GUI.TextField(new Rect(0, 40, 200, 40), "Map_Start.csv");
        if (GUI.Button(new Rect(0,0, 100, 30), "Save"))
        {
            MapManager.Instance.SaveMap(fileName);
        }
        if(GUI.Button(new Rect(120, 0, 100, 30), "Load"))
        {
            MapManager.Instance.LoadMap(fileName);
        }
       

        // setup map for display
        const int startX = 0;
        const int startY = 100;
        int scale = 30;
        for(int x = 0; x < MapManager.mapDimensionX; ++x)
        {
            for(int y = 0; y < MapManager.mapDimensionY; ++y)
            {
                if(GUI.Button(new Rect(startX + x * scale, startY + y *scale, scale, scale), (Texture2D)MapManager.Instance.mTileTypeToTextureTable[MapManager.Instance.mCurrMapTileType[x,y]]))
                {
                    MapManager.Instance.mCurrMapTileType[x, y] = (MapManager.Instance.mCurrMapTileType[x, y] + 1) % MapManager.cMaxTileType;
                }
            }
        }
    }

}