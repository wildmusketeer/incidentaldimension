using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlaneTiler : MonoBehaviour
{
    public GameObject planePrefab;
    // Use this for initialization
    void Start()
    {
        MapManager.Instance.InitTable();
        MapManager.Instance.LoadMap("Map_Start.csv");



        float tileScale = 5.0f;
        Vector3 offSet = tileScale*  new Vector3(0.5f, 0.5f, 0.0f);
        Vector3 centerPos = planePrefab.transform.position + offSet;
        
        GameObject go = new GameObject("MapParent");
        for (int i =0; i < MapManager.mapDimensionX; ++i)
        {
            for(int j = 0; j <MapManager.mapDimensionY; ++j)
            {
                GameObject newPlane = GameObject.Instantiate(planePrefab);
                newPlane.transform.position = centerPos + new Vector3((i  - MapManager.mapDimensionX /2.0f) * tileScale, (j - MapManager.mapDimensionY / 2.0f) * tileScale, 0.001f);
                newPlane.transform.localScale *= 0.5f;
                newPlane.transform.parent = go.transform;
                newPlane.name = "mapTile" + i + "_" + j;
                int tileType = MapManager.Instance.mCurrMapTileType[i, j];
                newPlane.GetComponent<Renderer>().material.mainTexture = (Texture2D) MapManager.Instance.mTileTypeToTextureTable[tileType];
            }
        }
      

    }


    // Update is called once per frame
    void Update()
    {

    }
}
