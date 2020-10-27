
var projectId = document.getElementById("projectId").value;
var projectName;
var selectedGroupId;
var labels;
var openedCardId;

	var drakeCard = dragula({
	isContainer: function (el) {
			return el.classList.contains('task-list');
		}
	});

	drakeCard.on("drag", function (el, source) {
	el.className += ' shadow';
	});



	drakeCard.on("dragend", function (el) {
	el.className = el.className.replace(' shadow', '');
	});

drakeCard.on("drop", function (el, target, source, sibling) {
	el.value = target.id;
	siblingId = null;
	if (sibling != null) {
		siblingId = sibling.id.replace("card", "");
	}
	moveCard(
		source.id,
		target.id,
		el.id.replace("card", ""),
		siblingId
	);


	});


	var drakeGroup = dragula({
	isContainer: function (el) {
			return el.classList.contains('group-list');
		},
		moves: function (el, container, handle) {
			return handle.classList.contains('handle');
		}
	});

drakeGroup.on("drop", function (el, target, source, sibling) {
	el.value = target.id;
	groupId = el.id.replace("group", "");

	siblingId = null;
	if (sibling != null) {
		siblingId = sibling.id.replace("group", "");
	}
	moveGroup(
		groupId,
		siblingId);
		

});

	function deleteCard(cardId) {

	$.post("Board/DeleteCard/",
		{
			cardId: cardId
		},
		function () {

			var element = document.getElementById('card' + cardId);
			element.parentNode.removeChild(element);

		});


	}


	$(document).on("click", ".delete-group", function () {
	deleteGroup();
	});
	$(document).on("click", ".color-group", function () {
		changeGroupColor();
	});

function hidePopups() {
	$('.popover').popover('hide');
}

	function changeGroupColor() {
	//	hidePopups();

		//$('#group' + selectedGroupId).style

	}

	function deleteGroup() {
		hidePopups();
	$.post("Board/DeleteGroup/",
		{
			groupId: selectedGroupId
		},
		function () {
			var element = document.getElementById('group' + selectedGroupId);
			element.parentNode.removeChild(element);
			

		});
}


	function moveCard(groupId, newGroupId, cardId, siblingId) {

	$.post("Board/MoveCard/",
		{
			groupId: groupId,
			newGroupId: newGroupId,
			cardId: cardId,
			siblingId: siblingId
		},
		function () {

		});
	}

	function moveGroup(groupId, siblingId) {
	
		$.post("Board/MoveGroup/",
			{
				projectId: projectId,
				groupId: groupId,
				siblingId: siblingId
			},
			function () {
	
			});
	}

	function addGroup() {

	$.post("Board/CreateCardGroup/",
		{
			projectId: projectId,
			name: 'New Group'
		},
		function (data) {
			document.getElementById("card-groups").innerHTML +=

				"<li class='column shadow' id='group" +data.data+"'>"
				+ "<div class='handle column-header' style='cursor:move'>"
				+ "<div class='handle columns' style='margin:0; width:100%'>"
				+ "<h6 onkeydown='if (event.keyCode == 13 || event.keyCode == 27) { $(this).blur(); return false; }' class='handle editable-Gname' style='line-height:1.5rem; width:100%;' spellcheck='false' contenteditable='true'>New Group</h6>"
				+ "<button onclick=selectGroup('" + data.data +"') tabindex='0' data-toggle='popover' class='btn close float-right text-center' style='text-shadow:none; color:white; cursor:pointer; font-size: 18px; width:10%'>"
				+ "<span aria-hidden='true'><i class='fas fa-ellipsis-v'></i></span>"
				+ "</button>"
				+ "</div>"
				+ "</div>"
				+ "<ul class='task-list' id='" + data.data +"'>"
				+ "</ul>"
				+ "<div class='column-button'>"
				+ "<button onclick=addTask('" + data.data +"') class='btn btn-transparent' style='color:#fff'>+ Add card</button>"
				+ "</div>"
				+ "</li>";

			$('[data-toggle="popover"]').popover({
				html: true,
				sanitize: false,
				content: function () {
					return $('#popover-edit-group').html()
				}
			});
		});
}

	function selectGroup(cardgroupId) {
	selectedGroupId = cardgroupId;
	}

