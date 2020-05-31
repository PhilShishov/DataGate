const HTML = {
    FORM_EXTRACT: '#extract-form',
    BTN_EXTRACT_EXCEL: '#btn-extract-excel',
    BTN_EXTRACT_PDF: '#btn-extract-pdf',
    FORM_UPDATE: 'update-form',
    CHECKBOX_ACTIVE: 'activeCheckBox',
    TABLE_EXTRACT: 'table-to-extract',
    TBODY_UPDATE_INACTIVE: 'tbody-update-inactive',
};

const SELECTORS = {
    INPUT_TOKEN_EXTRACT: `${HTML.FORM_EXTRACT} input[name=__RequestVerificationToken]`
};

const CLASSES = {
    INACTIVE: 'inactive-entity'
};

const MESSAGES = {
    BLOCKUI_USER_MESSAGE: 'Please wait a moment...'
};

function extract(model) {
    const excelValue = $(HTML.BTN_EXTRACT_EXCEL).attr('value');
    const pdfValue = $(HTML.BTN_EXTRACT_PDF).attr('value');
    const table = document.getElementById(HTML.TABLE_EXTRACT);

    let tableValues = [];

    for (let row of table.rows) {
        let tableRows = [];
        for (let cell of row.cells) {
            tableRows.push(cell.innerText);
        }
        tableValues.push(tableRows);
    }

    model.TableValues = tableValues;
    const token = $(SELECTORS.INPUT_TOKEN_EXTRACT).val();

    $(document).on('click', HTML.BTN_EXTRACT_EXCEL, function (event) {
        event.preventDefault()
        model.Command = excelValue;

        extractRequestHandler(model, token);
    });

    $(document).on('click', HTML.BTN_EXTRACT_PDF, function (event) {
        event.preventDefault()
        model.Command = pdfValue;

        extractRequestHandler(model, token);
    });

    function extractRequestHandler(model, token) {
        $.blockUI({ message: `<h3>${MESSAGES.BLOCKUI_USER_MESSAGE}</h3>` });
        $.ajax({
            url: '/Media/GenerateReport',
            type: 'POST',
            data: model,
            headers: { 'X-CSRF-TOKEN': token },
        }).done(function (data) {
            if (!data.success) {
                setTimeout($.unblockUI, 500);
                alert(data.errorMessage);
                return;
            }
            setTimeout($.unblockUI, 1000);
            if (data.fileName != '') {
                const url = '/Media/Download?fileName=' + data.fileName;
                window.location = url;
            }
        }).fail(function (request, status, error) {
            alert(request.responseText);
        });
    }
}

// Submit form on checkbox change - show active and inactive entities
function submitForm() {
    const updateForm = document.getElementById(HTML.FORM_UPDATE);
    const checkbox = document.getElementById(HTML.CHECKBOX_ACTIVE);

    if (checkbox) {
        checkbox.addEventListener('change', submitFormOnChange);

        function submitFormOnChange() {
            updateForm.submit();
        }
    }
};

// Add inactive class to entities that have inactive status
(function () {
    const rows = document.getElementById(HTML.TBODY_UPDATE_INACTIVE).getElementsByTagName('tr');
    for (var row of rows) {
        const cells = row.getElementsByTagName('td');
        for (var cell of cells) {
            if (cell.textContent.includes('Inactive')) {
                row.classList.add(CLASSES.INACTIVE);
            }
        }
    }
})();
// Autocomplete 

function loadAutocomplete(token, controllerToPass, entityId) {
    $('#SelectTerm').select2({
        placeholder: 'Quick Select',
        theme: 'classic',
        ajax: {
            url: '/api/autocomplete',
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            headers: { 'X-CSRF-TOKEN': token },
            delay: 250,
            data: function (params) {
                return {
                    selectTerm: params.term,
                    controllerToPass: controllerToPass,
                    id: entityId
                };
            },
            processResults: function (data) {
                return { results: data }
            }
        }
    });
}