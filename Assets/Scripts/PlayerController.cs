using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 必要なコンポーネントを定義
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private int moveSpeed;
    [SerializeField] private int jumpForce;

    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // スペースキーが押された際、かつ落下中ではないときにJump関数を呼ぶ
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !(rb.velocity.y < -0.5f)) {
            Jump();
        }

        // プレイヤーを移動させる処理
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
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
