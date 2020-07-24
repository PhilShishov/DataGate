function deleteFile(tokenDoc, areaName, table, table_dist, messagesArr) {
    $('.btn-delete').on('click', function () {
        const docValue = $(this).closest('tr').find('button').eq(0).val();
        const fileId = $(this).closest('tr').attr('class');

        var jqXhr = $.ajax({
            type: 'GET',
            url: '/media/delete',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            headers: { 'X-CSRF-TOKEN': tokenDoc },
            data: { fileId: fileId, docValue: docValue, areaName: areaName }
        });

        swal({
            title: messagesArr.TITLE,
            text: messagesArr.TEXT,
            icon: "warning",
            buttons: [messagesArr.BTN_CANCEL, "OK"],
            dangerMode: true
        }).then((isConfirm) => {
            if (!isConfirm) return;
            jqXhr
                .done(function (data) {
                    if (data.fileId == 'false') {
                        swal({
                            title: messagesArr.TITLE_FAIL,
                            text: messagesArr.TEXT_FAIL,
                            icon: "error",
                        });
                        return false;
                    }
                    $(`${table} .` + data.fileId).remove();
                    $(`${table_dist} .` + data.fileId).remove();
                    swal(messagesArr.TITLE_SUCCESS, {
                        icon: "success",
                    });
                })
                .fail(function (request, status, error) {
                    swal(request.responseText, {
                        icon: "error"
                    })
                });
        });
    });
}