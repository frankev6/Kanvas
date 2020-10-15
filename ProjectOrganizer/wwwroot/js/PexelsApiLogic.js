
var nextpage;

async function PexelSearch() {

	const query = document.getElementById("bgImageInput").value;
	if (query == '') {
		return;
	}

	var pexelsBaseUrl = "https://api.pexels.com/v1/search?query="+query+"&per_page=28";

	const response = await fetch(pexelsBaseUrl, {
		method: 'GET',
		headers: {
			Accept: 'application/json',
			Authorization: '563492ad6f9170000100000169d40f231fae42afaf37701fe9f4270a'
		}

	});

	var data = await response.json();
	nextpage = data.next_page;
	var photos = data.photos;
		var e_list = document.getElementById('thumbnailPhotoList');
	e_list.innerHTML = '';


	var loadbtn = document.getElementById('LoadMoreBg');
	if (loadbtn != null) {

	e_list.parentElement.removeChild(loadbtn);
	}

	photos.forEach(function (entry) {

		
		e_list.innerHTML += "<div onclick=setBackgroundImage('"+entry.src.large2x+"') class='thumbnail-photo' style=' background:url(" + entry.src.medium + ");'><a class='text-white' style='padding:10px;bottom:5px' href='" + entry.photographer_url + "'>Photo by " + entry.photographer + "</a></div>";


	});

	e_list.parentElement.innerHTML += "<div class='btn btn-primary' style='position:relative;left:47%; margin-top:10px' id='LoadMoreBg' onclick=PexelNextPage()>Load More</div>";
}

async function PexelNextPage() {

	const response = await fetch(nextpage, {
		method: 'GET',
		headers: {
			Accept: 'application/json',
			Authorization: '563492ad6f9170000100000169d40f231fae42afaf37701fe9f4270a'
		}

	});

	var data = await response.json();
	var photos = data.photos;
	nextpage = data.next_page;
	var e_list = document.getElementById('thumbnailPhotoList');

		var loadbtn = document.getElementById('LoadMoreBg');
		e_list.parentElement.removeChild(loadbtn);

	photos.forEach(function (entry) {


		e_list.innerHTML += "<div onclick=setBackgroundImage('" + entry.src.large2x + "') class='thumbnail-photo' style=' background:url(" + entry.src.medium + ");'><a class='text-white' style='padding:10px;bottom:5px' href='" + entry.photographer_url + "'>Photo by " + entry.photographer + "</a></div>";

	});

	e_list.parentElement.innerHTML += "<div class='btn btn-primary' style='position:relative;left:47%; margin-top:10px' id='LoadMoreBg' onclick=PexelNextPage()>Load More</div>";



}