function addTask(groupid) {

	$.post("Board/CreateCard/",
		{
			groupId: groupid,
			name: 'New Card'
		},
		function (data) {
			document.getElementById('group' + groupid).children[1].innerHTML +=
				"<li class='task' id='card" + data.data + "' style='display: block'><div contenteditable='true' spellcheck='false' onkeydown='if (event.keyCode == 13 || event.keyCode == 27) { $(this).blur(); return false; }' class='editable-Cname'>New Card</div><div id='card-labels'></div>"
				+ "<div class='task-menu justify-content-between'>"
					+ "<div id='deletecardbtn" + data.data + "' class='task-menu-button-delete task-menu-button'><i class='far fa-trash-alt'></i></div>"
					+ "<div style='display:inline-flex'>"
						+ "<div id='colorcardbtn@(card.Id)' class='task-menu-button task-menu-button-color'>"
						+ "<i class='fas fa-palette'></i>"
						+"<input id='cardColorInput"+data.data+"' type='color' class='form-control card-color-input' style='cursor: pointer !important; transform: translate(-6px, -24px) !important; opacity: 0 !important; border-radius: 0 !important; height: 100% !important; width: 100% !important;'>"
					+ "</div>"
					+ "<div id='labelcardbtn"+data.data+"' class='task-menu-button task-menu-button-label'><i class='fas fa-tag'></i></div>"
					+"<div id='attachmentcardbtn"+data.data+"' class='task-menu-button task-menu-button-attachment'><i class='fas fa-paperclip'></i></div>"
				+ "</div>"
				+ "</div>"
				+ "</li>";
			
		}, "json");

	}

$('[data-toggle="popover"]').popover({
	html: true,
	sanitize: false,
	content: function () {
		return $('#popover-edit-group').html()
	}
});

function deleteProject() {
	$.post("Board/DeleteProject/",
		{
			projectId: projectId
		}, function () {
			window.location.href = 'https://localhost/Kanvas/Dashboard';

	});
}


$('.editable-Pname').on('focusin', function () {
	projectName = $('.editable-Pname').text();
	$('.editable-Pname').addClass('content-editing');
	CardsBeingEdited = true;
});

$('.editable-Pname').on('focusout', function () {
	$(this).removeClass('content-editing');
	CardsBeingEdited = false;
	if ($(this).text() != projectName && $(this).text() != '') {

		$.post("/Board/ChangeProjectName/",
			{
				projectId: projectId,
				name: $(this).text()
			}, function () {

			});
	} else {
		$(this).html('<strong>' + projectName + '</strong>');
		}

});

var editingGroupId;
var editingGroupName;

$(document).on('focusin', '.editable-Gname', function () {
	editingGroupId = document.activeElement.parentNode.parentNode.parentNode.id;
	editingGroupName = document.activeElement.innerHTML;
	CardsBeingEdited = true;
	$(this).addClass('content-editing');
});

$(document).on('focusout', '.editable-Gname', function () {
	$(this).removeClass('content-editing');
	CardsBeingEdited = false;
	if ($(this).text() != editingGroupName && $(this).text() != '') {

		$.post("Board/ChangeGroupName/",
			{
				groupId: editingGroupId.replace("group", ""),
				name: $(this).text()
			}, function () {

			});
	} else {
		$(this).text(editingGroupName);
	}
});

var editingCardName;

$(document).on('focusin', '.editable-Cname', function () {
	editingCardName = $(this).text();
	$(this).addClass('content-editing');
	CardsBeingEdited = true;
});

$(document).on('focusout', '.editable-Cname', function () {
	$(this).removeClass('content-editing');
	CardsBeingEdited = false;
	if ($(this).text() != editingCardName && $(this).text() != '') {

		var text = $(this).text();
		var cardid = this.parentElement.id.replace('card','');


		$.post("Board/ChangeCardName/",
			{
				groupId: this.parentElement.parentElement.id,
				cardId: cardid,
				name: $(this).text()
			}, function () {

			});
	} else {
		$(this).text(editingCardName);
	}
});

