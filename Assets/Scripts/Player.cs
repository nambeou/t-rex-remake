using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 10;
    GameSession session;
    Animator animator;
    Collider2D myCollider;
    Rigidbody2D mybody;
    // Start is called before the first frame update
    void Start()
    {
        session = FindObjectOfType<GameSession>();
        animator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        mybody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void Jump() {
        if(session.GameHasStarted()){
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (myCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
                    animator.SetTrigger("Jump");
                    mybody.velocity = new Vector2(0, jumpSpeed);
                }
            }
        }
    }
    public void Run() {
        animator.SetBool("Running", true);
    }
}
