(function () {
    const btn = document.getElementById('confirmCreateBtn');
    btn.addEventListener('click',
        function (event) {
            let con = confirm('Are you sure you want to create this?');

            if (!con) {
                event.preventDefault();
            }
        });
})();