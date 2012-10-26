var hash = location.hash.slice(1).split('&');
var accesssToken = hash[0];
console.log(accesssToken);

var viewerId = hash[hash.length - 1];
console.log(viewerId);

var _tokenStorageId = "manology.vkAccessToken";
var _viewerStorageId = "manology.viewerId";

(function () {
	if (localStorage) {
		localStorage.setItem(_tokenStorageId, accesssToken);
		localStorage.setItem(_viewerStorageId, viewerId);
	}
})();

function getUser() {
	if (localStorage) {
		return {
			token: localStorage.getItem(_tokenStorageId),
			id: localStorage.getItem(_viewerStorageId)
		};
	}
}

location.replace('/home/me');