using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SordScript : MonoBehaviour
{
    public Rigidbody rb;

    //パーティクル
    public GameObject Particle;

    //場所
    public PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        // 剣をプレイヤーの子オブジェクトにする
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

            //スコア
            GameManagerScript.score += 5
                ;

            //パーティクル
            Instantiate(Particle, transform.position, Quaternion.identity);
           
            //敵消す
            other.gameObject.SetActive(false);
        }
    }
}
