const HTML = {
    FORM_EXTRACT: '#extract-form',
    BTN_EXTRACT_EXCEL: '#btn-extract-excel',
    BTN_EXTRACT_PDF: '#btn-extract-pdf',
    FORM_UPDATE: 'update-form',
    CHECKBOX_ACTIVE: 'activeCheckBox',
    TABLE_EXTRACT: 'table-to-extract',
    TBODY_UPDATE_INACTIVE: 'tbody-update-inactive',
    BTN_RESET: 'btn-reset',
};

const SELECTORS = {
    INPUT_TOKEN_EXTRACT: `${HTML.FORM_EXTRACT} input[name=__RequestVerificationToken]`
};

const CLASSES = {
    INACTIVE: 'inactive-entity'
};

function extract(model) {
    const excelValue = $(HTML.BTN_EXTRACT_EXCEL).attr('value');
    const pdfValue = $(HTML.BTN_EXTRACT_PDF).attr('value');
    const token = $(SELECTORS.INPUT_TOKEN_EXTRACT).val();
    const table = document.getElementById(HTML.TABLE_EXTRACT);

    $(document).on('click', HTML.BTN_EXTRACT_EXCEL, function (event) {
        event.preventDefault();
        let tableValues = [];

        for (let row of table.rows) {
            let tableRows = [];
            for (let cell of row.cells) {
                tableRows.push(cell.innerText);
            }
            tableValues.push(tableRows);
        }
        model.TableValues = tableValues;
        model.Command = excelValue;

        extractRequestHandler(model, token);
    });

    $(document).on('click', HTML.BTN_EXTRACT_PDF, function (event) {
        event.preventDefault();
        let tableValues = [];

        for (let row of table.rows) {
            let tableRows = [];
            for (let cell of row.cells) {
                tableRows.push(cell.innerText);
            }
            tableValues.push(tableRows);
        }
        model.TableValues = tableValues;
        model.Command = pdfValue;

        extractRequestHandler(model, token);
    });

    function extractRequestHandler(model, token) {
        $.blockUI({
            message: $('#blockui-panel'),
            css: {
                border: 'none',
                padding: '15px',
                '-webkit-border-radius': '10px',
                '-moz-border-radius': '10px',
            },
        });
        $.ajax({
            url: '/Media/GenerateReport',
            type: 'POST',
            data: model,
            headers: { 'X-CSRF-TOKEN': token },
        }).done(function (data) {
            if (!data.success) {
                $.unblockUI();
                swal(data.errorMessage, {
                    icon: "error"
                })
                return;
            }
            setTimeout($.unblockUI, 1000);
            if (data.fileName != '') {
                const url = '/Media/Download?fileName=' + data.fileName;
                window.location = url;
            }
        }).fail(function (request, status, error) {
            $.unblockUI();
            swal(request.responseText, {
                icon: "error"
            });
        });
    }
}

// ________________________________________________________
//
// Datatables for reports - sort, search, pagination and total result
function dataTableReportHandler(type) {
    $.fn.dataTable.moment('DD/MM/YYYY');

    const formatter = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'EUR',
    });

    // Remove the formatting to get aum data for total
    let aumValue = function (input) {
        return typeof input === 'string' && input != 'Not available' ?
            input.replace(/[\€,]/g, '') * 1 :
            typeof input === 'number' ?
                input : 0;
    };

    jQuery.extend(jQuery.fn.dataTableExt.oSort, {
        "formatted-num-pre": function (a) {
            a = (a === "-" || a === "") ? 0 : a.replace(/[^\d\-\.]/g, "");
            return parseFloat(a);
        },
        "formatted-num-asc": function (a, b) {
            return a - b;
        },
        "formatted-num-desc": function (a, b) {
            return b - a;
        }
    });

    if (type === 'Fund') {
        $('.table-view-datagate').DataTable({
            "dom": '<"top">t<"bottom"><"clear">',
            columnDefs: [
                { type: 'formatted-num', targets: "_all" }
            ],
            "pageLength": 50,
            "scrollX": true,
            "autoWidth": false,
            stateSave: true,
            "footerCallback": function (row, data, start, end, display) {
                var api = this.api(), data;

                const colCount = $(this).find("tr:first td").length;

                for (let i = 1; i < colCount; i++) {
                    total = api
                        .column(i)
                        .data()
                        .reduce(function (a, b) {
                            return aumValue(a) + aumValue(b);
                        }, 0);

                    // Update footer
                    $(api.column(i).footer()).html(formatter.format(total));
                }

            }
        });
    } else {
        $('.table-view-datagate').DataTable({
            "dom": '<"top"lf>rt<"bottom"ip><"clear">',
            "lengthMenu": [[-1, 10, 25, 50], ["All", 10, 25, 50]],
            "scrollX": true,
            "autoWidth": false,
            stateSave: true,
            "footerCallback": function (row, data, start, end, display) {
                var api = this.api(), data;

                // Total over this page
                pageTotal = api
                    .column(6, { page: 'current' })
                    .data()
                    .reduce(function (a, b) {
                        return aumValue(a) + aumValue(b);
                    }, 0);

                // Total over all pages
                total = api
                    .column(6)
                    .data()
                    .reduce(function (a, b) {
                        return aumValue(a) + aumValue(b);
                    }, 0);

                // Update footer
                $(api.column(6).footer()).html(formatter.format(pageTotal) + ' | ' + formatter.format(total) + ' total |');
            }
        });
    }

    $(".dataTables_length select").chosen({
        disable_search_threshold: 10,
        width: "68px",
    });
}