var editingLabelName;

$(document).on('focusin', '.editable-Lname', function () {
	editingLabelName = $(this).text();
});

$(document).on('focusout', '.editable-Lname', function () {

	if ($(this).text() != editingLabelName && $(this).text() != '') {

		var id = this.parentElement.id.replace('modal-label', '');
		var newText = $(this).text();

		$.post("Board/ChangeLabelName/",
			{
				labelId: id,
				name: newText
			}, function () {

				document.querySelectorAll('#label' + id).forEach(e => e.innerHTML = newText);
			});
	} else {
		$(this).text(editingCardName);
	}
});

function OpenCardLabelModal(cardid) {
	//give checkmarks to the right labels
	openedCardId = cardid;

	var elements = document.getElementsByClassName("label-name-btn");

	for (var i = 0; i < elements.length; i++) {
		checkmarkModalLabelOFF(elements[i].id.replace('modal-label', ''));
	}

	var labellist = document.getElementById('card-label-list' + cardid);

	if (labellist != null) {
		var el = labellist.getElementsByClassName("badge-pill");
		for (var i = 0; i < el.length; i++) {
			checkmarkModalLabelON(el[i].id.replace('label', ''));
		}
	}
	

	$('#CardLabelModal').modal('show');
}

function OpenCardAttachmentModal(cardid) {
	openedCardId = cardid;
	$('#CardAttachmentsModal').modal('show');
}


//card buttons
$(document).on('click', '.task-menu-button', function () {
	if (this.className.includes('task-menu-button-delete')) {
		var cardtodeleteId = this.id.replace('deletecardbtn', '');
		deleteCard(cardtodeleteId);
	}
	else if (this.className.includes('task-menu-button-label')) {
		var cardid = this.id.replace('labelcardbtn', '');
		OpenCardLabelModal(cardid);
	}
		else if (this.className.includes('task-menu-button-attachment')) {
		var cardid = this.id.replace('attachmentcardbtn', '');
		OpenCardAttachmentModal(cardid)
	}

});


$(document).on('input', '#bgColorInput', function () {
	document.getElementById('board-background').style.background = this.value;

});

$(document).on('input', '.card-color-input', function () {
	var cardid = this.parentElement.id.replace('colorcardbtn', '');
	document.getElementById('card' + cardid).style = 'display:block; background:' + this.value;
});

$(document).on('change', '.card-color-input', function () {
	var cardid = this.parentElement.id.replace('colorcardbtn', '');

	document.getElementById('card' + cardid).style = 'display:block; background:' + this.value;


	$.post("Board/ChangeCardColor/",
		{
			cardId: cardid,
			color: this.value
		},
		function () {
		});

});

$(document).on('change', '#bgColorInput', function () {
	document.getElementById('board-background').style.background = this.value;

	$.post("Board/ChangeColors/",
		{
			projectId: projectId,
			bgcolor: this.value,
			isUrl: false
		},
		function () {
		});

});

function setBackgroundImage(imageurl) {
	$.post("Board/ChangeColors/",
		{
			projectId: projectId,
			bgcolor: 'url('+imageurl+')',
			isUrl: false
		},
		function () {
			document.getElementById('board-background').style = "background: url(" + imageurl + "); background-size:cover; background-repeat:no-repeat; width:100%; height:100%; position:fixed";
		});

}


$(document).on('input', '#group-color-input', function () {

	document.getElementById('group' + selectedGroupId).style = 'background:' + this.value;
});

$(document).on('change', '#group-color-input', function () {
	document.getElementById('group' + selectedGroupId).style = 'background:' + this.value;
	hidePopups();
	$.post("Board/ChangeGroupCardColor/",
		{
			groupId: selectedGroupId,
			color: this.value
		},
		function () {
		});

});

