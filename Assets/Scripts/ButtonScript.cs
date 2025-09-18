using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // Hangi kapıyı açacağını belirtmek için bir değişken
    public GameObject targetDoor;

    private void OnTriggerEnter(Collider other)
    {
        // Eğer butona değen nesne "Player" etiketi taşıyorsa
        if (other.gameObject.tag == "Player")
        {
            // Kapıyı kapat (False yaparak görünmez ve geçilebilir hale getir)
            targetDoor.SetActive(false);
            Debug.Log("Kapı açıldı!");
        }
    }
}