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

        //向き右
        transform.rotation = Quaternion.Euler(0, 90, 0);

       
    }

    // Update is called once per frame
    void Update()
    {
        stick = Input.GetAxis("Horizontal");
        //空中でジャンプさせない
        //プレイヤーの下方向へレイを出す
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
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.yellow);//アニメーション
        }

        if (GoalScript.isGameClear == false && isBlock == true)
        {
            //ジャンプ
            const float JumpSpeed = 9.0f;
            Vector3 v = rb.velocity;

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                v.y = JumpSpeed;

                //アニメーション
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

        //攻撃
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
        //移動
        const float moveSpeed = 10.0f;
        Vector3 v = rb.velocity;

        if (GoalScript.isGameClear == false)
        {
            //右
            if (Input.GetKey(KeyCode.RightArrow) || stick > 0)
            {
                //向き
                transform.rotation=Quaternion.Euler(0,90,0);
                //動く
                v.x = moveSpeed;
                //アニメーション
                animator.SetBool("Run", true);
            }
            //左
            else if (Input.GetKey(KeyCode.LeftArrow) || stick < 0)
            {
                //向き
                transform.rotation = Quaternion.Euler(0, -90, 0);
                //動く
                v.x = -moveSpeed;
                //アニメーション
                animator.SetBool("Run", true);
            }
            else
            {
                v.x = 0;
                //アニメーション止める
                animator.SetBool("Run",false);
            }
        }
            rb.velocity = v;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "COIN")
        {
            //音
            audioSource.Play();
            other.gameObject.SetActive(false);

            //スコア
            GameManagerScript.score += 1;

            //パーティクル
            Instantiate(BombParticle,transform.position, Quaternion.identity);
        }
    }
}
