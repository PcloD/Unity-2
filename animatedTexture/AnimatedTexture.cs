using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class AnimatedTexture : MonoBehaviour {
    public Material mainmaterial;        /* material to apply the texture to */
    public string path;                  /* path where the files can be found */
    public string extension = "png";     /* extension of the files to load */

    private int counter;
    private List<Texture2D> textureList = new List<Texture2D>();

    void Start () {
        /* get all files in 'path' ending in 'extension' */
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] info = dir.GetFiles("*." + extension);

        /* load each file as texture and add to the texture list */
        foreach (FileInfo f in info) {
            WWW file = new WWW ("file://" + f.FullName); /* use WWW to load files none resource files */
            textureList.Add (file.texture);              /* append to the list */
        }

        InvokeRepeating ("Texturechanger", 0, .05f);
    }

    // Update is called once per frame
    void Update () {

    }

    void Texturechanger()
    {
        mainmaterial.SetTexture ("_MainTex", textureList [counter]);
        if (++counter >= textureList.Count) {
            counter = 0;
        }
    }
}
