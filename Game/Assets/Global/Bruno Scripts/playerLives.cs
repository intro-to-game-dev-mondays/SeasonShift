﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerLives : MonoBehaviour {

    public GameObject initialspawnPos;
    public GameObject playerPrefab;
    public int lives;
    public Text lifeCounter;

    public static int deathDetect = 0;
    public int startAm = 3;

	// Use this for initialization
	void Start () {
        lives = startAm;
        deathDetect = 0;
    }

    IEnumerator trueDeath()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("LevelSelect");

    }
	
	// Update is called once per frame
	void Update () {
        if ((deathDetect > 0) & (lives > 0) & (playerManager.isKillable)) {
            float xpos = initialspawnPos.GetComponent<Transform>().position.x;
            float ypos = initialspawnPos.GetComponent<Transform>().position.y;
            Vector3 pos = new Vector3(xpos, ypos, -10f);
            Quaternion angle = Quaternion.Euler(0f,0f,0f);

            if (lives > 0)
            {
                Instantiate(playerPrefab, pos, angle);
                deathDetect -= 1;
                lives = lives - 1;
                
            }
            
            
        }

        if(lives <= 0 && deathDetect == 1){
            StartCoroutine("trueDeath");
        }





        lifeCounter.GetComponent<UnityEngine.UI.Text>().text = lives.ToString();

    }
}
