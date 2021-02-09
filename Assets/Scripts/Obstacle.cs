using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField] GameObject referenceGround;
    [SerializeField] float minHeight = 0;
    [SerializeField] float maxHeight = 0;
    Collider2D myCollider;
    Rigidbody2D mybody;
    GameSession gameSession;
    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        myCollider = GetComponent<Collider2D>();
        mybody = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(transform.position.x, referenceGround.transform.position.y + Random.Range(minHeight, maxHeight));
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
    }

    private void MoveLeft() {
        float currentGameSpeed = FindObjectOfType<GameSession>().GetGameSpeed();
        mybody.velocity = new Vector2(-currentGameSpeed*10, 0);
    }


}
