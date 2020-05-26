function uploadModals(token, json) {
    const SELECTORS = {
        LOAD_DOC_BUTTON: '#btn-upload-document',
        LOAD_AGR_BUTTON: '#btn-upload-agreement',
        PLACEHOLDER_MODAL_DOC: '#modal-placeholder-document',
        PLACEHOLDER_MODAL_AGR: '#modal-placeholder-agreement',
    };

    // Document Upload
    const placeholderDocument = $(SELECTORS.PLACEHOLDER_MODAL_DOC);
    const urlDoc = '/loadDocUpload';
    $(document).on('click', SELECTORS.LOAD_DOC_BUTTON, function (event) {
        getModalRequest(placeholderDocument, urlDoc);
    });

    placeholderDocument.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();

        const form = $(this).parents('.modal').find('form');
        const token = $('input[name=__RequestVerificationToken]', form).val();
        const actionUrl = form.attr('action');
        const dataToSend = new FormData(form.get(0));

        postModalRequest(placeholderDocument, actionUrl, dataToSend, token);
    });

    // Agreement Upload
    const placeholderAgreement = $(SELECTORS.PLACEHOLDER_MODAL_AGR);
    const urlAgr = '/loadAgrUpload';

    $(document).on('click', SELECTORS.LOAD_AGR_BUTTON, function (event) {
        getModalRequest(placeholderAgreement, urlAgr);
    });

    placeholderAgreement.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();

        const form = $(this).parents('.modal').find('form');
        const token = $('input[name=__RequestVerificationToken]', form).val();
        const actionUrl = form.attr('action');
        const dataToSend = new FormData(form.get(0));

        postModalRequest(placeholderAgreement, actionUrl, dataToSend, token);
    });

    function postModalRequest(placeholderElement, actionUrl, dataToSend, token) {
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
    }

    function getModalRequest(placeholderElement, url) {
        $.get({
            url: url,
            data: json,
            contentType: 'application/json; charset=utf-8',
            headers: { 'X-CSRF-TOKEN': token },
        }).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
    }
};

// Set agreement upload dates
(function () {
    let contractDate = document.getElementById('contractDate');
    let activationDate = document.getElementById('activationDate');
    let expirationDate = document.getElementById('expirationDate');

    if (contractDate) {
        contractDate.addEventListener('change', setActivationDate);
    }

    function setActivationDate() {
        //activationDate.setAttribute('min', contractDate.value);
        expirationDate.setAttribute('min', contractDate.value);
        activationDate.value = contractDate.value;
    }
})();