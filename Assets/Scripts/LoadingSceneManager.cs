using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneManager : MonoBehaviour
{
    // ���� ���� ��ư�� Ŭ���� �� ȣ��Ǵ� �޼���
    public void OnStartGameButtonClicked()
    {
        // "SampleScene"���� �� ��ȯ
        SceneManager.LoadScene("SampleScene");
    }
}