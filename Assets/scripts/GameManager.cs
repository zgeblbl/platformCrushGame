using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private PlayerController playerController;
    [SerializeField] 
    private float respawnDelay = 2f;
    private bool gameOver = false;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public GameObject WinnerUI;


    void Start(){ 
        playerController = FindObjectOfType<PlayerController>();
    }
    public void RespawnPlayer(){
        if (gameOver == false)
        {
            gameOver = true;
            StartCoroutine("RespawnCoroutine");
        }
    }
    public IEnumerator RespawnCoroutine(){
        playerController.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //playerController.transform.position = playerController.respawnPoint;
        //playerController.gameObject.SetActive(true);
        gameOver = false;
    }
    public void AddScore(int numberOfScore)
    {
        score += numberOfScore;
        scoreText.text = "SCORE: "+ score.ToString();
    }
    public void LevelUp()
    {
        WinnerUI.SetActive(true);
        winText.text = "LEVEL COMPLETED TOTAL SCORE: " + score.ToString();
       Invoke("NextLevel", 2f);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    

}
