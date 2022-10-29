
using UnityEngine;

public class CamaraTakip : MonoBehaviour
{
    public GameObject hedef;
    Vector3 uzaklik;
    // Start is called before the first frame update
    void Start()
    {
        uzaklik = transform.position - hedef.transform.position;//kamera ile oyuncu aras�ndaki uzakl�k. bu sabit kalacak
    }

    // Update is called once per frame

    private void LateUpdate()
    {
        if(Player.dustuMu)
        {
            return;
        }
        //kamera takip i�lemi
        transform.position = hedef.transform.position + uzaklik;//kameran�n yeni pozisyonu player�n yeni pozisyonu+uzakl�k kadar

    }
}
