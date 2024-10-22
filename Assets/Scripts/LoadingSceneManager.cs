using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneManager : MonoBehaviour
{
    // 게임 시작 버튼이 클릭될 때 호출되는 메서드
    public void OnStartGameButtonClicked()
    {
        // "SampleScene"으로 씬 전환
        SceneManager.LoadScene("SampleScene");
    }
}