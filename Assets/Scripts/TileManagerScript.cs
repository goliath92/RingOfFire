using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManagerScript : MonoBehaviour
{
    //all tile prefabs
    public GameObject[] TilePrefabs;

    //track player to create new tiles
    private Transform playerTransform;

    //where to spawn the object
    private float spawnZ = -12.0f;      //tile's will be spawn behind the player a bit
    private float tileLength = 50.0f;

    //How many tiles will be on screen
    private int tileAmountOnScreen = 3;

    //Keep track of active tiles, so can be deleted when new ones created
    private List<GameObject> activeTiles;
    
    // to prevent deleting tiles while still on them.
    private float deleteMargin = 35.0f;

    private int lastPrefabIndex = 0;
    

    private void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < tileAmountOnScreen; i++)
        {
            // this logic is to create obstacle free tiles when starting the game (first 2 tiles will be free)
            if(i<2)
            {
                SpawnTile(0);
            }

            else
            {
                SpawnTile();
            }

            
        }
        
    }

    private void Update()
    {
        // player will always see "tileAmountOnScree" much tiles, so new ones will be created accordingly
        if(playerTransform.position.z - deleteMargin > (spawnZ - tileAmountOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }
    
    private void SpawnTile(int prefabIndex = -1) //-1 to create random number
    {
        GameObject go;

        if (prefabIndex == -1)
        {
            go = Instantiate(TilePrefabs[RandomTileIndex()]) as GameObject;
        }
        //The logic in Else is to create obstacle free tiles when starting the game (index 0 is the obstacle free tile)
        else
        {
            go = Instantiate(TilePrefabs[prefabIndex]) as GameObject;  
        }

        // SetParent, so created objects will not be child object under TileManager
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        //spawnZ should increase, so new tiles will spawn forward
        spawnZ += tileLength;
        activeTiles.Add(go);

    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomTileIndex()
    {
        if (TilePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;

        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, TilePrefabs.Length);
        }

        //new number random assigned
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
