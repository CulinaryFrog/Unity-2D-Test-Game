using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hole")
        {
            Destroy(gameObject);
        }

        if (other.tag == "Player" || other.tag == "Enemy" && other.GetComponent<Enemy>().speed == 0)
        {
            speed = 0;
            transform.parent = player.transform;
        }
    }
}
