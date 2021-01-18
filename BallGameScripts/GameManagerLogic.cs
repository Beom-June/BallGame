using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerLogic : MonoBehaviour
{
    public int TotalItemCount;
    public int Stage;
    public Text StageCountText;
    public Text PlayerCountText;

    // 플레이어가 떨어질 시
     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(Stage);
        }
    }
    public void GetItem(int count)
    {
        PlayerCountText.text = count.ToString();
    }
    void Awake()
    {
        StageCountText.text = "/" + TotalItemCount;
    }
}
