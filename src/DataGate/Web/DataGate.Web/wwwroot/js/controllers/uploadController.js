function uploadModals(token, json) {
    const placeholderDocument = $('#modal-placeholder-document');
    //const placeholderElement = $('#modal-placeholder-document');

    $(document).on('click', 'button[data-toggle="ajax-modal"]', function (event) {
        const url = '/loadDocUpload';
        $.get({
            url: url,
            data: json,
            contentType: 'application/json; charset=utf-8',
            headers: { 'X-CSRF-TOKEN': token },
        }).done(function (data) {
            placeholderDocument.html(data);
            placeholderDocument.find('.modal').modal('show');
        });
    });

    //$('#btn-upload-agreement').click(function () {
    //    $.ajax({
    //        url: '/loadAgrUpload',
    //        type: 'GET',
    //        data: json,
    //        contentType: 'application/json; charset=utf-8',
    //        headers: { 'X-CSRF-TOKEN': token },
    //        success: function (response) {
    //            modalPlaceholderAgr.html(response);
    //        }
    //    })
    //});
}