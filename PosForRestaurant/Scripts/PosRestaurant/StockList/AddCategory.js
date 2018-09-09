$(document).ready(function () {

	$(".dlt").click(function () {
		var id = $(this).attr('id');
		categoryDelete(id);
	});

	function categoryDelete(id) {
		var jsonData = { Id: id };
		var r = confirm("Are you sure to delete?");
		if (r === true) {
			$.ajax({
				url: "/StockList/DeleteCategory",
				data: jsonData,
				type: "Post",
				success: function (data, status) {
					if (data === true && status === "success") {
						removeRowOfDeletedCategory(id);
						alert("Successfully Deleted!");
					}
					else {
						alert("Sorry Couldn't Delete!");
					}
					
				}
			});
		}
		
	}

	function removeRowOfDeletedCategory(id) {
		id = "#" + id;
		$(id).closest('tr').remove();
		updateTableSerialNumber();
	}

	function updateTableSerialNumber() {
		$("td:nth-child(2)").each(function (index) {
			$(this).text(index + 1);
		});
	}

});