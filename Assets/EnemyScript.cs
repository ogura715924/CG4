using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody rb;

    private float moveSpeed;
    private Vector3 v ;
    private float Max;
    private float Min;
    private float currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        v = rb.velocity;
        moveSpeed = 2;

        Max =  10;
        Min = -10;

        // ���݂̈ʒu���擾
        currentPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        v.x = moveSpeed;


        // �������݂̈ʒu��Max�܂���Min�𒴂�����A���x�𔽓]������
        if (currentPosition >= currentPosition+Max || currentPosition <= currentPosition+Min)
        {
            moveSpeed *= -1;
        }

        rb.velocity = v;
    }

}