var MongoDB = function () {

	var _auth = new AuthController();
	var _mongoDBController = {
		saveViewModel: '/MongoDB/SaveViewModel',
		loadViewModel: '/MongoDB/loadViewModel'
	}

	this.saveViewModel = function (viewModel) {
		var data = {
			accessToken: _auth.getUser().accessToken,
			userId: _auth.getUser().ownerId,
			viewModel: viewModel
		};
		$.ajax({
			url: _mongoDBController.saveViewModel,
			type: 'POST',
			data: data,
			error: function (data) {
			},
			success: function () {
			}
		})
	}

	this.loadViewModel = function () {
		var data = {
			userId: _auth.getUser().ownerId
		};
		$.ajax({
			url: _mongoDBController.loadViewModel,
			data: data,
			success: function (data) {
				try {
					if (data) {

					}
					else {
					}
				}
				catch (e) {
				}
			}
		})
	}
}