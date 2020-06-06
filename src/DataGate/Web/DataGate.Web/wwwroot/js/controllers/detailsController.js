const HTML_MENU = {
    BTN_SUBENTITIES: '#btn-open-subentities',
    BTN_DISTINCT: '#btn-open-distinct',
    BTN_CHART: '#btn-open-chart',
    BTN_TIMELINE: '#btn-open-timeline',
    BTN_DOCUMENTS: '#btn-open-documents',
    BTN_AGREEMENTS: '#btn-open-agreements',
    CONTAINER_SUBENTITIES: '#subEntities',
    CONTAINER_DISTINCT: '#distinctDocuments',
    CONTAINER_CHART: '#aumChart',
    CONTAINER_TIMELINES: '#timelineChanges',
    CONTAINER_DOCUMENTS: '#allDocuments',
    CONTAINER_AGREEMENTS: '#allAgreements',
};

const URLS = {
    TIMELINES: '/loadTimelines',
    TIMESERIES: '/loadTimeseries',
    DISTINCT: '/loadDistinct',
    DOCUMENTS: '/loadAllDoc',
    AGREEMENTS: '/loadAllAgr',
};

// ________________________________________________________
//
// Menu for fund additional information -
// subentities, timeline changes, distinct documents,
// all documents, aum chart

function loadAddInfo(token, urlSubEnt, json) {
    $(HTML_MENU.BTN_SUBENTITIES).on('click', function (event) {
        beforeCallStyleHandler();

        $.ajax({
            url: urlSubEnt,
            type: 'GET',
            data: json,
            contentType: 'application/json; charset=utf-8',
            headers: { 'X-CSRF-TOKEN': token },
            success: function (response) {
                $(HTML_MENU.CONTAINER_SUBENTITIES).html(response);

                $('html, body').animate({
                    scrollTop: $(HTML_MENU.CONTAINER_SUBENTITIES).position().top - 80
                }, 'slow');               
            }
        });

        afterCallStyleHandler(HTML_MENU.CONTAINER_SUBENTITIES, HTML_MENU.BTN_SUBENTITIES);
    });

    $(HTML_MENU.BTN_DISTINCT).on('click', function () {
        beforeCallStyleHandler();
        getSelectMenuRequestHandler(URLS.DISTINCT, HTML_MENU.CONTAINER_DISTINCT);
        afterCallStyleHandler(HTML_MENU.CONTAINER_DISTINCT, HTML_MENU.BTN_DISTINCT);
    });

    $(HTML_MENU.BTN_CHART).on('click', function () {
        beforeCallStyleHandler();
        getSelectMenuRequestHandler(URLS.TIMESERIES, HTML_MENU.CONTAINER_CHART);
        afterCallStyleHandler(HTML_MENU.CONTAINER_CHART, HTML_MENU.BTN_CHART);
    });

    $(HTML_MENU.BTN_TIMELINE).on('click', function () {
        beforeCallStyleHandler();
        getSelectMenuRequestHandler(URLS.TIMELINES, HTML_MENU.CONTAINER_TIMELINES);
        afterCallStyleHandler(HTML_MENU.CONTAINER_TIMELINES, HTML_MENU.BTN_TIMELINE)
    });

    $(HTML_MENU.BTN_DOCUMENTS).on('click', function () {
        beforeCallStyleHandler();
        getSelectMenuRequestHandler(URLS.DOCUMENTS, HTML_MENU.CONTAINER_DOCUMENTS);
        afterCallStyleHandler(HTML_MENU.CONTAINER_DOCUMENTS, HTML_MENU.BTN_DOCUMENTS);
    });

    $(HTML_MENU.BTN_AGREEMENTS).on('click', function () {
        beforeCallStyleHandler();
        getSelectMenuRequestHandler(URLS.AGREEMENTS, HTML_MENU.CONTAINER_AGREEMENTS);
        afterCallStyleHandler(HTML_MENU.CONTAINER_AGREEMENTS, HTML_MENU.BTN_AGREEMENTS);
    });

    function beforeCallStyleHandler() {
        $('.column-add-info .card-add-info button.clicked-color').removeClass('clicked-color');
        $('.column-add-info .card-add-info.clicked-bg').removeClass('clicked-bg');

        $(HTML_MENU.CONTAINER_SUBENTITIES).addClass('d-none');
        $(HTML_MENU.CONTAINER_DISTINCT).addClass('d-none');
        $(HTML_MENU.CONTAINER_CHART).addClass('d-none');
        $(HTML_MENU.CONTAINER_TIMELINES).addClass('d-none');
        $(HTML_MENU.CONTAINER_DOCUMENTS).addClass('d-none');
        $(HTML_MENU.CONTAINER_AGREEMENTS).addClass('d-none');
    }

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

    function afterCallStyleHandler(container, btn) {
        $(container).removeClass('d-none');
        $(btn).parent().addClass('clicked-bg');
        $(btn).addClass('clicked-color');
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

// ________________________________________________________
//
// Select menu from chosen.js initialization
$(function () {
    $(".select-pharus").chosen({
        disable_search_threshold: 10,
        width: "260px",
    })
});