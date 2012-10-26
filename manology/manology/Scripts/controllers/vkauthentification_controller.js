var AuthController = function (redirectUri) {
	var self = this;

	var _hashParams = location.hash.slice(1).split('&');
	var _accesssToken = _hashParams[0].split('=')[1];
	console.log(_accesssToken);

	var _viewerId = _hashParams[_hashParams.length - 1].split('=')[1];
	console.log(_viewerId);

	var _tokenStorageId = "manology.vkAccessToken";
	var _viewerStorageId = "manology.viewerId";

	var _localStorageAvailable = typeof localStorage != undefined && localStorage != undefined;

	this.setUser = function () {
		if (_localStorageAvailable) {
			localStorage.setItem(_tokenStorageId, _accesssToken);
			localStorage.setItem(_viewerStorageId, _viewerId);
		}

		location.replace(redirectUri);
	}

	this.getUser = function () {
		if (_localStorageAvailable) {
			return {
				token: localStorage.getItem(_tokenStorageId),
				id: localStorage.getItem(_viewerStorageId)
			};
		}
	}

	this.signOff = function () {
		if (this.isAuthenticated()) {
			localStorage.removeItem(_tokenStorageId);
			localStorage.removeItem(_viewerStorageId);
			// TODO! Refactor this shit!
			localStorage.removeItem("ownerId");
		}

		location.replace(redirectUri);
	}

	this.isAuthenticated = function () {
		return self.getUser() && self.getUser().id && self.getUser().id > 0;
	}
}
