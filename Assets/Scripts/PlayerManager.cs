using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{
    public float health = 100f;
    public Text healthText;
    public GameManager gameManager;
    // Start is called before the first frame update
    public void Hit(float damage)
    {
        health-=damage;
        healthText.text= "Health: "+health.ToString();
        if(health <= 0)
        {
            gameManager.EndGame();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
