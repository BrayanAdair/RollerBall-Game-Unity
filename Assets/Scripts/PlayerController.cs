using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [Range(1, 20)]
    
    public float speedPlayer;
    public Text scoreText, timeText;
    public bool gameOver;
    public GameObject panelGameOver, panelWinner;

    private float horizontalInput, verticalInput;
    private Rigidbody playerRB;
    private int points;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        speedPlayer = 10;
        time = 30;
        playerRB = GetComponent<Rigidbody>();
        scoreText.text = "Score: " + points.ToString();
        panelGameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //speedPlayer +=1;
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        if(gameOver == false)
        {
            playerRB.AddForce(moveDirection * speedPlayer);
        }
        //Debug.Log(verticalInput);
        //transform.Translate(speedPlayer * Time.deltaTime * Vector3.right * horizontalInput);
        //transform.Translate(speedPlayer * Time.deltaTime * Vector3.forward * verticalInput);
        //Debug.Log("Score: "+ points);
        scoreText.text = "Score: " + points.ToString();
        CountDown();
        GameOver();
        Winner();
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        points += 1;

    }
    private void CountDown()
    {
        if(gameOver == false)
        {
            time -= Time.deltaTime;
            int seconds = (int)time;
            timeText.text = seconds.ToString();
        }
    }
    private void GameOver()
    {
        if(time<=0)
        {
            gameOver = true;
            panelGameOver.SetActive(true);
        }
    }
    private void Winner()
    {
        if(points == 9)
        {
            gameOver = true;
            panelWinner.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
