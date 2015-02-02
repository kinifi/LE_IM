using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Steamworks;


public class Level_Intro : MonoBehaviour {

	public GameObject introPanel;
    public GameObject gameManager, enemyCreator;
	public GUISkin skin;

	//SteamUGC
    private CallResult<SteamUGCRequestUGCDetailsResult_t> OnSteamUGCRequestUGCDetailsResultCallResult;
    private List<CallResult<SteamUGCRequestUGCDetailsResult_t>> m_RequestUGGDetailsResult;
    private List<CreatedLevel> m_CreatedLevels;

    //GUI vars
    public bool doneLoading = false;
	private Vector2 scrollPosition;

	public Button _levelButton;

	// Use this for initialization
	void Start () {

        m_RequestUGGDetailsResult = new List<CallResult<SteamUGCRequestUGCDetailsResult_t>>();
        m_CreatedLevels = new List<CreatedLevel>();
	}

    //Creation object to use for each level
    public class CreatedLevel
    {
        public string title;
        public string Description;
        public string path;
        public string xmlPath;
        public string previewImagePath;
        public ulong unusedSizeOnDisk;
        public bool unusedLegacyItem;
        public PublishedFileId_t publishFileID;
		public string Tags;
    }

    public void enableGameManager()
    {
        gameManager.SetActive(true);
        Debug.Log("Enabled Game Manager");
    }

    public void enableEnemyCreator()
    {
        enemyCreator.SetActive(true);
        Debug.Log("Enabled Enemy Creator");
    }

	/// <summary>
	/// Toggles the intro panel.
	/// </summary>
	public void toggleIntroPanel ()
	{

		if(introPanel.activeSelf)
		{
			introPanel.SetActive(false);
		}
		else
		{
			introPanel.SetActive(true);
		}

	}

	/// <summary>
	/// Queries the steam UGC.
	/// </summary>
	public void QuerySteamUGC()
	{
		Debug.Log("Started SteamUGC Query");

        //Check how many items are being downloaded right now
        if(m_RequestUGGDetailsResult.Count > 0)
        {
            //debug log the items being downloaded
            Debug.Log("Number of Items Downloaded right now: " + m_RequestUGGDetailsResult.Count);
        }

        //If an item is being downloaded. Clear it so we don't have to deal with it. 
        m_RequestUGGDetailsResult.Clear();

        //get the number of items downloaded already
        uint nSubscriptions = SteamUGC.GetNumSubscribedItems();
        Debug.Log("Subscribed Items: " + nSubscriptions);

        PublishedFileId_t[] fileIds = new PublishedFileId_t[nSubscriptions];
        uint ret = SteamUGC.GetSubscribedItems(fileIds, nSubscriptions);
        if(ret != nSubscriptions)
        {
            Debug.LogWarning("Subscriptions Returned: " + ret + "| Expected: " + nSubscriptions);
        }

        for (int i = 0; i < nSubscriptions; i++)
        {

            //print("Looping over: " + i + " | " + fileIds[i]);

            CreatedLevel _creation = new CreatedLevel();
            bool installed = SteamUGC.GetItemInstallInfo(fileIds[i], out _creation.unusedSizeOnDisk, out _creation.path, 300, out _creation.unusedLegacyItem);
            //Debug.Log("Creation Path: " + _creation.path + " | Creation Unused Size On Disk: " + _creation.unusedSizeOnDisk + "| Creation Unused Legacy Item: " + _creation.unusedLegacyItem);


            if(!installed)
            {
                //TODO do something if the user is subscribed to an item but does not have it downloaded
                Debug.Log("Not Installed");
            }

            int index = i;

            //Debug.Log("Get Subscriptions");

            var subscriptionDetails = CallResult<SteamUGCRequestUGCDetailsResult_t>.Create(OnSteamUGCRequestUGCDetailsResult);
            subscriptionDetails.Set(SteamUGC.RequestUGCDetails(fileIds[i], 0));
            m_RequestUGGDetailsResult.Add(subscriptionDetails);
            _creation.publishFileID = fileIds[i];


            //m_RequestUGGDetailsResult.Remove(subscriptionDetails);

            //add the level we got from WorkShop Servers the the Created Levels List for later use
            m_CreatedLevels.Add(_creation);

        }

        //TODO: Create a list of the levels you are subscribed too!
        //TODO: Consume when clicking the levels you are subscribed too!


	}

