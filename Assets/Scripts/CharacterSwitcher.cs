using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public PlayerMovement player1;
    public PlayerMovement player2;
    public GameObject tpsCamera;

    private int activePlayerIndex = 0;

    void Start()
    {
        // Başlangıçta 1. karakteri aktif yap
        SwitchCharacter(0);
    }

    void Update()
    {
        // Klavyeden bir tuşa basınca karakter değiştir
        if (Input.GetKeyDown(KeyCode.F)) // Veya istediğin başka bir tuş
        {
            activePlayerIndex = 1 - activePlayerIndex;
            SwitchCharacter(activePlayerIndex);
        }
    }

    void SwitchCharacter(int index)
    {
        // Tüm karakterlerin kontrolünü kapat
        player1.isControlled = false;
        player2.isControlled = false;
        
        // Sadece seçili karakterin kontrolünü aç
        if (index == 0)
        {
            player1.isControlled = true;
            // Kamerayı 1. karakterin takip etmesi için ayarla
            tpsCamera.transform.SetParent(player1.transform);
        }
        else
        {
            player2.isControlled = true;
            // Kamerayı 2. karakterin takip etmesi için ayarla
            tpsCamera.transform.SetParent(player2.transform);
        }

        // Kamera pozisyonunu ve rotasyonunu sıfırla
        tpsCamera.transform.localPosition = new Vector3(0, 3, -5);
        tpsCamera.transform.localEulerAngles = new Vector3(33, 0, 0);
    }
}