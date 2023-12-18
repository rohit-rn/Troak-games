using System.IO;
using UnityEngine;

public class Block_TextureLoader : MonoBehaviour
{
    // private string relativePath = "StreamingAssets/GameAssets/BlocksColor.png";  // Relative to StreamingAssets

    void Start()
    {
        // Combine the relative path with the StreamingAssets path
        string Path = "/c/Users/aamir/tempReactApp/react-unity-app/public/StreamingAssets/GameAssets/BlocksColor.png";

        // Check if the file exists
        if (File.Exists(Path))
        {
            // Load the texture from the file
            byte[] fileData = File.ReadAllBytes(Path);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);

            // Apply the texture to the object's material
            GetComponent<Renderer>().material.mainTexture = texture;
        }
        else
        {
            Debug.LogError("File not found: " + Path);
        }
    }
}