    void OnSteamUGCRequestUGCDetailsResult(SteamUGCRequestUGCDetailsResult_t pCallback, bool bIOFailure)
    {
		//Debug.Log("SteamUGCRequest: m_CreatedLevels: " +  m_CreatedLevels.Count);
        for (int i = 0; i < m_CreatedLevels.Count; i++)
		{
			
			if (m_CreatedLevels[i].publishFileID != pCallback.m_details.m_nPublishedFileId) 
	        { 
	            continue;
	        }

        	//do this shit here
	        m_CreatedLevels[i].title = pCallback.m_details.m_rgchTitle;
	        m_CreatedLevels[i].Description = pCallback.m_details.m_rgchDescription;
			m_CreatedLevels[i].Tags = pCallback.m_details.m_rgchTags;
			//Debug.Log(m_CreatedLevels[i].Tags);
			
			doneLoading = true;

			/*
			if((i + 1) == m_CreatedLevels.Count)
			{

				Debug.Log("Done Adding Levels");

			}
			else
			{
				Debug.Log("i Value: " + (i + 1) + " | m_CreatedLevels Count: " + m_CreatedLevels.Count);
				//Debug.Log("Not Done Adding Levels");
			}
			*/

			//Debug.Log("Added new Level: " + m_CreatedLevels[i].title);
        	break;
        }

        //Debug.Log("[" + SteamUGCRequestUGCDetailsResult_t.k_iCallback + " - SteamUGCRequestUGCDetailsResult_t] - " + pCallback.m_details + " -- " + pCallback.m_bCachedData);
        //Debug.Log(pCallback.m_details.m_nPublishedFileId + " -- " + pCallback.m_details.m_eResult + " -- " + pCallback.m_details.m_eFileType + " -- " + pCallback.m_details.m_nCreatorAppID + " -- " + pCallback.m_details.m_nConsumerAppID + " -- " + pCallback.m_details.m_rgchTitle + " -- " + pCallback.m_details.m_rgchDescription + " -- " + pCallback.m_details.m_ulSteamIDOwner + " -- " + pCallback.m_details.m_rtimeCreated + " -- " + pCallback.m_details.m_rtimeUpdated + " -- " + pCallback.m_details.m_rtimeAddedToUserList + " -- " + pCallback.m_details.m_eVisibility + " -- " + pCallback.m_details.m_bBanned + " -- " + pCallback.m_details.m_bAcceptedForUse + " -- " + pCallback.m_details.m_bTagsTruncated + " -- " + pCallback.m_details.m_rgchTags + " -- " + pCallback.m_details.m_hFile + " -- " + pCallback.m_details.m_hPreviewFile + " -- " + pCallback.m_details.m_pchFileName + " -- " + pCallback.m_details.m_nFileSize + " -- " + pCallback.m_details.m_nPreviewFileSize + " -- " + pCallback.m_details.m_rgchURL + " -- " + pCallback.m_details.m_unVotesUp + " -- " + pCallback.m_details.m_unVotesDown + " -- " + pCallback.m_details.m_flScore + " -- " + pCallback.m_details.m_unNumChildren);
    }

    void OnGUI()
    {

		GUI.skin = skin;

        GUILayout.BeginArea(new Rect(0, 0, Screen.width/5, Screen.height));

	        if (doneLoading)
	        {

				GUILayout.Label("Workshop Levels");
				
				if(GUILayout.Button("Back to Menu"))
				{
					Application.LoadLevel("LevelCreatorScene");
				}
				scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Height(Screen.height));
				
				if(m_CreatedLevels.Count >= 1)
				{
					//Create Buttons for each level in m_CreatedLevels
					for (int i = 0; i < m_CreatedLevels.Count; i++)
					{
						
						if (GUILayout.Button(m_CreatedLevels[i].title, GUILayout.Height(50)))
						{
							//Debug.Log("Title: " + m_CreatedLevels[i].title + " | " + m_CreatedLevels[i].Description + " | " + m_CreatedLevels[i].path + "/" + m_CreatedLevels[i].title + ".xml");
							PlayerPrefs.SetString("Title", m_CreatedLevels[i].title);
							PlayerPrefs.SetString("Description", m_CreatedLevels[i].Description);
							PlayerPrefs.SetString("Path", m_CreatedLevels[i].path + "/" + m_CreatedLevels[i].title + ".xml");
							Application.LoadLevel("OneOffLevel");
						}
					}
				}
				GUILayout.EndScrollView();
	        }


        GUILayout.EndArea();
    }

}
