(function () {
    const btn = document.getElementById('confirmEditBtn');
    btn.addEventListener('click',
        function (event) {
            let con = confirm('Are you sure you want to update this?');

            if (!con) {
                event.preventDefault();
            }
        });
})();