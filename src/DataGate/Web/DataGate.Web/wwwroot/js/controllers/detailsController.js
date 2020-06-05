const HTML_ADDITIONAL_INFO = {
    SELECT: '#select-additional-info',
    CONTAINER_SUBENTITIES: '#subEntities',
    CONTAINER_TIMELINES: '#timelineChanges',
    CONTAINER_DOCUMENTS: '#allDocuments',
    CONTAINER_AGREEMENTS: '#allAgreements',
};

const DROPDOWN_VALUES = {
    SUBFUNDS: 'SubFunds',
    SHARECLASSES: 'ShareClasses',
    TIMELINES: 'TimelineChanges',
    DOCUMENTS: 'AllDocuments',
    AGREEMENTS: 'AllAgreements',
};

const URLS = {
    TIMELINES: '/loadTimelines',
    DOCUMENTS: '/loadAllDoc',
    AGREEMENTS: '/loadAllAgr',
};

function loadAddInfo(token, urlSubEnt, json) {
    // ________________________________________________________
    //
    // Select menu for fund additional information -
    // subentities, timeline changes, all documents -
    // On change event for selected value

    $(HTML_ADDITIONAL_INFO.SELECT).on('change', function () {
        const dropdownvalue = $(`${HTML_ADDITIONAL_INFO.SELECT} option:selected`).val();

        $(this).find('[selected]').removeAttr('selected')
        $(this).find(':selected').attr('selected', 'selected')
        if (dropdownvalue == DROPDOWN_VALUES.SUBFUNDS || dropdownvalue == DROPDOWN_VALUES.SHARECLASSES) {
            closeOptions();
            $(HTML_ADDITIONAL_INFO.CONTAINER_SUBENTITIES).removeClass('d-none');

            getSelectMenuRequestHandler(urlSubEnt, HTML_ADDITIONAL_INFO.CONTAINER_SUBENTITIES);
        } else if (dropdownvalue == DROPDOWN_VALUES.TIMELINES) {
            closeOptions();
            $(HTML_ADDITIONAL_INFO.CONTAINER_TIMELINES).removeClass('d-none');

            getSelectMenuRequestHandler(URLS.TIMELINES, HTML_ADDITIONAL_INFO.CONTAINER_TIMELINES);
        } else if (dropdownvalue == DROPDOWN_VALUES.DOCUMENTS) {
            closeOptions();
            $(HTML_ADDITIONAL_INFO.CONTAINER_DOCUMENTS).removeClass('d-none');

            getSelectMenuRequestHandler(URLS.DOCUMENTS, HTML_ADDITIONAL_INFO.CONTAINER_DOCUMENTS);
        } else if (dropdownvalue == DROPDOWN_VALUES.AGREEMENTS) {
            closeOptions();
            $(HTML_ADDITIONAL_INFO.CONTAINER_AGREEMENTS).removeClass('d-none');

            getSelectMenuRequestHandler(URLS.AGREEMENTS, HTML_ADDITIONAL_INFO.CONTAINER_AGREEMENTS);
        } else {
            closeOptions();
        }
    });

    function getSelectMenuRequestHandler(url, placeholder) {
        $.ajax({
            url: url,
            type: 'GET',
            data: json,
            contentType: 'application/json; charset=utf-8',
            headers: { 'X-CSRF-TOKEN': token },
            success: function (response) {
                $(placeholder).html(response);
            }
        });
    }

    function closeOptions() {
        $(HTML_ADDITIONAL_INFO.CONTAINER_SUBENTITIES).addClass('d-none');
        $(HTML_ADDITIONAL_INFO.CONTAINER_TIMELINES).addClass('d-none');
        $(HTML_ADDITIONAL_INFO.CONTAINER_DOCUMENTS).addClass('d-none');
        $(HTML_ADDITIONAL_INFO.CONTAINER_AGREEMENTS).addClass('d-none');
    }
}

const HTML_UPLOAD = {
    BTN_LOAD_MODAL_DOC: '#btn-upload-document',
    BTN_LOAD_MODAL_AGR: '#btn-upload-agreement',
    PLACEHOLDER_MODAL_DOC: '#modal-placeholder-document',
    PLACEHOLDER_MODAL_AGR: '#modal-placeholder-agreement',
    URL_LOAD_DOC: '/loadDocUpload',
    URL_LOAD_AGR: '/loadAgrUpload'
};

function uploadModals(token, json) {
    // Document Upload
    const placeholderDocument = $(HTML_UPLOAD.PLACEHOLDER_MODAL_DOC);
    const urlDoc = HTML_UPLOAD.URL_LOAD_DOC;
    $(document).on('click', HTML_UPLOAD.BTN_LOAD_MODAL_DOC, function (event) {
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
    const placeholderAgreement = $(HTML_UPLOAD.PLACEHOLDER_MODAL_AGR);
    const urlAgr = HTML_UPLOAD.URL_LOAD_AGR;

    $(document).on('click', HTML_UPLOAD.BTN_LOAD_MODAL_AGR, function (event) {
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

    function postModalRequest(placeholderElement, actionUrl, dataToSend, token) {
        $.ajax({
            url: actionUrl,
            method: 'POST',
            data: dataToSend,
            headers: { 'X-CSRF-TOKEN': token },
            processData: false,
            contentType: false
        }).done(function (data) {
            if (data.success) {
                const { areaName, date, id, routeName } = data.dto;
                const url = '/Upload/OnUploadSuccess?areaName=' + areaName + '&date=' + date + '&id=' + id + '&routeName=' + routeName;
                window.location = url;
                return;
            }
            const newBody = $('.modal-body', data);
            placeholderElement.find('.modal-body').replaceWith(newBody);

        }).fail(function (request, status, error) {
            alert(request.responseText);
        });
    }
};

$(function () {
    $(".select-pharus").chosen({
        disable_search_threshold: 10,
        width: "260px",
    })
})