window.chartColors = [
    'rgb(54, 162, 235)',
    'rgb(255, 159, 64)',
    'rgb(255, 205, 86)',
    'rgb(75, 192, 192)',
    'rgb(153, 102, 255)',
    'rgb(255, 99, 132)',
    'rgb(201, 203, 207)'
];

const HTML_MENU = {
    BTN_SUBENTITIES: '#btn-open-subentities',
    BTN_DISTINCT: '#btn-open-distinct',
    BTN_CHART: '#btn-open-chart',
    BTN_TIMELINE: '#btn-open-timeline',
    BTN_DOCUMENTS: '#btn-open-documents',
    BTN_AGREEMENTS: '#btn-open-agreements',
    BTN_COUNTRIES_DIST: '#btn-open-countries-dist',
    CONTAINER_SUBENTITIES: '#subEntities',
    CONTAINER_DISTINCT: '#distinctDocuments',
    CONTAINER_CHART: '#aumChart',
    CONTAINER_TIMELINES: '#timelineChanges',
    CONTAINER_DOCUMENTS: '#allDocuments',
    CONTAINER_AGREEMENTS: '#allAgreements',
    CONTAINER_COUNTRIES_DIST: '#countriesDist',
    ICONS_EDITOR: 'icon-edit',
    TABLE_INFO: 'table-info-datagate',
};

const URLS = {
    TIMELINES: '/loadTimelines',
    TIMESERIES: '/loadTimeseries',
    DISTINCT: '/loadDistinct',
    DOCUMENTS: '/loadAllDoc',
    AGREEMENTS: '/loadAllAgr',
    COUNTRIES_DIST: '/loadCountriesDist',
};

// ________________________________________________________
//
// Menu for fund additional information -
// subentities, timeline changes, distinct documents,
// all documents, aum chart, countries of distribution

function loadAddInfo(token, urlSubEnt, json) {
    $(HTML_MENU.BTN_SUBENTITIES).on('click', function (event) {

        $('body').css('overflow', 'visible');
        $('.footer-datagate').eq(0).hide();

        beforeCallStyleHandler();
        $.ajax({
            url: urlSubEnt,
            type: 'GET',
            data: json,
            contentType: 'application/json; charset=utf-8',
            headers: { 'X-CSRF-TOKEN': token },
        }).done(function (data) {
            if (data) {
                $(HTML_MENU.CONTAINER_SUBENTITIES).html(data);

                $('html, body').animate({
                    scrollTop: $(HTML_MENU.CONTAINER_SUBENTITIES).position().top - 80
                }, 'slow');
            }
        }).fail(function (request, status, error) {
            console.log(request.responseText);
            window.location = '/error';
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

    $(HTML_MENU.BTN_COUNTRIES_DIST).on('click', function () {
        beforeCallStyleHandler();
        getSelectMenuRequestHandler(URLS.COUNTRIES_DIST, HTML_MENU.CONTAINER_COUNTRIES_DIST);
        afterCallStyleHandler(HTML_MENU.CONTAINER_COUNTRIES_DIST, HTML_MENU.BTN_COUNTRIES_DIST);
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
        $(HTML_MENU.CONTAINER_COUNTRIES_DIST).addClass('d-none');
    }

    function getSelectMenuRequestHandler(url, placeholder) {
        console.log(url);
        console.log(token);
        console.log(json);

        $('.footer-datagate').eq(0).show();

        $.ajax({
            url: url,
            type: 'GET',
            data: json,
            contentType: 'application/json; charset=utf-8',
            headers: { 'X-CSRF-TOKEN': token },
        }).done(function (data) {
            if (data) {
                $(placeholder).html(data);
            }
        }).fail(function (request, status, error) {
            window.location = '/error';
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

        const isFee = false;
        const form = $(this).parents('.modal').find('form');
        const token = $('input[name=__RequestVerificationToken]', form).val();
        const actionUrl = form.attr('action');
        const dataToSend = new FormData(form.get(0));

        postModalRequest(placeholderAgreement, actionUrl, dataToSend, token, isFee);
    });

    placeholderAgreement.on('click', '[data-save="modalFees"]', function (event) {
        event.preventDefault();

        const isFee = true;
        const form = $(this).parents('.modal').find('form');
        const token = $('input[name=__RequestVerificationToken]', form).val();
        const actionUrl = form.attr('action');
        const dataToSend = new FormData(form.get(0));

        postModalRequest(placeholderAgreement, actionUrl, dataToSend, token, isFee);
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

    function postModalRequest(placeholderElement, actionUrl, dataToSend, token, isFee) {
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
                const url = '/Upload/OnUploadSuccess?areaName=' + areaName + '&date=' + date + '&id=' + id + '&routeName=' + routeName + '&isFee=' + isFee;
                window.location = url;
                return;
            }
            const newBody = $('.modal-body', data);
            placeholderElement.find('.modal-body').replaceWith(newBody);

        }).fail(function (request, status, error) {
            swal(request.responseText, {
                icon: "error"
            })
        });
    }
};

$(function () {
    // ________________________________________________________
    //
    // Quick editor text
    //const rows = document.getElementById(HTML_MENU.TABLE_INFO).getElementsByTagName('tr');

    //for (var row of rows) {
    //    row.addEventListener('mouseenter', displayIconOnHoverHandler);

    //    function displayIconOnHoverHandler(event) {
    //        const icon = event.target.getElementsByClassName(HTML_MENU.ICONS_EDITOR)[0];

    //        if (icon) {
    //            icon.style.visibility = 'visible';
    //            icon.addEventListener('click', openEditorHandler);
    //        }

    //        function openEditorHandler() {
    //            const divEditor = document.createElement('div');
    //            divEditor.classList.add('quick-card-editor');

    //            const divInputs = document.createElement('div');
    //            divInputs.classList.add('quick-card-editor-container');
    //            divInputs.style.top = '14%';
    //            divInputs.style.left = '18%';
    //            divInputs.style.width = '16%';
    //            divEditor.addEventListener('click', function (event) {
    //                event.preventDefault();
    //                if (!divInputs.contains(event.target)) {
    //                    icon.removeEventListener('click', openEditorHandler);
    //                    divEditor.remove();
    //                }
    //            });

    //            divEditor.appendChild(divInputs);
    //            document.body.appendChild(divEditor);
    //        };
    //    };

    //    row.addEventListener('mouseleave', function (event) {
    //        const icon = event.target.getElementsByClassName(HTML_MENU.ICONS_EDITOR)[0];

    //        if (icon) {
    //            icon.style.visibility = 'hidden';
    //        }
    //    });
    //}
});