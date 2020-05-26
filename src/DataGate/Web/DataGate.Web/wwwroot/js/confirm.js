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