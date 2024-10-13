using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public GameObject currentPlant;     // 보유한 식물
    public Sprite currentPlantSprite;   // 보유한 식물 스프라이트
    public Transform tiles;             // 타일

    public LayerMask tileMask;          // 타일 레이어마스트

    public int suns = 100;              // 점수
    public Text sunText;                // 점수 텍스트

    public LayerMask sunMask;
    
    public void BuyPlant(GameObject plant, Sprite sprite)   // 구매시 PlantSlot 컴포넌트로부터 plant와 sprite를 전달받음
    {
        currentPlant = plant;
        currentPlantSprite = sprite;
    }

    private void Update()
    {
        sunText.text = suns.ToString();

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, tileMask);  // 화면상 마우스 클릭한 좌표값(식물 배치용)

        foreach(Transform tile in tiles)    // loop를 돌려서 tile의 SpriteRenderer를 false로 바꿈
            tile.GetComponent<SpriteRenderer>().enabled = false;

        if(hit.collider && currentPlant)    // 식물을 가진 상태에서, 타일에 오브젝트 배치
        {
            hit.collider.GetComponent<SpriteRenderer>().sprite = currentPlantSprite;    // 타일 스프라이트를 Plant오브젝트 Sprite로 변경
            hit.collider.GetComponent<SpriteRenderer>().enabled = true;                 // SpriteRenderer를 true바꿔 보이도록 재설정

            if (Input.GetMouseButtonDown(0) && !hit.collider.GetComponent<Tile>().hasPlant)     // 식물이 없는 타일에 마우스 좌클릭시 실행
            {
                Instantiate(currentPlant, hit.collider.transform.position, Quaternion.identity);    // 식물을 복제하여 배치
                hit.collider.GetComponent<Tile>().hasPlant = true;  // 타일에 식물배치여부를 true로 변경
                currentPlant = null;        // 들고있던 식물을 제거
                currentPlantSprite = null;  // 스프라이트도 제거
            }
        }

        RaycastHit2D sunhit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, sunMask); // 화면상 마우스 클릭한 좌표값(점수 획득용)

        if (sunhit.collider)    // 점수 획득
        {
            if (Input.GetMouseButtonDown(0))
            {
                suns += 25;
                Destroy(sunhit.collider.gameObject);
            }
        }
    }
}
