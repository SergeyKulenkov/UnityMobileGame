using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour
{
    private float speed = 0f;
    private float defaultSpeed = 3f;
    [HideInInspector]
    public int health;
    [HideInInspector]
    public int scorePoints;

    public float distance = 1f;

    protected virtual void  Start()
    {
        speed = defaultSpeed;
        distance += Random.Range(1f, 6f) / 5; //making random distance between the player
    }
	
	protected virtual void Update ()
    {
        //moving left
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        //checking if enemy is near the player/the goal
        if (transform.position.x - GameObject.FindWithTag("guy").transform.position.x <= distance && transform.position.x - GameObject.FindWithTag("guy").transform.position.x >= 0) Attack();
        else if (transform.position.x - GameObject.FindWithTag("goal").transform.position.x <= distance) Attack();
        else if (transform.position.x - GameObject.FindWithTag("guy").transform.position.x <= 0) DontAttack();  //if it's not near keep moving

        if (health <= 0)
        {   //adding money to the coins script and destroying enemy
            GameObject.Find("coinSign").GetComponent<coins>().score += scorePoints;
            Destroy(gameObject);
        }
    }

    protected virtual void Attack() //attack method
    {
        speed = 0;
    }

    protected virtual void DontAttack() //stop attack and keep moving method
    {
        speed = defaultSpeed;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {   //taking damage from player's bullets
        if (other.gameObject.CompareTag("riflebullet")) health -= other.gameObject.GetComponent<rifleBullet>().damage;
        if (other.gameObject.CompareTag("bullet")) health -= other.gameObject.GetComponent<bullet>().damage;
    }
}
