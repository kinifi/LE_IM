using UnityEngine;
using System.Collections;
using Steamworks;

public class SteamWorkshopUpload : MonoBehaviour {
	static readonly AppId_t s_AppId = new AppId_t(265670);

	public enum EState {
		Initialized,
		Failed,
		Creating,
		Uploading,
		Complete,
	}
	private EState m_State;
	public EState State { get { return m_State; } }

	private PublishedFileId_t m_tmpPublishedFileId;
	private bool m_tmpNeedsToAcceptTOS;
	private UGCUpdateHandle_t m_tmpUpdateHandle;

	private string m_tmpContentFolder;
	private string m_tmpPreviewFile;
	private string m_tmpName;
	private string m_tmpDescription;
	private ERemoteStoragePublishedFileVisibility m_tmpVisibility;

	private CallResult<CreateItemResult_t> m_CrateItemResult;
	private CallResult<SubmitItemUpdateResult_t> m_SubmitItemUpdateResult;

	public void Init() {
		m_CrateItemResult = CallResult<CreateItemResult_t>.Create();
		m_SubmitItemUpdateResult = CallResult<SubmitItemUpdateResult_t>.Create();

		Reset();
	}

	private void Reset() {
		m_State = EState.Initialized;
		m_tmpPublishedFileId = PublishedFileId_t.Invalid;
		m_tmpNeedsToAcceptTOS = false;
		m_tmpUpdateHandle = UGCUpdateHandle_t.Invalid;

		m_tmpContentFolder = "";
		m_tmpPreviewFile = "";
		m_tmpName = "";
		m_tmpDescription = "";
		m_tmpVisibility = ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPrivate;

		m_CrateItemResult.Cancel();
		m_SubmitItemUpdateResult.Cancel();
	}

#region CREATION
	public void CreateWorkshopItem(string contentFolder, string previewFile, string name, string description, ERemoteStoragePublishedFileVisibility visibility) {
		Reset();
		m_State = EState.Creating;

		m_tmpContentFolder = contentFolder;
		m_tmpPreviewFile = previewFile;
		m_tmpName = name;
		m_tmpDescription = description;
		m_tmpVisibility = visibility;

		SteamAPICall_t handle = SteamUGC.CreateItem(s_AppId, EWorkshopFileType.k_EWorkshopFileTypeCommunity);
		m_CrateItemResult.Set(handle, OnCreateItemResult);
	}

	private void OnCreateItemResult(CreateItemResult_t pCallback, bool bIOFailed) {
		print("OnCreateItemResult - m_eResult: " + pCallback.m_eResult + " | m_nPublishedFileId: " + pCallback.m_nPublishedFileId + " | m_bUserNeedsToAcceptWorkshopLegalAgreement: " + pCallback.m_bUserNeedsToAcceptWorkshopLegalAgreement);

		if (bIOFailed) {
			//ESteamAPICallFailure failureReason = SteamUtils.GetAPICallFailureReason(m_CrateItemResult.Handle);
			//Debug.LogError("OnCreateItemResult bIOFailed = true. Reason: " + failureReason);
			m_State = EState.Failed;
			return;
		}

		if (pCallback.m_eResult != EResult.k_EResultOK) {
			Debug.LogError("OnCreateItemResult m_eResult != k_EResultOK");
			m_State = EState.Failed;
			return;
		}

		m_tmpPublishedFileId = pCallback.m_nPublishedFileId;
		m_tmpNeedsToAcceptTOS = pCallback.m_bUserNeedsToAcceptWorkshopLegalAgreement;

		UpdateWorkshopItem();
	}
#endregion // CREATION

#region UPLOAD
	public EItemUpdateStatus GetWorkshopProgress(out ulong bytesProcessed, out ulong bytesTotal) {
		return SteamUGC.GetItemUpdateProgress(m_tmpUpdateHandle, out bytesProcessed, out bytesTotal);
	}

	private void UpdateWorkshopItem() {
		m_State = EState.Uploading;

		m_tmpUpdateHandle = SteamUGC.StartItemUpdate(s_AppId, m_tmpPublishedFileId);

		// TODO: Check return values of these?
		SteamUGC.SetItemContent(m_tmpUpdateHandle, m_tmpContentFolder);
		SteamUGC.SetItemPreview(m_tmpUpdateHandle, m_tmpPreviewFile);
		SteamUGC.SetItemTitle(m_tmpUpdateHandle, m_tmpName);
		SteamUGC.SetItemDescription(m_tmpUpdateHandle, m_tmpDescription);
		SteamUGC.SetItemVisibility(m_tmpUpdateHandle, m_tmpVisibility);
		//SteamUGC.SetItemTags(m_tmpUpdateHandle, ); // TODO:

		SteamAPICall_t handle = SteamUGC.SubmitItemUpdate(m_tmpUpdateHandle, "");
		m_SubmitItemUpdateResult.Set(handle, OnSubmitItemUpdateResult);
	}

	private void OnSubmitItemUpdateResult(SubmitItemUpdateResult_t pCallback, bool bIOFailed) {
		m_State = EState.Complete;

		print("OnSubmitItemUpdateResult - m_eResult: " + pCallback.m_eResult + " | m_bUserNeedsToAcceptWorkshopLegalAgreement: " + pCallback.m_bUserNeedsToAcceptWorkshopLegalAgreement);
		
		if (bIOFailed) {
			//ESteamAPICallFailure failureReason = SteamUtils.GetAPICallFailureReason(m_CrateItemResult.Handle);
			//Debug.LogError("OnSubmitItemUpdateResult bIOFailed = true. Reason: " + failureReason);
			m_State = EState.Failed;
			return;
		}

		if (pCallback.m_eResult != EResult.k_EResultOK) {
			Debug.LogError("OnSubmitItemUpdateResult m_eResult != k_EResultOK");
			m_State = EState.Failed;
			return;
		}

		m_tmpNeedsToAcceptTOS = pCallback.m_bUserNeedsToAcceptWorkshopLegalAgreement;

	}

#endregion
}
