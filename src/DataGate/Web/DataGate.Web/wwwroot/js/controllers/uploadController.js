function uploadModals(token, json) {
    const SELECTORS = {
        LOAD_DOC_BUTTON: '#btn-upload-document',
        LOAD_AGR_BUTTON: '#btn-upload-agreement',
        PLACEHOLDER_MODAL_DOC: '#modal-placeholder-document',
        PLACEHOLDER_MODAL_AGR: '#modal-placeholder-agreement',
    };

    // Document Upload
    const placeholderDocument = $(SELECTORS.PLACEHOLDER_MODAL_DOC);
    $(document).on('click', SELECTORS.LOAD_DOC_BUTTON, function (event) {
        $.get({
            url: '/loadDocUpload',
            data: json,
            contentType: 'application/json; charset=utf-8',
            headers: { 'X-CSRF-TOKEN': token },
        }).done(function (data) {
            placeholderDocument.html(data);
            placeholderDocument.find('.modal').modal('show');
        });
    });

    placeholderDocument.on('click', '[data-save="modal"]', function (event) {
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
            placeholderDocument.find('.modal-body').replaceWith(newBody);
        }).fail(function (request, status, error) {
            alert(request.responseText);
        });
    });

    // Agreement Upload
    const placeholderAgreement = $(SELECTORS.PLACEHOLDER_MODAL_AGR);

    $(document).on('click', SELECTORS.LOAD_AGR_BUTTON, function (event) {
        $.get({
            url: '/loadAgrUpload',
            data: json,
            contentType: 'application/json; charset=utf-8',
            headers: { 'X-CSRF-TOKEN': token },
        }).done(function (data) {
            placeholderAgreement.html(data);
            placeholderAgreement.find('.modal').modal('show');
        });
    });

    placeholderAgreement.on('click', '[data-save="modal"]', function (event) {
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
            placeholderAgreement.find('.modal-body').replaceWith(newBody);
        }).fail(function (request, status, error) {
            alert(request.responseText);
        });
    });
};