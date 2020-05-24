function uploadModals(token, json) {
    const btnDocTextContent = document.getElementById('btn-upload-document').textContent.trim();
    let btnTextContent;

    if (btnDocTextContent) {
        btnTextContent = btnDocTextContent;
    } else {
        btnTextContent = btnAgrTextContent;
    }

    let placeholderElement;
    let url;
    if (btnTextContent === 'Upload Agreement') {
        placeholderElement = $('#modal-placeholder-agreement');
        url = '/loadAgrUpload';
    } else {
        placeholderElement = $('#modal-placeholder-document');
        url = '/loadDocUpload';
    }

    $(document).on('click', 'button[data-toggle="ajax-modal"]', function (event) {
        $.get({
            url: url,
            data: json,
            contentType: 'application/json; charset=utf-8',
            headers: { 'X-CSRF-TOKEN': token },
        }).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
    });

    placeholderElement.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();

        const form = $(this).parents('.modal').find('form');
        const token = $('input[name=__RequestVerificationToken]', form).val();
        debugger;
        const actionUrl = form.attr('action');
        const dataToSend = new FormData(form.get(0));

        $.ajax({
            url: actionUrl,
            method: 'POST',
            data: dataToSend,
            headers: { 'X-CSRF-TOKEN': token },
            processData: false,
            contentType: false
        }).done(function (data) {
            const newBody = $('.modal-body', data);
            placeholderElement.find('.modal-body').replaceWith(newBody);
        }).fail(function (request, status, error) {
            alert(request.responseText);
        });
    });
};