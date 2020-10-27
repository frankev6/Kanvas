function createTeam() {

	var teamId;
	var team_name = document.getElementById('teamNameEntry').value;

	if (team_name == null || team_name.length == 0) {
		document.getElementById('teamtErrorInfo').innerHTML = "Name of team is required.";
		return;
	}

	$.post("Teams/CreateTeam/",
		{
			name: team_name
		},
		function () {
			window.location.reload();
		});
}
function deleteTeam(team_id) {

	$.post("Teams/DeleteTeam/",
		{
			teamId: team_id,
			deleteProjects: true
		},
		function () {
			window.location.reload();
		});
}
function AddUserToTeam() {

	$.post("Teams/AddUserToTeam/",
		{
			teamId: teamId,
			username: document.getElementById('add-username-input').value
		},
		function () {
			window.location.reload();
		});
}
function selectTeam(teamid, teamname) {
	teamId = teamid;
	document.getElementById('AddTeamMemberTitle').innerHTML = 'Add Member to ' + teamname;
}