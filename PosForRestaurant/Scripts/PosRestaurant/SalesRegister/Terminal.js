$(document).ready(function () {
	$('#suspend').click(function () {
		$('#firstTableTbody').empty();
		emptyPaymentInfo();
	});
	//Item search by category
	$('.itemCategory').click(function () {
		var categoryId = $(this).attr('id');
		searchItemByCategory(categoryId);
	});

	//showing all item
	$('#ItemListTab').click(function () {
		showAllItemOfDiv();
	});

	//getting data in table
	$('.item').click(function () {
		var itemId = $(this).children('#itemListItemId').val();
		var itemName = $(this).children('#itemListItemName').val();
		var price = $(this).children('#itemListItemPrice').val();
		var quantity = 1;
		var total = price * quantity;
		var taxApply = $(this).children('#itemListItemTax').val();
		var discount = $(this).children('#itemListItemDiscount').val()
		if (taxApply == 'True') {
			taxApply = 1;
		}
		else {
			taxApply = 0

		}
		var itemInfo = {
			ItemId: itemId,
			ItemName: itemName,
			Price: price,
			Quantity: quantity,
			Total: total,
			TaxApply: taxApply,
			Discount: discount,
		};
		//if row is not created
		if ($('#firstTableTbody').children('tr').length == 0) {	
			createRowsOfTable(itemInfo);
			createPaymentInfo(itemInfo);
		}
		//if row is created
		else {
			var ItemExist = false;
			$('#firstTableTbody').children('tr').each(function () {
				//if the item already exist, then increase the quantity
				if ($(this).children('td:nth-child(3)').children('input').val() == itemId) {
					createPaymentInfo(itemInfo);
					var index = $(this).index();
					itemInfo.Quantity = parseInt($(this).children('td:nth-child(5)').children('input').val());
					itemInfo.Quantity = itemInfo.Quantity + 1;
					itemInfo.Total = itemInfo.Quantity * itemInfo.Price;
					var inputQty = '<input type="hidden" name="SellDetailses[' + index + '].Quantity" value="' + itemInfo.Quantity + '"/> ' + itemInfo.Quantity ;
					$(this).children('td:nth-child(5)').html(inputQty);
					var inputTotal = '<input type="hidden" name="SellDetailses[' + index + '].ItemTotal" value="' + itemInfo.Total + '"/> ' + itemInfo.Total;
					$(this).children('td:nth-child(6)').html(inputTotal);
					ItemExist = true;
				}
				
			});

			//if does not exist create row
			if (ItemExist == false) {
				createRowsOfTable(itemInfo);
				createPaymentInfo(itemInfo);
			}
		}
	});

	

	function searchItemByCategory(categoryId) {
		className = 'categoryId-' + categoryId;
		$('.item').each(function () {
			if ($(this).hasClass(className)) {
				$(this).show();
			}
			else {
				$(this).hide();
			}
		});
	}

	function showAllItemOfDiv() {
		$('.item').each(function () {
			$(this).show();
		});
	}
	var index = 0;
	function createRowsOfTable(itemInfo) {
		//index = $('#firstTableTbody').children('tr').length + 1;
		var trDel = '<td><input type="hidden" name ="SellDetailses.Index" value="'+index+'"/>' + 'Del' + '</td>';
		var trMinus = '<td>' + '-' + '</td>';
		var trItemName = '<td><input type="hidden" name="SellDetailses[' + index + '].ItemId" value="' + itemInfo.ItemId + '"/> ' + itemInfo.ItemName + '</td>';
		var trPrice = '<td>' + itemInfo.Price + '</td>';
		var trQuantity = '<td><input type="hidden" name="SellDetailses[' + index + '].Quantity" value="' + itemInfo.Quantity + '"/>' + itemInfo.Quantity + '</td>';
		var trTotal = '<td><input type="hidden" name="SellDetailses[' + index + '].ItemTotal" value="' + itemInfo.Total + '"/>' + itemInfo.Total + '</td>';
		var trTaxApply = '<td>' + itemInfo.TaxApply + '</td>';
		var trOption = '<td></td>';
		var row = '<tr id="SellDetails'+index+'">' + trDel + trMinus + trItemName + trPrice + trQuantity + trTotal + trTaxApply + trOption + '</tr>';
		$('#firstTableTbody').append(row);
	}
	var total = 0;
	var discount = 0;
	var thisDiscount = 0;
	var subTotal = 0;
	var tax = 0;
	var totalPayable = 0;
	var totalItemType = 0;
	var thisSubTotalItem = 0;
	function createPaymentInfo(itemInfo) {
		total = total + parseInt(itemInfo.Total);
		thisDiscount = parseInt(itemInfo.Total) * (parseInt(itemInfo.Discount) / 100);
		discount = discount + thisDiscount;
		subTotal = total - discount;
		thisSubTotalItem = parseInt(itemInfo.Total) - thisDiscount;
		if (itemInfo.TaxApply == 1) {
			tax = tax + thisSubTotalItem * .145;
		}
		else {
			tax = tax;
		}
		totalPayable = subTotal + tax;
		totalItemType = $('#firstTableTbody').children('tr').length;
		$('#paymentInfoTotal').children('td:nth-child(2)').html('<input type="hidden" Id="Total" name="Total" value="' + total.toFixed(2) + '" />' + total.toFixed(2) + '');
		$('#paymentInfoDiscount').children('td:nth-child(2)').html('<input type="hidden" Id="OverallDiscount" name="OverallDiscount" value="' + discount.toFixed(2) + '" />' + discount.toFixed(2) + '');
		$('#paymentInfoSubTotal').children('td:nth-child(2)').html('<input type="hidden" Id="SubTotal" name="SubTotal" value="' + subTotal.toFixed(2) + '" />' + subTotal.toFixed(2) + '');
		$('#paymentInfoTax').children('td:nth-child(2)').html('<input type="hidden" Id="Tax" name="Tax" value="' + tax.toFixed(2) + '" />' + tax.toFixed(2) + '');
		$('#paymentInfoTotalPayable').children('td:nth-child(2)').html('<input type="hidden" Id="TotalPayable" name="TotalPayable" value="' + totalPayable.toFixed(2) + '" />' + totalPayable.toFixed(2) + '');
		$('#paymentInfoTotalItemTypes').children('td:nth-child(2)').html('<input type="hidden" Id="TotalItemType" name="TotalItemType" value="' + totalItemType + '" />' + totalItemType + '');
	}

	function emptyPaymentInfo() {
		total = 0;
		discount = 0;
		thisDiscount = 0;
		subTotal = 0;
		tax = 0;
		totalPayable = 0;
		totalItemType = 0;
		thisSubTotalItem = 0;
		$('#paymentInfoTotal').children('td:nth-child(2)').empty();
		$('#paymentInfoDiscount').children('td:nth-child(2)').html('<input type="hidden" Id="OverallDiscount" name="OverallDiscount" value="' + discount + '" />' + discount + '');
		$('#paymentInfoSubTotal').children('td:nth-child(2)').html('<input type="hidden" Id="SubTotal" name="SubTotal" value="' + subTotal + '" />' + subTotal + '');
		$('#paymentInfoTax').children('td:nth-child(2)').html('<input type="hidden" Id="Tax" name="Tax" value="' + tax + '" />' + tax + '');
		$('#paymentInfoTotalPayable').children('td:nth-child(2)').html('<input type="hidden" Id="TotalPayable" name="TotalPayable" value="' + totalPayable + '" />' + totalPayable + '');
		$('#paymentInfoTotalItemTypes').children('td:nth-child(2)').html('<input type="hidden" Id="TotalItemType" name="TotalItemType" value="' + totalItemType + '" />' + totalItemType + '');
	}
});