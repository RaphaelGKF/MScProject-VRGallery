using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArtInfoLarge : MonoBehaviour
{
    [SerializeField] private ArtInfoData artInfo;
    [SerializeField] private GameObject image;
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text artist;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text songTitle;
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
        songTitle.text = artInfo.songname;

    }
}
