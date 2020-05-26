function extract(model) {

    const SELECTORS = {
        TOKEN_EXTRACT: '#extract-form input[name=__RequestVerificationToken]',
        EXTRACT_EXCEL_BUTTON: 'btn-extract-excel',
        EXTRACT_PDF_BUTTON: 'btn-extract-pdf',
        jQ_EXTRACT_EXCEL_BUTTON: '#btn-extract-excel',
        jQ_EXTRACT_PDF_BUTTON: '#btn-extract-pdf',
        TABLE_EXTRACT: 'table-entities',
    };

    const excelValue = document.getElementById(SELECTORS.EXTRACT_EXCEL_BUTTON).getAttribute('value');
    const pdfValue = document.getElementById(SELECTORS.EXTRACT_PDF_BUTTON).getAttribute('value');
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

    $(document).on('click', SELECTORS.jQ_EXTRACT_EXCEL_BUTTON, function (event) {
        event.preventDefault()
        model.Command = excelValue;

        extractRequestHandler(model, token);
    });

    $(document).on('click', SELECTORS.jQ_EXTRACT_PDF_BUTTON, function (event) {
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