using System.IO;
using UnityEngine;

public class Jem_TextureLoader : MonoBehaviour
{
    // private string relativePath = "StreamingAssets/GameAssets/JemColor.png";  // Relative to StreamingAssets

    void Start()
    {
        // Combine the relative path with the StreamingAssets path
        string Path = "/c/Users/aamir/tempReactApp/react-unity-app/public/StreamingAssets/GameAssets/JemColor.png";
        // Debug.Log(Path);
        // Debug.Log(relativePath);

        // Check if the file exists
        if (File.Exists(Path))
        {
            // Load the texture from the file
            byte[] fileData = File.ReadAllBytes(Path);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);

            // Apply the texture to the object's material
            GetComponent<Renderer>().material.mainTexture = texture;
            GetComponent<Renderer>().material.SetTexture("_EmissionMap", texture);
        }
        else
        {
            Debug.LogError("File not found: " + Path);
        }
    }
}
