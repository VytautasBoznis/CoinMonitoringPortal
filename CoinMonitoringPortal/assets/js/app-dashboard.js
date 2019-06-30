var chart = null;

$(document).ready(function () {
	$('#coin').on('change', redraw);
	$('#exchangeKey').on('change', redraw);
	$('#EmaChecked').on('change', redraw);
	$('#RsiChecked').on('change', redraw);
	$('#FiChecked').on('change', redraw);

	redraw();
});

function redraw() {

	if ($('.portfolioData').count == 0) {
		return;
	}

	var selectedCoinText = $('#coin')[0][$('#coin')[0].selectedIndex].text;
	var split = selectedCoinText.split('/');


	if ($('#exchangeKey').val() == 2) {
		var temp = split[1];
		split[1] = split[0];
		split[0] = temp;
	}

	var request = {
		ExchangeType: $('#exchangeKey').val(),
		Symbol1: split[0],
		Symbol2: split[1],
		From: '2019-05-01',
		ShowRSI: $('#RsiChecked').is(':checked'),
		ShowEMA: $('#EmaChecked').is(':checked'),
		ShowFI: $('#FiChecked').is(':checked')
	}

	$.ajax({
		url: "/CoinMonitoringPortal/AutoAction/GetChartData",
		method: "POST",
		data: request,
		success: function (data) {
			if (data) {
				tryPaintChart(data);
			}
		}
	});
}

function tryPaintChart(response) {
	var ctx = document.getElementById('chart').getContext('2d');

	var datasetFixed = response.ChartPointsMain.map(function (point) {
		return point.Last;
	});

	var datasetLabels = response.ChartPointsMain.map(function (point) {
		return point.TimeFormatted;
	});

	var fullDataSet = [];

	var mainDataset = {
		label: response.Name,
		borderColor: 'rgb(45, 189, 168)',
		data: datasetFixed
	}
	fullDataSet.push(mainDataset);

	if ($('#RsiChecked').is(':checked')) {
		if (response.RSI) {
			var datasetRSI = response.RSI.Points.map(function (point) {
				return point.Value;
			});

			var RsiDataset = {
				label: response.RSI.Name,
				borderColor: 'rgb(44, 151, 222)',
				data: datasetRSI
			}

			fullDataSet.push(RsiDataset);
		}
	}

	if ($('#EmaChecked').is(':checked')) {
		if (response.EMA) {
			var datasetEMA = response.EMA.Points.map(function (point) {
				return point.Value;
			});

			var EmaDataset = {
				label: response.EMA.Name,
				borderColor: 'rgb(134 , 179 , 77 )',
				data: datasetEMA
			}

			fullDataSet.push(EmaDataset);
		}
	}

	if ($('#FiChecked').is(':checked')) {
		if (response.ForceIndex) {
			var datasetForceIndex = response.ForceIndex.Points.map(function (point) {
				return point.Value;
			});

			var ForceIndexDataset = {
				label: response.ForceIndex.Name,
				borderColor: 'rgb(203 ,62 ,75 )',
				data: datasetForceIndex
			}

			fullDataSet.push(ForceIndexDataset);
		}
	}

	if (chart) {
		chart.destroy();
		chart = undefined;
	}

	chart = new Chart(ctx, {
		type: 'line',
		data: {
			labels: datasetLabels,
			datasets: fullDataSet
		},

		options: {}
	});
}