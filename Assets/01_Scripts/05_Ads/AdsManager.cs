using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AdsManager : MonoBehaviour
{
    public string AppId = "1d88fdbcd";
    

    private void OnApplicationPause(bool pauseStatus)
    {
        IronSource.Agent.onApplicationPause(pauseStatus);
    }

    public void InitAds()
    {
        IronSource.Agent.init(AppId, IronSourceAdUnits.BANNER);
    }
    
    
}
