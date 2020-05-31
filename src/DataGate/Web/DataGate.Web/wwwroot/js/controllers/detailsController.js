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

// Double top scroll plugin
(function ($) {

    jQuery.fn.doubleScroll = function (userOptions) {

        // Default options
        let options = {
            contentElement: undefined, // Widest element, if not specified first child element will be used
            scrollCss: {
                'overflow-x': 'auto',
                'overflow-y': 'hidden',
                'height': '20px'
            },
            contentCss: {
                'overflow-x': 'auto',
                'overflow-y': 'hidden'
            },
            onlyIfScroll: true, // top scrollbar is not shown if the bottom one is not present
            resetOnWindowResize: false, // recompute the top ScrollBar requirements when the window is resized
            timeToWaitForResize: 30 // wait for the last update event (usefull when browser fire resize event constantly during ressing)
        };

        $.extend(true, options, userOptions);

        // do not modify
        // internal stuff
        $.extend(options, {
            topScrollBarMarkup: '<div class="doubleScroll-scroll-wrapper"><div class="doubleScroll-scroll"></div></div>',
            topScrollBarWrapperSelector: '.doubleScroll-scroll-wrapper',
            topScrollBarInnerSelector: '.doubleScroll-scroll'
        });

        let _showScrollBar = function ($self, options) {
            if (options.onlyIfScroll && $self.get(0).scrollWidth <= $self.width()) {
                // content doesn't scroll
                // remove any existing occurrence...
                $self.prev(options.topScrollBarWrapperSelector).remove();
                return;
            }
            // add div that will act as an upper scroll only if not already added to the DOM
            let $topScrollBar = $self.prev(options.topScrollBarWrapperSelector);

            if ($topScrollBar.length == 0) {

                // creating the scrollbar
                // added before in the DOM
                $topScrollBar = $(options.topScrollBarMarkup);
                $self.before($topScrollBar);

                // apply the css
                $topScrollBar.css(options.scrollCss);
                $(options.topScrollBarInnerSelector).css("height", "20px");
                $self.css(options.contentCss);

                // bind upper scroll to bottom scroll
                $topScrollBar.bind('scroll.doubleScroll', function () {
                    $self.scrollLeft($topScrollBar.scrollLeft());
                });

                // bind bottom scroll to upper scroll
                let selfScrollHandler = function () {
                    $topScrollBar.scrollLeft($self.scrollLeft());
                };
                $self.bind('scroll.doubleScroll', selfScrollHandler);
            }

            // find the content element (should be the widest one)	
            let $contentElement;

            if (options.contentElement !== undefined && $self.find(options.contentElement).length !== 0) {
                $contentElement = $self.find(options.contentElement);
            } else {
                $contentElement = $self.find('>:first-child');
            }

            // set the width of the wrappers
            $(options.topScrollBarInnerSelector, $topScrollBar).width($contentElement.outerWidth());
            $topScrollBar.width($self.width());
            $topScrollBar.scrollLeft($self.scrollLeft());
        }

        return this.each(function () {
            let $self = $(this);

            _showScrollBar($self, options);
            // bind the resize handler 
            // do it once
            if (options.resetOnWindowResize) {
                let id;
                let handler = function (e) {
                    _showScrollBar($self, options);
                };

                $(window).bind('resize.doubleScroll', function () {
                    // adding/removing/replacing the scrollbar might resize the window
                    // so the resizing flag will avoid the infinite loop here...
                    clearTimeout(id);
                    id = setTimeout(handler, options.timeToWaitForResize);
                });
            }
        });
    }

}(jQuery));