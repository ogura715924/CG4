using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody rb;

    private float moveSpeed;
    private Vector3 v ;

    //追尾
    public PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        v = rb.velocity;
        moveSpeed = 2;

        //追尾
        player = FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
    
        if (player != null)
        {
            //自機の位置
            Vector3 playerPosition = player.transform.position;

            //敵の位置
            Vector3 enemyPosition = transform.position;

            //プレイヤーに向かう方向ベクトルを計算
            Vector3 direction = (playerPosition - enemyPosition).normalized;

            //敵の速度ベクトルを更新
            rb.velocity = direction * moveSpeed;

            //敵の向きをプレイヤーに向ける
            transform.LookAt(playerPosition);

        }
        


    }

}