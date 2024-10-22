using UnityEngine;
using UnityEngine.UI;

public class SkillCooldown : MonoBehaviour
{
    public Image skillImage; // ��ų �������� ��Ÿ�� �̹���
    public Button skillButton; // ��ų�� Ŭ���� ��ư
    public float cooldownTime = 5f; // ��Ÿ�� (��: 5��)

    private float cooldownTimer = 0f; // ���� ��Ÿ���� ������ ����
    private bool isCooldown = false; // ��Ÿ�� ���� Ȯ��

    void Update()
    {
        // ��Ÿ���� ���� ���� ��
        if (isCooldown)
        {
            cooldownTimer -= Time.deltaTime;

            // ��Ÿ���� ������ ��
            if (cooldownTimer <= 0f)
            {
                cooldownTimer = 0f;
                isCooldown = false;
                skillImage.fillAmount = 1f; // �̹��� ���� ���·� ����
                skillButton.interactable = true; // ��ư �ٽ� Ȱ��ȭ
                skillImage.gameObject.SetActive(false); // �̹��� ��Ȱ��ȭ
            }
            else
            {
                // ��Ÿ�� ���� ���� �� �̹��� ������Ʈ
                skillImage.fillAmount = cooldownTimer / cooldownTime; // �̹��� ä���
            }
        }
    }

    // ��ų ��ư�� Ŭ������ �� ȣ���� �Լ�
    public void UseSkill()
    {
        if (!isCooldown) // ��Ÿ���� �ƴ� ���� ��� ����
        {
            // ��ų ��� ���� �ֱ�
            StartCooldown();
        }
    }

    // ��Ÿ�� ����
    void StartCooldown()
    {
        skillImage.gameObject.SetActive(true); // �̹��� Ȱ��ȭ
        isCooldown = true;
        cooldownTimer = cooldownTime;
        skillImage.fillAmount = 1f; // �̹��� �ʱ�ȭ
        skillButton.interactable = false; // ��ư ��Ȱ��ȭ
    }
}
