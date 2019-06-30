$(document).ready(function () {
	$("#add-key").on("click", showAddKey);
	$('#save-key').on("click", createKey);
	$('.deleteKeys').on("click", deleteKey);
	$('#exchangeKey').on('change', showCexWarning);
});

function showAddKey() {
	$('#add-key-form').modal();
}

function createKey() {

	var request = {
		ExchangeType: $('#exchangeKey').val(),
		KeyValue: $('#keyValue').val(),
		SecretValue: $('#secretValue').val()
	};

	$.ajax({
		url: "/CoinMonitoringPortal/Account/CreateAuthKey",
		method: "POST",
		data: request,
		success: function() {
			$('#add-key-form').modal('hide');
			location.reload();
		}
	});

}

function showCexWarning() {
	if ($('#exchangeKey').val() == 1) {

		$('#cex-info').show();
	} else {
		$('#cex-info').hide();
	}
}

function deleteKey(e) {
	var request = {
		KeyNr: $(e.target).data('key-nr')
	};

	$.ajax({
		url: "/CoinMonitoringPortal/Account/DeleteKey",
		method: "POST",
		data: request,
		success: function () {
			location.reload();
		}
	});
}