using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpwanPlayer : MonoBehaviour
{
    public GameObject playerPrefab;
    //public GameObject enemyPrefab;

    public float minx;
    public float miny;
    public float maxx;
    public float maxy;
    private void Start()
    {
        Vector2 randomPosition = new Vector2 (Random.Range(minx,maxx),Random.Range(miny,maxy));
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition,Quaternion.identity);
    }
}
