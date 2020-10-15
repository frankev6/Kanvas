//TODO: make owner, visuals
//0 viewer, 1 editor, 2 owner
//change project accessibility
function CPA(userId, role, removeUser, isPublic) {
	if (userRole == 0) {
		return;
	}

	$.post("/Board/ChangeProjectAccessibilty/",
		{
			projectId: projectId,
			userId: userId,
			userRole: role,
			removeUser: removeUser,
			isPublic: isPublic
		},
		function (data) {
			if (data.success) {
			return true;
			} else {
				//no permission modal
				
			}
		});
	return false;
}

var adduser_input = document.getElementById("share-adduser-input");
if (userRole == 0) {

	adduser_input.disabled = true;
}
adduser_input.addEventListener("keyup", function (event) {
	if (userRole == 0) {
		return;
	}

	if (event.keyCode === 13) {

		event.preventDefault();

		$.post("/Board/ChangeProjectAccessibilty/",
			{
				projectId: projectId,
				userId: adduser_input.value,
				userRole: 0,//viewer
				removeUser: false,
				isPublic: isPublic
			},
			function (data) {
				if (data.success) {
					var info = JSON.parse(data.responseText);

					document.getElementById("share-user-list").innerHTML += 
						"<div id='userbox"+info.Id+"' class='d-flex text-dark justify-content-between user-modal-item' style='margin-bottom:10px'>"
					+"<div class='d-flex'>"
					+"<div class='small-user-thumnail'>"+info.Username.charAt(0).toUpperCase()+"</div>"
					+"<div style='margin-top:3px;margin-left:8px'>"+ info.Username +"</div>"
					+"</div>"
					+"<div class='user-dropdown-modal dropdown my-2 my-sm-0' style='margin-top:2px!important; cursor:pointer'>"
					+"<div role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>"
					+"<div id='dropdown"+info.Id+"'>Viewer <i class='fas fa-caret-down'></i></div>"
					+"</div>"
					+"<div class='dropdown-menu dropdown-menu-right' aria-labelledby='navbarDropdown'>"
					+"<div id='" + info.Id +"' class='share-edit-option dropdown-item'>Editor</div>"
					+"<div id='"+info.Id+"' class='share-viewer-option dropdown-item'>Viewer</div>"
					+"<div class='dropdown-divider'></div>"
					+"<div id='"+info.Id+"' class='share-remove-option dropdown-item'>Remove</div>"
					+"</div>"
					+"</div>"
					+"</div>"

					adduser_input.value = "";
				}

			});
		
	}
});

$(document).on('click', '.share-edit-option', function (e) {
	if (userRole == 0) {
		return;
	}
	var id = e.target.id;
	CPA(id, 1, false, isPublic);
	var item = document.getElementById("dropdown" + id);
	item.innerHTML = "Editor <i class='fas fa-caret-down'></i>";
});
$(document).on('click', '.share-viewer-option', function (e) {
	if (userRole == 0) {
		return;
	}
	var id = e.target.id;
	CPA(id, 0, false, isPublic)
	var item = document.getElementById("dropdown" + id);
	item.innerHTML = "Viewer <i class='fas fa-caret-down'></i>";
});

$(document).on('click', '.share-remove-option', function (e) {
	if (userRole == 0) {
		return;
	}
	var id = e.target.id;
	CPA(id, 1, true, isPublic);
	document.getElementById("userbox" + id).remove();

});

//public stuff

var publicbtn = document.getElementById('share-public-option').checked = isPublic;
if (userRole != 2) {

	publicbtn.disabled = true;
}

$(document).on('click', '#share-public-option', function () {
	//toggle
	if (userRole != 2) {
		return;
	}
		isPublic = !isPublic;
		CPA(null, null, null, isPublic);
});