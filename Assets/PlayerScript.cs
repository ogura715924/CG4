using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject BombParticle;
    public Animator animator;

    private bool isBlock = true;

    private AudioSource audioSource;

    private float stick ;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();

        //�����E
        transform.rotation = Quaternion.Euler(0, 90, 0);

       
    }

    // Update is called once per frame
    void Update()
    {
        stick = Input.GetAxis("Horizontal");
        //�󒆂ŃW�����v�����Ȃ�
        //�v���C���[�̉������փ��C���o��
        Vector3 rayPosition = transform.position;
        float distance = 0.9f;
        Ray ray = new Ray(rayPosition, Vector3.down);
        // Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);

        isBlock = Physics.Raycast(ray, distance);


        if (isBlock == true)
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);
        }
        else
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.yellow);//�A�j���[�V����
        }

        if (GoalScript.isGameClear == false && isBlock == true)
        {
            //�W�����v
            const float JumpSpeed = 9.0f;
            Vector3 v = rb.velocity;

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                v.y = JumpSpeed;

                //�A�j���[�V����
                animator.SetBool("RunJump", true);
                animator.SetBool("Jump", true);
            }
            else
            {
                animator.SetBool("Jump", false);
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || stick < 0 || stick > 0)
                {
                    animator.SetBool("RunJump", false);
                }
            }

            rb.velocity = v;
        }

        //�U��
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("Attack", false);
        }


    }

    void FixedUpdate() 
    {
        //�ړ�
        const float moveSpeed = 10.0f;
        Vector3 v = rb.velocity;

        if (GoalScript.isGameClear == false)
        {
            //�E
            if (Input.GetKey(KeyCode.RightArrow) || stick > 0)
            {
                //����
                transform.rotation=Quaternion.Euler(0,90,0);
                //����
                v.x = moveSpeed;
                //�A�j���[�V����
                animator.SetBool("Run", true);
            }
            //��
            else if (Input.GetKey(KeyCode.LeftArrow) || stick < 0)
            {
                //����
                transform.rotation = Quaternion.Euler(0, -90, 0);
                //����
                v.x = -moveSpeed;
                //�A�j���[�V����
                animator.SetBool("Run", true);
            }
            else
            {
                v.x = 0;
                //�A�j���[�V�����~�߂�
                animator.SetBool("Run",false);
            }
        }
            rb.velocity = v;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "COIN")
        {
            //��
            audioSource.Play();
            other.gameObject.SetActive(false);

            //�X�R�A
            GameManagerScript.score += 1;

            //�p�[�e�B�N��
            Instantiate(BombParticle,transform.position, Quaternion.identity);
        }
    }
}
