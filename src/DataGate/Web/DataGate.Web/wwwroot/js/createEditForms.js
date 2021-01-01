const HTML_CREATE_EDIT = {
    BTN_CONFIRM_CREATE: 'btn-confirm-create',
    BTN_CONFIRM_DELETE: 'btn-confirm-delete',
    BTN_CONFIRM_UPDATE: 'btn-confirm-update',
    DIV_INPUTS_FORMAT: 'div-inputs-to-format',
    INPUT_NAME_TO_FORMAT: 'formatName',
    CHECKBOX_DERIVATIVES: 'derivatives',
    SELECT_MENU_DERIV_PURPOSE: 'derivPurpose',
    SELECT_MENU_DERIV_MARKET: 'derivMarket'
};

const SELECTORS_CREATE_EDIT = {
    INPUTS_ALL_EXCEPT_FORMAT_NAME: `input:not(#${HTML_CREATE_EDIT.INPUT_NAME_TO_FORMAT})`
};

function createEdit(confirmations, messages_btn) {
    const CONFIRMATIONS = confirmations;
    const MESSAGES_BTN = messages_btn;

    // Confirm create
    (function () {
        const buttons = document.getElementsByClassName(HTML_CREATE_EDIT.BTN_CONFIRM_CREATE);

        if (buttons) {
            for (let btn of buttons) {
                btn.addEventListener('click',
                    function (event) {
                        const form = $(this).parent().parent();
                        event.preventDefault();
                        swal({
                            title: CONFIRMATIONS.CREATE,
                            icon: "warning",
                            buttons: [
                                MESSAGES_BTN.FAIL,
                                MESSAGES_BTN.SUCCESS
                            ],
                        }).then((isConfirm) => {
                            if (!isConfirm) return;
                            form.submit();
                            return true;
                        });
                    });
            }
        }
    })();

    // Confirm delete
    (function () {
        const buttons = document.getElementsByClassName(HTML_CREATE_EDIT.BTN_CONFIRM_DELETE);

        if (buttons) {
            for (let btn of buttons) {
                btn.addEventListener('click',
                    function (event) {
                        const form = $(this).parent().parent();
                        event.preventDefault();
                        swal({
                            title: CONFIRMATIONS.DELETE,
                            icon: "warning",
                            buttons: [
                                MESSAGES_BTN.FAIL,
                                MESSAGES_BTN.SUCCESS
                            ],
                        }).then((isConfirm) => {
                            if (!isConfirm) return;
                            form.submit();
                            return true;
                        });
                    });
            }
        }
    })();

    // Confirm edit
    (function () {
        const buttons = document.getElementsByClassName(HTML_CREATE_EDIT.BTN_CONFIRM_UPDATE);

        if (buttons) {
            for (let btn of buttons) {
                btn.addEventListener('click',
                    function (event) {
                        const form = $(this).parent().parent();
                        event.preventDefault();
                        swal({
                            title: CONFIRMATIONS.UPDATE,
                            icon: "warning",
                            buttons: [
                                MESSAGES_BTN.FAIL,
                                MESSAGES_BTN.SUCCESS
                            ],
                        }).then((isConfirm) => {
                            if (!isConfirm) return;
                            form.submit();
                            return true;
                        });
                    });
            }
        }
    })();
}

// Format input fields 
(function () {
    const inputFields = document.getElementById(HTML_CREATE_EDIT.DIV_INPUTS_FORMAT);

    if (inputFields) {
        const selectedInputFields = inputFields.querySelectorAll(SELECTORS_CREATE_EDIT.INPUTS_ALL_EXCEPT_FORMAT_NAME);

        for (var i = 0; i < selectedInputFields.length; i++) {
            selectedInputFields[i].addEventListener('input', function (event) {
                let input = event.target;
                input.value = input.value.toUpperCase();
            });
        }
    }
})();

// Special format for sub fund and share class upon creation or update
(function () {
    const formatNameInput = document.getElementById(HTML_CREATE_EDIT.INPUT_NAME_TO_FORMAT);

    if (formatNameInput) {
        formatNameInput.addEventListener('blur', formatSubFundAndShareClassName);
    }

    function formatSubFundAndShareClassName() {

        if (this.value) {
            this.value = this.value.trimStart();
            this.value = this.value.trimEnd();
            this.value = capitalLetter(this.value);

            function capitalLetter(str) {
                str = str.split(" ");

                for (let i = 0, x = str.length; i < x; i++) {
                    str[i] = str[i][0].toUpperCase() + str[i].substr(1);
                }
                return str.join(" ");
            }
        }
    }
})();

// Open derivatives additional options
(function () {
    const checkboxDeriv = document.getElementById(HTML_CREATE_EDIT.CHECKBOX_DERIVATIVES);

    const derivMarket = document.getElementById(HTML_CREATE_EDIT.SELECT_MENU_DERIV_MARKET);
    const derivPurpose = document.getElementById(HTML_CREATE_EDIT.SELECT_MENU_DERIV_PURPOSE);

    if (checkboxDeriv) {
        checkboxDeriv.addEventListener('click', function () {
            if (this.checked == true) {
                console.log('here2');
                derivMarket.removeAttribute('hidden');
                derivPurpose.removeAttribute('hidden');
            } else {
                derivMarket.setAttribute('hidden', true);
                derivPurpose.setAttribute('hidden', true);
            }
        })
    }
})();

$(function () {
    $(".select-datagate").chosen({
        disable_search_threshold: 10,
        width: "269px",
    })
});