using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f; // 시작 버튼 후 연출 대기
    
    /// <summary>
    /// 메인 메뉴에서 게임 시작
    /// </summary>
    public void LoadGame()
    {
        StartCoroutine(WaitAndLoad("Level1", sceneLoadDelay));
    }

    /// <summary>
    /// 메인 메뉴로 즉시 이동
    /// </summary>
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    // 일정 시간 기다린 뒤 지정 씬 로드
    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

}
