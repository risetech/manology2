function saveViewModel(viewModel) {
	var data = {};
	data.accessToken = 
	data.userId = 1;
	data.viewModel = viewModel;
	$.ajax({
		url: '/MongoDB/SaveViewModel',
		type: 'POST',
		data: data,
		error: function (data) {
		},
		success: function () {
		}
	})
}

function loadViewModel() {
	var data = {};
	data.userId = 1;
	$.ajax({
		url: '/MongoDB/LoadViewModel',
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