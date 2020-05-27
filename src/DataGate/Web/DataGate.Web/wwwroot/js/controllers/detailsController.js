function loadAddInfo(token, url, json) {
    // ________________________________________________________
    //
    // Select menu for fund additional information -
    // subentities, timeline changes, all documents -
    // On change event for selected value

    $('#fundAdditionalInfSelect').on('change', function () {
        const dropdownvalue = $('#fundAdditionalInfSelect option:selected').val();

        $(this).find('[selected]').removeAttr('selected')
        $(this).find(':selected').attr('selected', 'selected')
        if (dropdownvalue == 'SubFunds') {
            $('#subEntities').css('visibility', 'visible');
            $('#timelineChanges').addClass('d-none');
            $('#allDocuments').addClass('d-none');
            $('#allAgreements').addClass('d-none');

            $.ajax({
                url: url,
                type: 'GET',
                data: json,
                contentType: 'application/json; charset=utf-8',
                headers: { 'X-CSRF-TOKEN': token },
                success: function (response) {
                    $('#loadSubEntities').html(response);
                }
            });
        } else if (dropdownvalue == 'TimelineChanges') {
            $('#timelineChanges').removeClass('d-none');
            $('#subEntities').css('visibility', 'hidden');
            $('#allDocuments').addClass('d-none');
            $('#allAgreements').addClass('d-none');

            $.ajax({
                url: '/loadTimelines',
                type: 'GET',
                data: json,
                contentType: 'application/json; charset=utf-8',
                headers: { 'X-CSRF-TOKEN': token },
                success: function (response) {
                    $('#loadTimelines').html(response);
                }
            });
        } else if (dropdownvalue == 'AllDocuments') {
            $('#allDocuments').removeClass('d-none');
            $('#timelineChanges').addClass('d-none');
            $('#subEntities').css('visibility', 'hidden');
            $('#allAgreements').addClass('d-none');

            $.ajax({
                url: '/loadAllDoc',
                type: 'GET',
                data: json,
                contentType: 'application/json; charset=utf-8',
                headers: { 'X-CSRF-TOKEN': token },
                success: function (response) {
                    $('#loadAllDocuments').html(response);
                }
            });
        } else if (dropdownvalue == 'AllAgreements') {
            $('#allAgreements').removeClass('d-none');
            $('#timelineChanges').addClass('d-none');
            $('#subEntities').css('visibility', 'hidden');
            $('#allDocuments').addClass('d-none');

            $.ajax({
                url: '/loadAllAgr',
                type: 'GET',
                data: json,
                contentType: 'application/json; charset=utf-8',
                headers: { 'X-CSRF-TOKEN': token },
                success: function (response) {
                    $('#loadAllAgreements').html(response);
                }
            });
        } else {
            $('#subEntities').css('visibility', 'hidden');
            $('#timelineChanges').addClass('d-none');
            $('#allDocuments').addClass('d-none');
            $('#allAgreements').addClass('d-none');
        }
    });
}

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
            const newBody = $('.modal-body', data);
            placeholderElement.find('.modal-body').replaceWith(newBody);
            if (data.success) {
                console.log(data.dto);
                const { areaName, date, id, routeName } = data.dto;
                console.log(routeName);
                const url = '/Upload/OnUploadSuccess?areaName=' + areaName + '&date=' + date + '&id=' + id + '&routeName=' + routeName;
                window.location = url;
            }

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