$(document).on('input', '.label-color-btn', function () {
	document.getElementById('modal-label' + this.id).style = 'background:' + this.value;
});

$(document).on('change', '.label-color-btn', function () {
	var id = this.id
	var color = this.value;
	$.post("Board/ChangeLabelColor/",
		{
			labelId: id,
			color: color
		},
		function () {
			document.getElementById('modal-label' + id).style.background = color;
			document.querySelectorAll('#label' + id).forEach(e => e.style.background = color);
		});

});

$(document).on('click', '.label-delete-btn', function () {

	var id = this.id

	$.post("Board/DeleteLabel/",
		{
			labelId: id
		},
		function () {
			document.querySelectorAll('#label' + id).forEach( e => e.remove());
			
			var itemtodelete = document.getElementById('modal-label-cell' + id);
			var itemparent = itemtodelete.parentNode;
			itemparent.removeChild(itemtodelete);

		});
});

$(document).on('click', '.label-create-btn', function () {

	const randomColor = Math.floor(Math.random() * 16777215).toString(16);

	$.post("Board/MakeLabel/",
		{
			projectId: projectId,
			name: "New Label",
			color: '#' + randomColor
		},
		function (data) {
			var label = JSON.parse(data.responseText);

			var labellist = document.getElementById('modal-label-list');

			labellist.innerHTML += "<div id='modal-label-cell"+label.Id+"' class='d-inline-flex' style='margin-top:10px; width:100%'>"

			+"		 <div id='modal-label"+label.Id+"' class='label-name-btn' style='background:"+label.Color+"'>"
			+"		 	<div onkeydown='if (event.keyCode == 13 || event.keyCode == 27) { $(this).blur(); return false; }' contenteditable='true' spellcheck='false' class='editable-Lname'>"+label.Name+"</div>"
			+"		 </div>"
			+"		 <div  class='btn btn-primary' style='margin-right: 5px; padding:0; width:50px;height:40px'>"
			+"		 	<i class='fas fa-palette' style='padding:10px'></i>"
			+"		 	<input id='"+label.Id+"' type='color' class='form-control label-color-btn' style='cursor: pointer !important; transform: translateY(-36px) !important; opacity: 0 !important; border-radius: 0 !important; height: 100% !important; width: 100% !important;'>"
			+"		 </div>"
			+"		<div id='"+label.Id+"' class='btn btn-danger label-delete-btn'><i class='fas fa-trash-alt'></i></div>"
			+"	</div>";
		});
});

$(document).on('click', '.label-name-btn', function (e) {

	if (e.target !== this) {
		return;
	}

	var id = this.id.replace('modal-label','');

		//card doenst have label
		$.post("Board/AddRemoveLabelToCard/",
			{
				labelId: id,
				cardId: openedCardId
			},
			function (data) {
				if (data != null) {//added new
				
				//add visual checkmark on label
				label = JSON.parse(data.responseText);
					checkmarkModalLabelON(label.Id);
				//add label on card visually
				document.getElementById('card-label-list' + openedCardId).innerHTML +=
						"<span class='badge badge-pill' id='label" + label.Id + "' style='background:" + label.Color + "!important'>" + label.Name + "</span>";




				} else {//removed
					//remove visual checkmark on label
					//remove label on card visually

					document.getElementById('card-label-list' + openedCardId).querySelector('#label' + id).remove();
					checkmarkModalLabelOFF(id);
				}

			});
	
});

function checkmarkModalLabelON(labelId) {
	//get a modal label
	//add to inner html
	var modalLabel = document.getElementById('modal-label' + labelId);
	modalLabel.innerHTML += "<div id='labelcheckmark" + labelId + "' class='float-right'><i class='fas fa-check'></i></div>";
}
function checkmarkModalLabelOFF(labelId) {
	//get a modal label
	//add to inner html
	var labelcheckmark = document.getElementById('labelcheckmark' + labelId);
	if (labelcheckmark != null) {
	var parent = labelcheckmark.parentNode;
		parent.removeChild(labelcheckmark);
	}
}

