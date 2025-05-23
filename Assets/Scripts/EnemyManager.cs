using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    public Animator enemyAnimator;
    public float damage = 20f;
    public float health = 100f;
    public GameManager gameManager;
    // Start is called before the first frame update

    public void Hit(float damage)
    {
        health -= damage;

        if (health <= 0) {
            gameManager.enemiesAlive--;
            Destroy(gameObject);

        }
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination=player.transform.position;
        if(GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            enemyAnimator.SetBool("isRunning", true);
        }
        else
        {
            enemyAnimator.SetBool("isRunning", false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject==player)
        {
            //Debug.Log("Player hit!");
            player.GetComponent<PlayerManager>().Hit(damage);   
        }
    }
}
