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

    public Text enIyiSkorText;//sol üstte en iyi skoru yazdýrmak için


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
        enIyiSkor = PlayerPrefs.GetInt("enIyiSkor");//oyun baþlarken hafýzada kayýtlý olan skoru getirmek için 

        enIyiSkorText.text ="Best Skor: " + enIyiSkor.ToString();//hafýzada olan en iyi skoru ekranda göstermek için 
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
            return; //þart saðlanýyorsa altýndaki hiç bir komut çalýþmaz



        }
        if(Input.GetMouseButtonDown(0))
        {
            //her ekrana dokunulduðunda saða gidiyorsa düz gitmeye baþlayacak düz gidiyorsa saða gidecek
             if(yon.z==0) //düz
             {
                  yon = Vector3.back; //sað
             }
              else
              {
                yon = Vector3.left; //düz
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
            if (enIyiSkor < skor)//skor yeni skordan büyükse
            {
                enIyiSkor = (int)skor;//en iyi skor deðiþkenine skoru ata
                PlayerPrefs.SetInt("enIyiSkor", enIyiSkor);//hafýzadaki puaný güncelle
                PlayerPrefs.Save();//hafýzaya kaydet
            }
            
        }


     
    }
    private void FixedUpdate()
    {
        if(dustuMu)//düþerken sürekli puan artýyor artmasýn diye
        {
            return;
        }
        Vector3 hareket = yon * hiz * Time.deltaTime;//player için pozisyon oluþturuldu
        transform.position += hareket;//hareketi sürekli plaeyrýn pozisyonuna ekleryni sürekli hareket edecek
        hiz += hizlanmaZorlugu * Time.deltaTime; //fixedupdate içerisindeyse her saniye çalýþýr
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
