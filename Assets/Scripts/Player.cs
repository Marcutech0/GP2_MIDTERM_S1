using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public List<GameObject> playerColor;
    public GameObject player;
    public int playerColorCount = 0;

    public int vertexCount = 40;
    public float lineWidth = 0.5f;
    public float range;
    public LineRenderer line;

    public List<GameObject> enemyList;
    public GameObject enemyTarget;
    public int enemyCount;
    public Transform target;
    public GameObject DeathScreen;

    void Awake()
    {
        enemyCount = 0;

        player = playerColor[playerColorCount++];

        line = GetComponent<LineRenderer>();
    }

    private void Start()
    {
     
    }

    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            ChangePlayerColor();
        }

        CreateCircle();
    }

    public void ChangePlayerColor()
    {
        player.SetActive(false);
        player = playerColor[playerColorCount++];
        if (playerColorCount == playerColor.Count)
        {
            playerColorCount = 0;
        }

        player.SetActive(true);
    }

    private void CreateCircle()
    {
        line.widthMultiplier = lineWidth;

        float deltaTheta = 2f * Mathf.PI / vertexCount;
        float theta = 0f;

        line.positionCount = vertexCount;
        for (int i = 0; i < line.positionCount; i++)
        {
            Vector3 pos = new Vector3(range * Mathf.Cos(theta), 0f, range * Mathf.Sin(theta));
            line.SetPosition(i, pos);
            theta += deltaTheta;
        }
    }

    private void AimAtEnemy()
    {
        enemyTarget = enemyList[enemyCount];
        Vector3 relativePos = enemyTarget.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyList.Add(other.gameObject);
            AimAtEnemy();
            enemyCount++;
        }
    }
    private void OnDestroy()
    {
        DeathScreen.SetActive(true);
    }
}