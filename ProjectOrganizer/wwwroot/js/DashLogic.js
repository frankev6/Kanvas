var selectedTeamId;
var profileInfo;


if (window.location.href.toLowerCase().includes("dashboard")) {
	document.getElementById('dashboardbtn').style = 'background-color:#335dff;';
} else if (window.location.href.toLowerCase().includes("schedule")) {
	document.getElementById('schedulebtn').style = 'background-color:#335dff';
} else if (window.location.href.toLowerCase().includes("analytics")) {
	document.getElementById('analyticsbtn').style = 'background-color:#335dff';
} else if (window.location.href.toLowerCase().includes("teams")) {
	document.getElementById('teamsbtn').style = 'background-color:#335dff';
} else if (window.location.href.toLowerCase().includes("files")) {
	document.getElementById('filesbtn').style = 'background-color:#335dff';
} else if (window.location.href.toLowerCase().includes("settings")) {
	document.getElementById('settingsbtn').style = 'background-color:#335dff';
} else if (window.location.href.toLowerCase().includes("help")) {
	document.getElementById('helpbtn').style = 'background-color:#335dff';
}



function makeNewProject() {

		var Pname = document.getElementById('projectNameEntry').value;
		var Pdesc = document.getElementById('projectDescriptionEntry').value;

		if (Pname == '') {
		document.getElementById('projectErrorInfo').innerHTML = 'Name of project is required.';
			return;
		}

	if (typeof selectedTeamId === 'undefined') {

		$.post("Dashboard/NewProject/",
			{
				name: Pname,
				description: Pdesc
			},
			function (data) {
				location.href = "board?id=" + data.responseText;
			});

	} else {
		$.post("Teams/NewProject/",
			{
				teamId: selectedTeamId,
				name: Pname,
				description: Pdesc
			},
			function (data) {
				location.href = "board?id=" + data.responseText;
			});
	}	
}
function setSelectedTeam(teamid) {
	selectedTeamId = teamid;
}