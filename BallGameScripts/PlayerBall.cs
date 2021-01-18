using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    Rigidbody rigid;
    bool isJump;
    public float JumpPower;
    public int itemCount;
    public GameManagerLogic manager;
    AudioSource audio;
    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        itemCount = 0;

    }
     void Update()
    {
        // 위에서 isJump는 false로 선언. !isJump는 true
        if(Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, JumpPower, 0), ForceMode.Impulse);
        }
    }
    // 물리 기반으로 움직일 것 이므로
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }
    // 바닥에 공이 도착하면 다시 점프하기 위하여 생성
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")                                 // other.name으로 하면 같은 Coin인데 이름이 다르면 효과 X
        {
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
        }
        else if (other.tag == "Point" )
            if(itemCount == manager.TotalItemCount)
            {
                if (manager.Stage == 2)
                {
                    SceneManager.LoadScene(0);
                }
                // 재시작
                else       
                {
                    SceneManager.LoadScene(manager.Stage+1);
                }
            }
            else
            {
                SceneManager.LoadScene(manager.Stage);
            }
        }
    }

