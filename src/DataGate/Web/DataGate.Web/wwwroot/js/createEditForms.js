// Confirm create
(function () {
    const btn = document.getElementById('confirmCreateBtn');

    if (btn) {
        btn.addEventListener('click',
            function (event) {
                let con = confirm('Are you sure you want to create this?');

                if (!con) {
                    event.preventDefault();
                }
            });
    }
})();


// Confirm delete
(function () {
    const buttons = document.getElementsByClassName('confirmDelBtn');

    if (buttons) {
        for (var btn of buttons) {
            btn.addEventListener('click',
                function (event) {
                    let con = confirm('Are you sure you want to delete this?');

                    if (!con) {
                        event.preventDefault();
                    }
                });
        }
    }
})();

// Confirm edit
(function () {
    const btn = document.getElementById('confirmEditBtn');

    if (btn) {
        btn.addEventListener('click',
            function (event) {
                let con = confirm('Are you sure you want to update this?');

                if (!con) {
                    event.preventDefault();
                }
            });
    }
})();

// Format input fields 
(function () {
    const createFormInputFields = document.getElementById('div-format-inputs').querySelectorAll('input:not(#formatName)');

    if (createFormInputFields) {
        for (var i = 0; i < createFormInputFields.length; i++) {
            createFormInputFields[i].addEventListener('blur', formatInput);
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
    const formatNameInput = document.getElementById('formatName');

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
    const deriv = document.getElementById('derivatives');

    const derivMarket = document.getElementById('derivMarket');
    const derivPurpose = document.getElementById('derivPurpose');

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