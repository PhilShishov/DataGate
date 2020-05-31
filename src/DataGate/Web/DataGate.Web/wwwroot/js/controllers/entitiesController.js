const SELECTORS = {
    TOKEN_EXTRACT: '#extract-form input[name=__RequestVerificationToken]',
    BTN_EXTRACT_EXCEL: '#btn-extract-excel',
    BTN_EXTRACT_PDF: '#btn-extract-pdf',
    TABLE_EXTRACT: 'table-entities',
};
function extract(model) {
    const excelValue = $(SELECTORS.BTN_EXTRACT_EXCEL).attr('value');
    const pdfValue = $(SELECTORS.BTN_EXTRACT_PDF).attr('value');
    const table = document.getElementById(SELECTORS.TABLE_EXTRACT);

    let tableValues = [];

    for (let row of table.rows) {
        let tableRows = [];
        for (let cell of row.cells) {
            tableRows.push(cell.innerText);
        }
        tableValues.push(tableRows);
    }

    model.TableValues = tableValues;
    const token = $(SELECTORS.TOKEN_EXTRACT).val();

    $(document).on('click', SELECTORS.BTN_EXTRACT_EXCEL, function (event) {
        event.preventDefault()
        model.Command = excelValue;

        extractRequestHandler(model, token);
    });

    $(document).on('click', SELECTORS.BTN_EXTRACT_PDF, function (event) {
        event.preventDefault()
        model.Command = pdfValue;

        extractRequestHandler(model, token);
    });

    function extractRequestHandler(model, token) {
        $.blockUI({ message: '<h3>Please wait a moment...</h3>' });
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
    const checkbox = document.getElementById('activeCheckBox');
    //const select = document.getElementById('SelectTerm');

    const updateForm = document.getElementById('update-form');

    checkbox.addEventListener('change', submitFormOnChange);
    //select.addEventListener('change', submitForm);

    function submitFormOnChange() {
        updateForm.submit();
    }
};

// Add inactive class to entities that have inactive status
(function () {
    const rows = document.getElementById('tbody-entities').getElementsByTagName('tr');
    for (var row of rows) {
        const cells = row.getElementsByTagName('td');
        for (var cell of cells) {
            if (cell.textContent.includes('Inactive')) {
                row.classList.add('inactive-entity');
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