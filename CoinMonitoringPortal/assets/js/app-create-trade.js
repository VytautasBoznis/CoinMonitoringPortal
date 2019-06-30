$(document).ready(function () {
	$("#add-key").on("click", showAddKey);
	$('#save-key').on("click", addCriteria);
	$('#create-trade').on("click", createTrade);
	$('.deleteButton').on("click", deleteTrade);
	$('.resetButton').on("click", resetTrade);

});

function showAddKey() {
	$('#indexName')[0].selectedIndex = 0;
	$('#value').val('');
	$('#weight').val('');
	$('#valueMustBe')[0].selectedIndex = 0;
	$('#add-criteria-form').modal();
}

function addCriteria() {
	$('#add-criteria-form').modal('hide');

	var row = '<tr class="criteria" data-eco-index="' + $('#indexName').val() + '" data-criteria-type="' + $('#valueMustBe').val() + '" data-value="' + $('#value').val() + '" data-weight="' + $('#weight').val() +'">' +
		'<td>' + $('#indexName')[0][$('#indexName')[0].selectedIndex].text +'</td>'+
		'<td>' + $('#value').val() +'</td>'+
		'<td>' + $('#valueMustBe')[0][$('#valueMustBe')[0].selectedIndex].text +'</td>'+
		'<td>' + $('#weight').val() + '</td>' +
		'<td><a href="#" class="delete-btn"><span class="btn btn-primary btn-lg active">Delete</span></a></td>' +
		'</tr>';

	$('#table-body').html($('#table-body').html() + row);
	$(".delete-btn").unbind();
	$(".delete-btn").on('click', removeRow);
}

function removeRow(e) {
	$(e.target).parent().parent().parent().remove();
}

function createTrade() {
	var selectedCoinText = $('#coinPair')[0][$('#coinPair')[0].selectedIndex].text;
	var split = selectedCoinText.split('/');

	var request = {
		Trade: {
			TradeAction: $('#tradeAction').val(),
			ExchangePair: {
				ExchangeType: $('#exchangeNr').val(),
				Symbol1: split[0],
				Symbol2: split[1]
			},
			Value: $('#tradeValue').val(),
			TradeCriteria: []
		}
	}

	var criteria = $('.criteria');
	for (var i = 0, l = criteria.length; i < l; i++) {
		var newCriteria = {
			EcoIndexType: $(criteria[i]).data('eco-index'),
			CriteriaValueType: $(criteria[i]).data('criteria-type'),
			Value: $(criteria[i]).data('value'),
			Weight: $(criteria[i]).data('weight')
		}

		request.Trade.TradeCriteria.push(newCriteria);
	}

	$.ajax({
		url: "/CoinMonitoringPortal/AutoAction/CreateScheduledTrade",
		method: "POST",
		data: request,
		success: function () {
			window.location = '/CoinMonitoringPortal/ScheduledTrades';
		}
	});
}

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

function redraw() {

	if ($('.portfolioData').count == 0) {
		return;
	}

	var selectedCoinText = $('#coin')[0][$('#coin').val()].text;
	var split = selectedCoinText.split('/');

	var request = {
		ExchangeType: $('#exchange').val(),
		Symbol1: split[0],
		Symbol2: split[1],
		From: '2019-01-01',
		ShowRSI: $('#RsiChecked').is(':checked'),
		ShowEMA: $('#EmaChecked').is(':checked'),
		ShowFI: $('#FiChecked').is(':checked')
	}

	//$.ajax({
	//	url: "/CoinMonitoringPortal/Account/DeleteKey",
	//	method: "POST",
	//	data: request,
	//	success: function (data) {
	//		if (data) {
	//			tryPaintChart(data);
	//		}
	//	}
	//});
}

function tryPaintChart(data) {
	chart.draw(data);
}