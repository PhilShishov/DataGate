function extract(model) {
    const SELECTORS = {
        TOKEN_EXTRACT: '#extract-form input[name=__RequestVerificationToken]',
        EXTRACT_EXCEL_BUTTON: '#btn-extract-excel',
        EXTRACT_PDF_BUTTON: '#btn-extract-pdf',
        TABLE_EXTRACT: 'table-entities',
    };
    const excelValue = $(SELECTORS.EXTRACT_EXCEL_BUTTON).attr('value');
    const pdfValue = $(SELECTORS.EXTRACT_PDF_BUTTON).attr('value');
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

    $(document).on('click', SELECTORS.EXTRACT_EXCEL_BUTTON, function (event) {
        event.preventDefault()
        model.Command = excelValue;

        extractRequestHandler(model, token);
    });

    $(document).on('click', SELECTORS.EXTRACT_PDF_BUTTON, function (event) {
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
            setTimeout($.unblockUI, 1000);
            if (!data.success) {
                alert(data.errorMessage);
                return;
            }
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