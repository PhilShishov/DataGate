function confirmDelete() {
    const buttons = document.getElementsByClassName('confirmDelBtn');

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