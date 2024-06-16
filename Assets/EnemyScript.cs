using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody rb;

    private float moveSpeed;
    private Vector3 v ;

    //�ǔ�
    public PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        v = rb.velocity;
        moveSpeed = 2;

        //�ǔ�
        player = FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
    
        if (player != null)
        {
            //���@�̈ʒu
            Vector3 playerPosition = player.transform.position;

            //�G�̈ʒu
            Vector3 enemyPosition = transform.position;

            //�v���C���[�Ɍ����������x�N�g�����v�Z
            Vector3 direction = (playerPosition - enemyPosition).normalized;

            //�G�̑��x�x�N�g�����X�V
            rb.velocity = direction * moveSpeed;

            //�G�̌������v���C���[�Ɍ�����
            transform.LookAt(playerPosition);

        }
        


    }

}