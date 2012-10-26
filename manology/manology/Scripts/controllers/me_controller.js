var MeController = function () {
	var _auth = new AuthController();

	this.index = function () {
		if (_auth.isAuthenticated()) {
			this.lookupHash();
		}
		else {
			localStorage.setItem("ownerId", location.hash.slice(1));
			location.replace('/');
		}
	}

	this.lookupHash = function () {
		if (location.hash) {
			var ownerId = location.hash.slice(1);
			if (!ownerId) {
				location.replace('/');
			}
		}
		else {
			var ownerId = _auth.getUser().id;
			location.hash = ownerId;
		}
	}
}