using UnityEngine;
using UnityEngine.UI;

public class SkillCooldown : MonoBehaviour
{
    public Image skillImage; // 스킬 아이콘을 나타낼 이미지
    public Button skillButton; // 스킬을 클릭할 버튼
    public float cooldownTime = 5f; // 쿨타임 (예: 5초)

    private float cooldownTimer = 0f; // 현재 쿨타임을 추적할 변수
    private bool isCooldown = false; // 쿨타임 여부 확인

    void Update()
    {
        // 쿨타임이 진행 중일 때
        if (isCooldown)
        {
            cooldownTimer -= Time.deltaTime;

            // 쿨타임이 끝났을 때
            if (cooldownTimer <= 0f)
            {
                cooldownTimer = 0f;
                isCooldown = false;
                skillImage.fillAmount = 1f; // 이미지 원래 상태로 복원
                skillButton.interactable = true; // 버튼 다시 활성화
                skillImage.gameObject.SetActive(false); // 이미지 비활성화
            }
            else
            {
                // 쿨타임 진행 중일 때 이미지 업데이트
                skillImage.fillAmount = cooldownTimer / cooldownTime; // 이미지 채우기
            }
        }
    }

    // 스킬 버튼을 클릭했을 때 호출할 함수
    public void UseSkill()
    {
        if (!isCooldown) // 쿨타임이 아닐 때만 사용 가능
        {
            // 스킬 사용 로직 넣기
            StartCooldown();
        }
    }

    // 쿨타임 시작
    void StartCooldown()
    {
        skillImage.gameObject.SetActive(true); // 이미지 활성화
        isCooldown = true;
        cooldownTimer = cooldownTime;
        skillImage.fillAmount = 1f; // 이미지 초기화
        skillButton.interactable = false; // 버튼 비활성화
    }
}
