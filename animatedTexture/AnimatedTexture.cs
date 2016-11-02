using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class AnimatedTexture : MonoBehaviour {
	public Material mainmaterial;
	public string path;
	public string extension = "png";

	private int counter;
	private List<Texture2D> textureList = new List<Texture2D>();


	// Use this for initialization
	void Start () {
		DirectoryInfo dir = new DirectoryInfo(path);

		FileInfo[] info = dir.GetFiles("*." + extension);

		foreach (FileInfo f in info) {
			WWW file = new WWW ("file://" + f.FullName);
			textureList.Add (file.texture);
		}

		InvokeRepeating ("Texturechanger", 0, .05f);
	}

	// Update is called once per frame
	void Update () {

	}

	void Texturechanger()
	{
		if (++counter >= textureList.Count) {
			counter = 0;
		}
		mainmaterial.SetTexture ("_MainTex", textureList [counter]);
	}
}
