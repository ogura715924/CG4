using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SordScript : MonoBehaviour
{
    public Rigidbody rb;

    //�p�[�e�B�N��
    public GameObject Particle;

    //�ꏊ
    public PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        // �����v���C���[�̎q�I�u�W�F�N�g�ɂ���
        transform.parent = player.transform;
        transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {

            //�X�R�A
            GameManagerScript.score += 5
                ;

            //�p�[�e�B�N��
            Instantiate(Particle, transform.position, Quaternion.identity);
           
            //�G����
            other.gameObject.SetActive(false);
        }
    }
}
