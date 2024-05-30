using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScroling : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    Vector2Int currentTilePosition = new Vector2Int(0, 0);
    [SerializeField] Vector2Int playerTilePosition;
    Vector2Int OnTileGridPlayerPosition;
    [SerializeField] private float tileSize = 6f;
    GameObject[,] terrainTiles;
    [SerializeField] int terrainTileHorizontalCount;
    [SerializeField] int terrainTileVerticalCount;

    [SerializeField] int fieldOfVisionHeight = 3;
    [SerializeField] int fieldOfVisionWidth = 3;
    private void Awake()
    {
        terrainTiles = new GameObject[terrainTileHorizontalCount, terrainTileVerticalCount];
    }

    private void Start()
    {
        UpdateTilesOnScreen();
    }

    private void Update()
    {
        playerTilePosition.x = (int)(playerTransform.position.x / tileSize);
        playerTilePosition.y = (int)(playerTransform.position.y / tileSize);

        playerTilePosition.x -= playerTransform.position.x < 0 ? 1 : 0;
        playerTilePosition.y -= playerTransform.position.y < 0 ? 1 : 0;
        if (currentTilePosition != playerTilePosition)
        {
            currentTilePosition = playerTilePosition;
            OnTileGridPlayerPosition.x = calculatePosition(OnTileGridPlayerPosition.x, true);
            OnTileGridPlayerPosition.y = calculatePosition(OnTileGridPlayerPosition.y, false);
            UpdateTilesOnScreen();
        }
    }

    public void UpdateTilesOnScreen()
    {
        for (int pov_x = -(fieldOfVisionWidth/2); pov_x <= fieldOfVisionWidth / 2; pov_x++)
        {
            for (int pov_y = -(fieldOfVisionHeight); pov_y <= fieldOfVisionHeight / 2; pov_y++)
            {
                int tileToUpdate_x = calculatePosition(playerTilePosition.x + pov_x, true);
                int tileToUpdate_y = calculatePosition(playerTilePosition.y + pov_y, false);

                GameObject tile = terrainTiles[tileToUpdate_x, tileToUpdate_y];
                tile.transform.position =
                    calculateTilePosition(playerTilePosition.x + pov_x, playerTilePosition.y + pov_y);
            }
        }
    }
    public int calculatePosition(int currentValue, bool horizonal)
    {
        if (horizonal)
        {
            if(currentValue >= 0 ) currentValue = currentValue % terrainTileHorizontalCount;
            else
            {
                currentValue++;
                currentValue = terrainTileHorizontalCount - 1 + currentValue % terrainTileHorizontalCount;
            }
        }
        else
        {
            if(currentValue >= 0 ) currentValue = currentValue % terrainTileVerticalCount;
            else
            {
                currentValue++;
                currentValue = terrainTileVerticalCount - 1 + currentValue % terrainTileVerticalCount;
            }
        }

        return (int)currentValue;
    }

    public Vector3 calculateTilePosition(int v1, int v2)
    {
        return new Vector3(v1 * tileSize, v2 * tileSize, 0f);
    }

    public void Add(GameObject tileGameObject, Vector2Int tilePosition)
    {
        terrainTiles[tilePosition.x, tilePosition.y] = tileGameObject;
    }

}
