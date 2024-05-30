using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTile : MonoBehaviour
{
    [SerializeField] Vector2Int tilePosition;
    void Start()
    {
        GetComponentInParent<WorldScroling>().Add(gameObject, tilePosition);
        transform.position = new Vector3(-100, -100, 0);
    }
}
