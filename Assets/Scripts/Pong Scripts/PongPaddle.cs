using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPaddle : MonoBehaviour
{

    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;
    [SerializeField] private Transform playerPaddle;
    public float speed = 7.5f;
    private float topBorderY = 5.8f;
    private float bottomBorderY = -3.75f;
    // Update is called once per frame
    void Update()
    {  
        if(Input.GetKey(upKey) && playerPaddle.position.y < topBorderY)
        {
            playerPaddle.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if(Input.GetKey(downKey) && playerPaddle.position.y > bottomBorderY)
        {
            playerPaddle.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}
