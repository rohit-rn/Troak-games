using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class Testing : MonoBehaviour
{

    // [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Renderer myRenderer;

    private void Start() {
        /*
        string url = "http://google.com/";
        WebRequests.Get(url, (string error) => {
            // Error
            Debug.Log("Error: " + error);
            textMesh.SetText("Error: " + error);
        }, (string text) => { 
            // Successfully contacted URL
            Debug.Log("Received: " + text);
            textMesh.SetText(text);
        });
        */

        // string url = "https://dfstudio-d420.kxcdn.com/wordpress/wp-content/uploads/2019/06/digital_camera_photo-980x653.jpg";
        string url = "https://wallpapers.com/images/featured-full/blank-white-background-xbsfzsltjksfompa.jpg";
        WebRequests.GetTexture(url, (string error) => { 
            // Error
            Debug.Log("Error: " + error);
        }, (Texture2D texture2D) => {
            // Successfully contacted URL
            // Debug.Log("Success!");
            // Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(.5f, .5f), 10f);
            // spriteRenderer.sprite = sprite;

            Debug.Log("Success");

            // Get the material of the Renderer
            Material myMaterial = myRenderer.material;

            // Set the new albedo texture
            myMaterial.mainTexture = texture2D;
        });
    }

}
