using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 必要なコンポーネントを定義
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CapsuleCollider2D))]

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーを移動させる処理
        rb.velocity = new Vector2(Input.GetAxis("Horizintal") * moveSpeed, rb.velocity.y);
    }
}
