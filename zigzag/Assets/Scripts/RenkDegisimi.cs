
using UnityEngine;

public class RenkDegisimi : MonoBehaviour
{
    public Color[] renkler;
    Color ilkRenk, ikinciRenk;
    int birinci_Renk;

    public Material zemin_material;

    // Start is called before the first frame update
    void Start()
    {
        birinci_Renk = Random.Range(0,renkler.Length);

        Camera.main.backgroundColor = renkler[birinci_Renk];

        zemin_material.color = renkler[birinci_Renk];

        ikinciRenk = renkler[ikinciRenkSec()];

    }

    // Update is called once per frame
    void Update()
    {
        Color fark = zemin_material.color - ikinciRenk;

        if ((Mathf.Abs(fark.r)-Mathf.Abs(fark.g)+Mathf.Abs(fark.b))<0.2)
        {
            ikinciRenk = renkler[ikinciRenkSec()];
        }
        zemin_material.color = Color.Lerp(zemin_material.color, ikinciRenk, 0.003f);

        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, ikinciRenk, 0.0007f);

    }
    int ikinciRenkSec()
    {
        int ikincilRenk;

        ikincilRenk = Random.Range(0, renkler.Length);

        while (ikincilRenk==birinci_Renk)
        {
            ikincilRenk = Random.Range(0, renkler.Length);
        }
        return ikincilRenk;
    }
}
