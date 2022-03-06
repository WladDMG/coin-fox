using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour
{
    string gameId = "4223297";
    string placementId = "BannerPlay";
    bool testMode = false;

    IEnumerator Start()
    {
        Advertisement.Initialize(gameId, testMode);
        while (!Advertisement.IsReady(placementId))
            yield return null;

        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);

        Advertisement.Banner.Show(placementId);
    }
}
