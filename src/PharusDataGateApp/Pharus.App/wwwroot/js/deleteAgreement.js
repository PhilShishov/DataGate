function passUrlToDelete(url) {
    $(".confirmDelBtn").on('click', function () {
        let con = confirm('Are you sure you want to delete this?');

        if (!con) {
            event.preventDefault();
        }
        else {
            const id = $(this).closest('tr').find("td:eq(0)").text().trim();
            const agrName = $(this).closest('tr').find("td:eq(2)").text().trim();
            $.ajax({
                type: "GET",
                url: url,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: { id: id, agrName: agrName },
                success: function (data) {
                    if (data.data == "false") {
                        alert("Something wrong!");
                        return false;
                    }
                    $("#tbl-distinct-agreements tr:contains('" + data.data + "')").remove();
                },
                async: false
            });
        }
    });
}