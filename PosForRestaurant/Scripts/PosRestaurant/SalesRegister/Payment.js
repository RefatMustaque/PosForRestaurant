$(document).ready(function () {
	$('#Cash').on('input', function (e) {
		var total = parseInt($('#TotalPayable').val());
		var cash = parseInt($('#Cash').val());
		var changeAmount = 0;
		if ((total - cash) > 0) {
			var due = total - cash;
			$('#Due').val(due);
			$('#ChangeAmount').val(0);
		}
		else {
			changeAmount = cash - total ;
			$('#ChangeAmount').val(changeAmount);
			$('#Due').val(0);
		}
		 
	});
});