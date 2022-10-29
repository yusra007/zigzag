using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    float hiz;
    
    Vector3 yon;
    
    public ZeminOlusturma zeminOlusturr;
    
    public static bool dustuMu = true;
    
    public float hizlanmaZorlugu;

    float skor=0f,artisMiktari=1f;

    [SerializeField]
    Text skorText,bestScoreText,scoreText;

    int enIyiSkor=0;

    public Text enIyiSkorText;//sol �stte en iyi skoru yazd�rmak i�in


    public GameObject playGamePanel, restartGamePanel;



    void Start()
    {
        bestScoreText.text="Best Score: " + PlayerPrefs.GetInt("enIyiSkor").ToString();


        if (RestartGame.isRestart == true)
        {
            dustuMu = false;
            playGamePanel.SetActive(false);
            skorText.gameObject.SetActive(true);
            enIyiSkorText.gameObject.SetActive(true);

        }
        yon = Vector3.left;
        enIyiSkor = PlayerPrefs.GetInt("enIyiSkor");//oyun ba�larken haf�zada kay�tl� olan skoru getirmek i�in 

        enIyiSkorText.text ="Best Skor: " + enIyiSkor.ToString();//haf�zada olan en iyi skoru ekranda g�stermek i�in 
    }

    public void startGame()
    {
        dustuMu = false;
        playGamePanel.SetActive(false);
        skorText.gameObject.SetActive(true);
        enIyiSkorText.gameObject.SetActive(true);
    }
   
    void Update()
    {
        if (dustuMu)
        {
            return; //�art sa�lan�yorsa alt�ndaki hi� bir komut �al��maz



        }
        if(Input.GetMouseButtonDown(0))
        {
            //her ekrana dokunuldu�unda sa�a gidiyorsa d�z gitmeye ba�layacak d�z gidiyorsa sa�a gidecek
             if(yon.z==0) //d�z
             {
                  yon = Vector3.back; //sa�
             }
              else
              {
                yon = Vector3.left; //d�z
              }

        }
        if (transform.position.y<-26f)
        {
            dustuMu = true;
            restartGamePanel.SetActive(true);
            Destroy(gameObject,1f);
            skorText.gameObject.SetActive(false);
            enIyiSkorText.gameObject.SetActive(false);

            scoreText.text = "Score: " + ((int)skor).ToString();
            if (enIyiSkor < skor)//skor yeni skordan b�y�kse
            {
                enIyiSkor = (int)skor;//en iyi skor de�i�kenine skoru ata
                PlayerPrefs.SetInt("enIyiSkor", enIyiSkor);//haf�zadaki puan� g�ncelle
                PlayerPrefs.Save();//haf�zaya kaydet
            }
            
        }


     
    }
    private void FixedUpdate()
    {
        if(dustuMu)//d��erken s�rekli puan art�yor artmas�n diye
        {
            return;
        }
        Vector3 hareket = yon * hiz * Time.deltaTime;//player i�in pozisyon olu�turuldu
        transform.position += hareket;//hareketi s�rekli plaeyr�n pozisyonuna ekleryni s�rekli hareket edecek
        hiz += hizlanmaZorlugu * Time.deltaTime; //fixedupdate i�erisindeyse her saniye �al���r
        skor += artisMiktari * hiz * Time.deltaTime;

        skorText.text = "Skor:"+ ((int)skor).ToString();
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("zemin"))
        {
          StartCoroutine(  yokEt(collision.gameObject));
            zeminOlusturr.zeminOlustur();
        }
    }
    IEnumerator yokEt(GameObject obje)
    {
        yield return new WaitForSeconds(0.3f);
        obje.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(1f);
        Destroy(obje);
    }
}
