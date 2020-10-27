//TODO: get, create, move, delete attachments
var e_list = document.getElementById("attachments-list");

function GetAttachments() {

	$.post("Board/GetCardAttachments/",
		{
			projectId: projectId,
			cardId: openedCardId
		},
		function (data) {

			var attachments = JSON.parse(data.responseText);

			attachments.forEach(
				function (a) {
					e_list.innerHTML += "<div  class='attachment-item'  id='attachment" + a.Id + "'>"
									+ "		<a target='_blank' href='" + a.Url + "' class='d-flex'><div class='attachment-thumbnail' style=' background:url(https://drive.google.com/thumbnail?id="+a.FileId+"); '></div>"
									+ "		<div class='ml-3' style='padding-top:14px;'>" + a.Name + " <i class='fas fa-external-link-alt'></i></div></a>"
									+ "		<div onclick=DeleteAttachment('" + a.Id + "') class='btn btn-danger-a attachment-delete-btn mt-2'><i class='fas fa-trash'></i></div>"
									+ "	</div>";

			});
		});
}

function CreateAttachment(a_url, a_name, a_fileid, a_type,a_embedUrl) {
	if (userRole == 0) {
		return;
	}

	$.post("Board/CreateAttachment/",
		{
			projectId: projectId,
			cardId: openedCardId,
			aUrl: a_url,
			aName: a_name,
			aFileId: a_fileid,
			aType: a_type,
			aEmbedUrl: a_embedUrl
		},
		function () {
		});
}

function MoveAttachment(a_id, other_a_id) {
	if (userRole == 0) {
		return;
	}

	$.post("Board/MoveAttachment/",
		{
			projectId: projectId,
			cardId: openedCardId,
			aId: a_id,
			otherAId: other_a_id
		});
}


function DeleteAttachment(a_id) {
	if (userRole == 0) {
		return;
	}

	$.post("Board/DeleteAttachment/",
		{
			projectId: projectId,
			aId: a_id
		}, function () {

			document.getElementById("attachment" + a_id).remove();


		});

}

function ToggleAddAttachments() {
	var e_addattachment = document.getElementById('add-attachments-list');
	var e_addbtn = document.getElementById("add-attachment-btn");

	if (e_addattachment.classList.contains('a-hide')) {

		e_list.classList.remove('a-show');
		e_list.classList.add('a-hide');
		e_addbtn.style.display = 'none';

		e_addattachment.classList.remove('a-hide');
		e_addattachment.classList.add('a-show');

	} else {

		e_addattachment.classList.remove('a-show');
		e_addattachment.classList.add('a-hide');
		e_addbtn.style.display = 'block';

		e_list.classList.remove('a-hide');
		e_list.classList.add('a-show');
		
	}
}

//GOOGLE DRIVE STUFF
// The Browser API key obtained from the Google API Console.
// Replace with your own Browser API key, or your own key.
var developerKey = 'AIzaSyB2Qj3zeJPmRzXNFG8Kn37sb71u1W-KcwI';

// The Client ID obtained from the Google API Console. Replace with your own Client ID.
var clientId = "286961498643-b11hr09emksrm6hnaq3nomjddvgiqt9q.apps.googleusercontent.com"

// Replace with your own project number from console.developers.google.com.
// See "Project number" under "IAM & Admin" > "Settings"
var appId = "286961498643";

// Scope to use to access user's Drive items.
var scope = ['https://www.googleapis.com/auth/drive'];//take file out for full perms

var pickerApiLoaded = false;
var userAuthed = false;
var oauthToken;

// Use the Google API Loader script to load the google.picker script.
function loadPicker() {
	gapi.load('auth', { 'callback': onAuthApiLoad });
	gapi.load('picker', { 'callback': onPickerApiLoad });
}

function onAuthApiLoad() {
	window.gapi.auth.authorize(
		{
			'client_id': clientId,
			'scope': scope,
			'immediate': false
		},
		handleAuthResult);
}

function onPickerApiLoad() {
	pickerApiLoaded = true;
	createPicker();
}

function handleAuthResult(authResult) {
	if (authResult && !authResult.error) {
		oauthToken = authResult.access_token;
		userAuthed = true;
		createPicker();
	}
}

// Create and render a Picker object for searching images.
function createPicker() {
	if (pickerApiLoaded && oauthToken) {
		var view = new google.picker.View(google.picker.ViewId.DOCS);
		//view.setMimeTypes("image/png,image/jpeg,image/jpg");
		var picker = new google.picker.PickerBuilder()
			// .enableFeature(google.picker.Feature.NAV_HIDDEN)
			//.enableFeature(google.picker.Feature.MULTISELECT_ENABLED)
			.setAppId(appId)
			.setOAuthToken(oauthToken)
			.addView(view)
			.addView(new google.picker.DocsUploadView())
			.setDeveloperKey(developerKey)
			.setCallback(pickerCallback)
			.build();
		picker.setVisible(true);
	}
}

// A simple callback implementation.
function pickerCallback(data) {
	if (data.action == google.picker.Action.PICKED) {

		var file = data.docs[0];
		//create attachment
		CreateAttachment(file.url, file.name, file.id, file.type,file.iconUrl);

	ToggleAddAttachments();
	$('#CardAttachmentsModal').modal('show');
	} else if (data.action == google.picker.Action.CANCEL) {
		ToggleAddAttachments();
		$('#CardAttachmentsModal').modal('show');
	}
}


$(document).on("click", "#add-attachment-googledrive", function () {
	$('#CardAttachmentsModal').modal('hide');

	if (userAuthed == false) {
		loadPicker();
	} else {
		createPicker();
	}
});
$("#CardAttachmentsModal").on('shown.bs.modal', function () {
	GetAttachments();
});
$("#CardAttachmentsModal").on('hidden.bs.modal', function () {
	e_list.innerHTML = "";
});
//GOOGLE DRIVE ENDDD


