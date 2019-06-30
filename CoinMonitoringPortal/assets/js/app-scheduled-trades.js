$(document).ready(function () {
	$('.deleteButton').on("click", deleteTrade);
	$('.resetButton').on("click", resetTrade);
});

function deleteTrade(e) {
	var $target = $(e.target);

	var request = {
		TradeNr: $target.data('trade-nr')
	}

	$.ajax({
		url: "/CoinMonitoringPortal/AutoAction/DeleteScheduledTrade",
		method: "POST",
		data: request,
		success: function () {
			window.location = '/CoinMonitoringPortal/ScheduledTrades';
		}
	});
}

function resetTrade(e) {
	var $target = $(e.target);

	var request = {
		TradeNr: $target.data('trade-nr')
	}

	$.ajax({
		url: "/CoinMonitoringPortal/AutoAction/ResetScheduledTrade",
		method: "POST",
		data: request,
		success: function () {
			window.location = '/CoinMonitoringPortal/ScheduledTrades';
		}
	});
}