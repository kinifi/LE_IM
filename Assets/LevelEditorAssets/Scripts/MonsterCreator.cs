using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using System.Text;
using System.IO;
using Steamworks;
public class MonsterCreator : MonoBehaviour {

    public string author_Name, author_Note, monsterName, monsterDescription, monsterCreated, monsterEnemy, memoryConnection;
    private string path;

    //Steam workshop stuff
    private PublishedFileId_t m_PublishedFileId;
    private UGCUpdateHandle_t m_UGCUpdateHandle;
    private CallResult<CreateItemResult_t> OnCreateItemResultCallResult;
    private CallResult<SubmitItemUpdateResult_t> OnSubmitItemUpdateResultCallResult;
    private ulong BytesProcessed;
    private ulong BytesTotal;
    private string imagePath;
    private bool privateLevel = false;
    private Texture2D previewImage;
    private Vector2 scrollPosition;
    

	// Use this for initialization
	void Start () {

        //set this to give an example to users
        imagePath = Application.dataPath + "/UserLevels/" + "SantaHat.png";

        OnCreateItemResultCallResult = CallResult<CreateItemResult_t>.Create(OnCreateItemResult);
        OnSubmitItemUpdateResultCallResult = CallResult<SubmitItemUpdateResult_t>.Create(OnSubmitItemUpdateResult);

        //Set the author name to the Steam Persona Name. Example: authorName = Kinifi
        author_Name = SteamBasic.getPersonaName();

	}
	
	void OnGUI()
    {

        GUILayout.BeginArea(new Rect(300, 0, Screen.width-300, Screen.height));
        if (previewImage != null)
        {
            GUILayout.Label(previewImage);
        }
        GUILayout.EndArea();



        GUILayout.BeginArea(new Rect(0, 0, 300, Screen.height));
        //scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Height(Screen.height));

        if(GUILayout.Button("Back To Main"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        GUILayout.Space(10);
        GUILayout.Label("Monster Creator");

        ///Monster Name
        GUILayout.Label("Monster Name");
        monsterName = GUILayout.TextField(monsterName, 20);

        ///Description of the monster
        //Monster image location
        GUILayout.Label("Monster Description");
        monsterDescription = GUILayout.TextArea(monsterDescription, 300, GUILayout.Height(100));

        //load the sprite from the method below
        //MUST HAVE EXACT LOCATION
        GUILayout.Label("Image Path. MUST BE EXACT");
        GUILayout.Label("Supported File Types: PNG, JPG, GIF");
        GUILayout.Label("Gif's May not play in the game but will on Steam Workshop");
        imagePath = GUILayout.TextField(imagePath, 260);

        if(imagePath != null || imagePath != "")
        {
            if(GUILayout.Button("Preview Image"))
            {
                previewImage = LoadPNG(imagePath);
            }

        }

        //Created
        //How was the monster created?
        GUILayout.Label("Back Story for Monster:");
        monsterCreated = GUILayout.TextArea(monsterCreated, 300, GUILayout.Height(100));

        //Enemies
        //Does the monster have enemies?
        GUILayout.Label("Monster Enemies");
        monsterEnemy = GUILayout.TextField(monsterEnemy, 100);

        //Memory connection?
        //Is the monster tied to a memory from life?
        GUILayout.Label("Is this connected to a Memory from Imagine Me?");
        memoryConnection = GUILayout.TextField(memoryConnection, 300);

        //Author Name
        GUILayout.BeginHorizontal();
        GUILayout.Label("Author Name: ");
        GUILayout.Label(author_Name);
        GUILayout.EndHorizontal();

        //Author Notes
        GUILayout.Label("Author Notes");
        author_Note = GUILayout.TextArea(author_Note, 200, GUILayout.Height(100));

        //bool to toggle private or public
        privateLevel = GUILayout.Toggle(privateLevel, "Private? ");


        #region Steam Workshop Upload Button
        if (GUILayout.Button("Upload to Steam WorkShop", GUILayout.Height(50)))
        {
            //Debug.Log("Successfully uploaded");


            SteamAPICall_t handle = SteamUGC.CreateItem((AppId_t)265670, EWorkshopFileType.k_EWorkshopFileTypeCommunity);
            OnCreateItemResultCallResult.Set(handle);

            m_UGCUpdateHandle = SteamUGC.StartItemUpdate((AppId_t)265670, m_PublishedFileId);

            bool retMapName = SteamUGC.SetItemTitle(m_UGCUpdateHandle, monsterName);
            bool retDescription = SteamUGC.SetItemDescription(m_UGCUpdateHandle, author_Note);

            if (privateLevel)
            {
                bool retVisibility = SteamUGC.SetItemVisibility(m_UGCUpdateHandle, ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPrivate);
                Debug.Log("" + retVisibility);
            }
            else
            {
                bool retVisibility = SteamUGC.SetItemVisibility(m_UGCUpdateHandle, ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPublic);
                Debug.Log("" + retVisibility);
            }

            bool retTags = SteamUGC.SetItemTags(m_UGCUpdateHandle, new string[] { "Monster", "Enemy" });
            bool retContent = SteamUGC.SetItemContent(m_UGCUpdateHandle, path);
            bool retPreview = SteamUGC.SetItemPreview(m_UGCUpdateHandle, imagePath);
            SteamAPICall_t handleUpdate = SteamUGC.SubmitItemUpdate(m_UGCUpdateHandle, "Test Changenote");
            OnSubmitItemUpdateResultCallResult.Set(handleUpdate);
        }

        #endregion


        //GUILayout.EndScrollView();
        GUILayout.EndArea();
    }

    /// <summary>
    /// Load the Image passed. This will check if the image exists also
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public Texture2D LoadPNG(string filePath)
    {

        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        return tex;
    }


    /// <summary>
    /// DO NOT CALL. save the XML by finding all the gameobjects in the level with the "Block" Tag
    /// </summary>
    private void saveXML()
    {
        path = Application.dataPath + "/UserMonsters/" + monsterName + ".xml";
        XmlDocument xmlDoc = new XmlDocument();
        XmlElement elmRoot = xmlDoc.CreateElement("Monster");
        xmlDoc.AppendChild(elmRoot);

        XmlElement settings = xmlDoc.CreateElement("Settings");
        XmlElement authorName = xmlDoc.CreateElement("authorName");
        XmlElement authorNote = xmlDoc.CreateElement("authorNote");
        authorName.InnerText = author_Name;
        authorNote.InnerText = author_Note;
        elmRoot.AppendChild(settings);
        settings.AppendChild(authorName);
        settings.AppendChild(authorNote);


        StreamWriter outStream = System.IO.File.CreateText(path);
        xmlDoc.Save(outStream);
        outStream.Close();
        Debug.Log("Finished Save" + Time.realtimeSinceStartup);
    }

    void OnCreateItemResult(CreateItemResult_t pCallback, bool bIOFailure)
    {
        Debug.Log("[" + CreateItemResult_t.k_iCallback + " - CreateItemResult_t] - " + pCallback.m_eResult + " -- " + pCallback.m_nPublishedFileId + " -- " + pCallback.m_bUserNeedsToAcceptWorkshopLegalAgreement);
        m_PublishedFileId = pCallback.m_nPublishedFileId;
    }

    void OnSubmitItemUpdateResult(SubmitItemUpdateResult_t pCallback, bool bIOFailure)
    {
        Debug.Log("[" + SubmitItemUpdateResult_t.k_iCallback + " - SubmitItemUpdateResult_t] - " + pCallback.m_eResult + " -- " + pCallback.m_bUserNeedsToAcceptWorkshopLegalAgreement);
    }

}
