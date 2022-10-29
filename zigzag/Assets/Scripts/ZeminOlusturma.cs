
using UnityEngine;

public class ZeminOlusturma : MonoBehaviour
{
    public GameObject sonZemin;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i<=20 ; i++)
        {
            zeminOlustur();
        }
    }

    // Update is called once per frame
   public void zeminOlustur()
    {
        Vector3 yon;
        int randomSayi = Random.Range(0, 2);//0 ya da 1 gelecek

        if(randomSayi==0)
        {
            yon = Vector3.left;
        }
        else
        {
            yon = Vector3.back;

        }
        //son zemini deðiþtirip her seferinde bir o kadar ekler
        sonZemin = Instantiate(sonZemin, sonZemin.transform.position + yon,sonZemin.transform.rotation);
    }
}
