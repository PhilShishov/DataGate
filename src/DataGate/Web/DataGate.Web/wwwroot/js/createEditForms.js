const HTML_CREATE_EDIT = {
    BTN_CONFIRM_CREATE: 'btn-confirm-create',
    BTN_CONFIRM_DELETE: 'btn-confirm-delete',
    BTN_CONFIRM_UPDATE: 'btn-confirm-update',
    DIV_INPUTS_FORMAT: 'div-inputs-to-format',
    INPUT_NAME_TO_FORMAT: 'formatName',
    SELECT_MENU_DERIVATIVES: 'derivatives',
    SELECT_MENU_DERIV_PURPOSE: 'derivPurpose',
    SELECT_MENU_DERIV_MARKET: 'derivMarket'
};

const SELECTORS = {
    INPUTS_ALL_EXCEPT_FORMAT_NAME: `input:not(#${HTML_CREATE_EDIT.INPUT_NAME_TO_FORMAT})`
};

const MESSAGES = {
    CONFIRM_CREATE: 'Are you sure you want to create this?',
    CONFIRM_DELETE: 'Are you sure you want to delete this?',
    CONFIRM_UPDATE: 'Are you sure you want to update this?',
};

// Confirm create
(function () {
    const buttons = document.getElementsByClassName(HTML_CREATE_EDIT.BTN_CONFIRM_CREATE);

    if (buttons) {
        for (let btn of buttons) {
            btn.addEventListener('click',
                function (event) {
                    let con = confirm(MESSAGES.CONFIRM_CREATE);

                    if (!con) {
                        event.preventDefault();
                    }
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
                    let con = confirm(MESSAGES.CONFIRM_DELETE);

                    if (!con) {
                        event.preventDefault();
                    }
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
                    let con = confirm(MESSAGES.CONFIRM_UPDATE);

                    if (!con) {
                        event.preventDefault();
                    }
                });
        }
    }
})();

// Format input fields 
(function () {
    const inputFields = document.getElementById(HTML_CREATE_EDIT.DIV_INPUTS_FORMAT);

    if (inputFields) {
        const selectedInputFields = inputFields.querySelectorAll(SELECTORS.INPUTS_ALL_EXCEPT_FORMAT_NAME);

        for (var i = 0; i < selectedInputFields.length; i++) {
            selectedInputFields[i].addEventListener('blur', formatInput);
        }
    }

    function formatInput() {
        this.value = this.value.trimStart();
        this.value = this.value.trimEnd();
        this.value = this.value.toUpperCase();
    }
})();

// Special format for sub fund and share class upon creation or update
(function () {
    const formatNameInput = document.getElementById(HTML_CREATE_EDIT.INPUT_NAME_TO_FORMAT);

    if (formatNameInput) {
        formatNameInput.addEventListener('blur', formatSubFundAndShareClassName);
    }

    function formatSubFundAndShareClassName() {
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
})();

// Open derivatives additional options
(function () {
    const deriv = document.getElementById(HTML_CREATE_EDIT.SELECT_MENU_DERIVATIVES);

    const derivMarket = document.getElementById(HTML_CREATE_EDIT.SELECT_MENU_DERIV_MARKET);
    const derivPurpose = document.getElementById(HTML_CREATE_EDIT.SELECT_MENU_DERIV_PURPOSE);

    if (deriv) {
        if (deriv.value == 'Yes') {
            derivMarket.removeAttribute('hidden');
            derivPurpose.removeAttribute('hidden');
        } else {
            derivMarket.setAttribute('hidden', true);
            derivPurpose.setAttribute('hidden', true);
        }

        deriv.addEventListener('change', openDeriv);
    }

    function openDeriv() {
        if (deriv.options[deriv.selectedIndex].text === 'Yes') {
            derivMarket.removeAttribute('hidden');
            derivPurpose.removeAttribute('hidden');
        } else {
            derivMarket.setAttribute('hidden', true);
            derivPurpose.setAttribute('hidden', true);
        }
    }
})();