using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Level_Manage : MonoBehaviour
{
    public static Level_Manage instance;

    [SerializeField] private Transform respawnPoint;
    [SerializeField] private GameObject zPrefab;

    public CinemachineVirtualCameraBase cam;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    public void Respawn()
    {
        GameObject player = Instantiate(zPrefab, respawnPoint.position, Quaternion.identity);
        cam.Follow = player.transform;
    }
}
