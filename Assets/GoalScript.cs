using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoalScript : MonoBehaviour
{
    public GameObject gameClearText;

    //staticでほかのクラスでも
    public static bool isGameClear = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameClearText.SetActive(true);
            isGameClear = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameClear=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
