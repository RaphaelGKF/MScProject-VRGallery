using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "My Objects/Art Info")]
public class ArtInfoData : ScriptableObject
{
    // ART INFO DATA
    public Texture image;
    public string title;
    public string artist;
    [Multiline]
    public string description;
    public string songname;
}
