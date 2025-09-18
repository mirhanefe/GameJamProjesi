using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectionVisualizer : MonoBehaviour
{
    // Hangi objelerin birbirine bağlanacağını belirten değişkenler
    public Transform target1;
    public Transform target2;

    // Patlama mesafesi
    public float maxDistance = 10f;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Line Renderer'ın pozisyonlarını her karede günceller
        if (target1 != null && target2 != null)
        {
            lineRenderer.SetPosition(0, target1.position);
            lineRenderer.SetPosition(1, target2.position);

            // İki karakter arasındaki mesafeyi hesapla
            float currentDistance = Vector3.Distance(target1.position, target2.position);

            // Mesafenin patlama limitini aşıp aşmadığını kontrol et
            if (currentDistance > maxDistance)
            {
                // Mesafeyi aştıysa oyunu yeniden başlat
                Debug.Log("Bağlantı koptu! Oyun yeniden başlıyor.");
                RestartLevel();
            }
            
            // Mesafeye göre çizgi rengini ayarla
            float colorT = currentDistance / maxDistance; // 0 ile 1 arasında bir değer
            lineRenderer.startColor = Color.Lerp(Color.green, Color.red, colorT);
            lineRenderer.endColor = Color.Lerp(Color.green, Color.red, colorT);
        }
    }
    
    // Seviyeyi yeniden başlatan metod
    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}