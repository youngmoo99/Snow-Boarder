using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    void Awake()
    {
        BackgroundMusicSingleton();
    }

    /// <summary>
    /// 배경 음악 오브젝트를 싱글톤으로 유지.
    /// - 이미 인스턴스가 있다면 새로 생긴 것은 제거
    /// - 최초 1개만 씬 전환에도 유지
    /// </summary>
    void BackgroundMusicSingleton()
    {   
        // 현재 씬에 같은 타입의 오브젝트 개수
        int instanceCount = FindObjectsOfType(GetType()).Length;
        
        if (instanceCount > 1)
        {   
            // 중복 방지 : 잠시 비활성화 후 자기 자신 파괴
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {   
            // 첫 인스턴스는 씬 로드 시에도 유지
            DontDestroyOnLoad(gameObject);
        }
    }

}
