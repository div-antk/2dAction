using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 必要なコンポーネントを定義
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    [SerializeField] private int moveSpeed;
    [SerializeField] private int jumpForce;

    private bool isMoving = false;
    private bool isJumping = false;
    private bool isFalling = false;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isMoving = horizontal != 0;
        isFalling = rb.velocity.y < -0.5f;

        // 移動中かどうかの判定
        if (isMoving) {
            Vector3 scale = gameObject.transform.localScale;

            // 向きの反転処理
            if(horizontal < 0 && scale.x > 0 || horizontal > 0 && scale.x < 0) {
                scale.x *= -1;
            }
            gameObject.transform.localScale = scale;
        }

        // スペースキーが押された際、かつ落下中ではないときにJump関数を呼ぶ
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !isFalling) {
            Jump();
        }


        // プレイヤーを移動させる処理
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);

        animator.SetBool("IsMoving", isMoving);
        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsFalling", isFalling);
    }

    void Jump() {
        isJumping = true;

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    // 着地した情報を取得
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Stage")) {
            isJumping = false;

        }

    }
}
