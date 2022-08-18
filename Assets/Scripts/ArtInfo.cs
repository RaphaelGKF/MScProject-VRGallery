using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArtInfo : MonoBehaviour
{
    [SerializeField] private ArtInfoData artInfo;
    [SerializeField] private GameObject image;
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text artist;
    [SerializeField] private TMP_Text description;
    [SerializeField] private Transform frame;

    // Start is called before the first frame update
    void Start()
    {
        Renderer rend = image.GetComponent<Renderer>();
        Material material = rend.material;
        material.mainTexture = artInfo.image;

        title.text = artInfo.title;
        artist.text = artInfo.artist;
        description.text = artInfo.description;
       // frame.localScale = TextureToScale(artInfo.image, frame.localScale);
    }

   // private Vector3 TextureToScale(Texture texture, Vector3 scale)// This takes the original frame scale and modifies the X,Y scale but keeps the depth Z.
   // {
    //    if (texture.width > texture.height)
     //   {
     //       scale.x = 1f;
     //       scale.y = (float)texture.height / (float)texture.height;
     //   }
     //   else
     //   {
       //     scale.x = (float)texture.width / (float)texture.height;
     //       scale.y = 1f;
     //   }
     //   return scale;
   // }
}
