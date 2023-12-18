using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainOrContinue : MonoBehaviour
{

    public String brandName, campaingId, userId;

    public void TravelToWebsite() => Application.OpenURL("https://" + brandName + ".troak.club/" + campaingId + "/" + userId);
}