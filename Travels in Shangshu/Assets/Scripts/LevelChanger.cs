using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private LevelConnection connection;
    [SerializeField] private string targetScene;
    [SerializeField] private Transform spawnPoint;

    void Start()
    {
        if(connection == LevelConnection.ActiveConnection)
        {
            FindObjectOfType<Player>().transform.position = spawnPoint.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<Player>();
        if(player != null)
        {
            LevelConnection.ActiveConnection = connection;
            SceneManager.LoadScene(targetScene); 
        }   
    }
}
