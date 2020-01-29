function passDocUrlToDelete(url) {
    $(".confirmDocDelBtn").on('click', function () {
        let con = confirm('Are you sure you want to delete this?');

        if (!con) {
            event.preventDefault();
        }
        else {
            const docName = $(this).closest('tr').find("td:eq(2)").text().trim();
            $.ajax({
                type: "GET",
                url: url,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: {docName: docName },
                success: function (data) {
                    if (data.data == "false") {
                        alert("Something wrong!");
                        return false;
                    }
                    $("#tbl-distinct-documents tr:contains('" + data.data + "')").remove();
                },
                async: false
            });
        }
    });
}