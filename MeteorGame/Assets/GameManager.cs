using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public GameObject meteor;
    public GameObject scorePawn;
    public TextMeshProUGUI scoreText;
    [SerializeField] float horizontalBound = 5f;
    [SerializeField] float verticalBound = 5f;
    void Start()
    {
        //Generate
        for (int i = 0 ; i < 8 ; i++)
        {
            Vector2 position = new Vector2(Random.Range(1, horizontalBound), Random.Range(1, verticalBound));
            position = position * (Random.Range(0, 2) == 0 ? -1 : 1);
            Instantiate(meteor, new Vector3(position.x, position.y, i), Quaternion.identity);
        }
        for (int i = 0; i < 4; i++)
        {
            Vector2 position = new Vector2(Random.Range(1, horizontalBound), Random.Range(1, verticalBound));
            position = position * (Random.Range(0, 2) == 0 ? -1 : 1);
            Instantiate(scorePawn, new Vector3(position.x, position.y, i), Quaternion.identity);
        }
    }
    void Update()
    {
        
    }
    public void scoreUpdate()
    {
        Debug.Log("Update Score");
        scoreText.text = "Score : " + score.ToString();
    }
}
