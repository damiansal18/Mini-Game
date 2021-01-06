using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    private int score;
    public GameObject explosion; //explosin & celebration
   // public Transform obj1; //used to eliminate  
    private Text ScoreText;
    private Image Scoreboard;

    void Start()
    {
        score = 0;
    }
    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score.ToString();
        Scoreboard.fillAmount = score;
        ScoreText = transform.Find("Canvas").Find("Text").GetComponent<Text>();
        Scoreboard = transform.Find("Canvas").Find("Image2").GetComponent<Image>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ammo")
        {
            Destroy(col.gameObject);
            score += 1;
            if (score == 5)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(this);
                Destroy(gameObject);
            }
        }
    }
}
