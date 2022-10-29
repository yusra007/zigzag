
using UnityEngine;

public class CamaraTakip : MonoBehaviour
{
    public GameObject hedef;
    Vector3 uzaklik;
    // Start is called before the first frame update
    void Start()
    {
        uzaklik = transform.position - hedef.transform.position;//kamera ile oyuncu arasýndaki uzaklýk. bu sabit kalacak
    }

    // Update is called once per frame

    private void LateUpdate()
    {
        if(Player.dustuMu)
        {
            return;
        }
        //kamera takip iþlemi
        transform.position = hedef.transform.position + uzaklik;//kameranýn yeni pozisyonu playerýn yeni pozisyonu+uzaklýk kadar

    }
}
