const HTML_NAVBAR = {
    NOTIFICATION_MENU_TOOGLER: 'badge-notification-container',
    NOTIFICATION_BADGE: 'notification-badge',
    SEARCH_MENU_PARENT: 'search-form-wrapper-responsive',
    SEARCH_MENU: 'search-form-wrapper',
    SEARCH_MENU_TOOGLER: 'open-search-box',
    USER_MENU_TOOGLER: 'responsive-menu',
};

const CLASSES_NAVBAR = {
    ACTIVE: 'active',
    OPEN: 'open',
    OPENED: 'opened',
    UNREAD: 'unread'
};

(function () {
    const searchMenuParent = document.getElementsByClassName(HTML_NAVBAR.SEARCH_MENU_PARENT)[0];
    const searchMenu = document.getElementsByClassName(HTML_NAVBAR.SEARCH_MENU)[0];
    const searchMenuToogler = document.getElementsByClassName(HTML_NAVBAR.SEARCH_MENU_TOOGLER)[0];
    const userMenuToogler = document.getElementsByClassName(HTML_NAVBAR.USER_MENU_TOOGLER)[0];
    const notifMenuToogler = document.getElementsByClassName(HTML_NAVBAR.NOTIFICATION_MENU_TOOGLER)[0];
    const notifButton = document.getElementById(HTML_NAVBAR.NOTIFICATION_BADGE);

    if (notifButton) {
        notifButton.addEventListener('click', () => {
            var token = $('#load-notification-form input[name=__RequestVerificationToken]').val();
            $.ajax({
                url: '/loadNotifications',
                type: 'GET',
                contentType: 'application/json; charset=utf-8',
                headers: { 'X-CSRF-TOKEN': token },
            }).done(function (data) {
                if (data) {
                    $('#user-notifications').html(data);
                    notifMenuToogler.classList.toggle(CLASSES_NAVBAR.OPEN);

                    const notifDots = document.getElementsByClassName('dot');
                    if (notifDots) {
                        for (var dot of notifDots) {
                            dot.addEventListener('click', (ev) => {
                                ev.stopPropagation();
                                var json = { notifId: dot.getAttribute('data-id') };
                                $.ajax({
                                    url: '/api/notifications',
                                    type: 'GET',
                                    data: json,
                                    contentType: 'application/json; charset=utf-8',
                                    headers: { 'X-CSRF-TOKEN': token },
                                    dataType: 'json',
                                }).done((data) => {
                                    ev.target.parentElement.classList.remove(CLASSES_NAVBAR.UNREAD);
                                    ev.target.remove();
                                }).fail(function (request, status, error) {
                                    swal(request.responseText, {
                                        icon: "error"
                                    })
                                });
                            });
                        }
                    }

                    const markAll = document.getElementsByClassName('mark-all-read')[0];

                    if (markAll) {
                        markAll.addEventListener('click', (ev) => {
                            ev.stopPropagation();
                            $.ajax({
                                url: '/api/notifications/all',
                                type: 'GET',
                                contentType: 'application/json; charset=utf-8',
                                headers: { 'X-CSRF-TOKEN': token },
                                dataType: 'json',
                            }).done((data) => {

                                for (var dot of notifDots) {
                                    dot.parentElement.classList.remove(CLASSES_NAVBAR.UNREAD);
                                    dot.remove();
                                }
                            }).fail(function (request, status, error) {
                                swal(request.responseText, {
                                    icon: "error"
                                })
                            });
                        });
                    }
                }
            }).fail(function (request, status, error) {
                swal(request.responseText, {
                    icon: "error"
                })
            });
        })
    }

    // Toogle notification menu
    if (notifMenuToogler) {
        notifMenuToogler.addEventListener('click', () => {
            if (userMenuToogler.classList.contains(CLASSES_NAVBAR.OPEN)) {
                userMenuToogler.classList.toggle(CLASSES_NAVBAR.OPEN);
            }

            if (!searchMenu.classList.contains('d-none')) {
                searchMenuParent.classList.toggle(CLASSES_NAVBAR.OPENED);
                searchMenu.classList.add('d-none');
            }
        });
    }

    // Toogle search menu
    if (searchMenuToogler) {
        searchMenuToogler.addEventListener('click', toggleSearchMenu);

        function toggleSearchMenu() {

            if (notifMenuToogler.classList.contains(CLASSES_NAVBAR.OPEN)) {
                notifMenuToogler.classList.toggle(CLASSES_NAVBAR.OPEN);
            }

            if (userMenuToogler.classList.contains(CLASSES_NAVBAR.OPEN)) {
                userMenuToogler.classList.toggle(CLASSES_NAVBAR.OPEN);
            }

            searchMenuParent.classList.toggle(CLASSES_NAVBAR.OPENED);
            const searchMenuStatus = searchMenu.classList.contains('d-none');

            if (searchMenuStatus) {
                searchMenu.classList.remove('d-none');
            } else {
                searchMenu.classList.add('d-none');
            }
        };
    }

    // Toggle user menu
    if (userMenuToogler) {
        userMenuToogler.addEventListener('click', () => {
            if (!searchMenu.classList.contains('d-none')) {
                searchMenuParent.classList.toggle(CLASSES_NAVBAR.OPENED);
                searchMenu.classList.add('d-none');
            }

            if (notifMenuToogler.classList.contains(CLASSES_NAVBAR.OPEN)) {
                notifMenuToogler.classList.toggle(CLASSES_NAVBAR.OPEN);
            }

            userMenuToogler.classList.toggle(CLASSES_NAVBAR.OPEN);
        })
    }
})();


window.addEventListener('scroll', showBackToTop);

function showBackToTop() {
    let scrollPos = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop;

    var scroll = document.getElementsByClassName('back-to-top')[0];

    if (scrollPos > 40) {
        scroll.style.display = "inline";
    } else {
        scroll.style.display = "none";
    }
    scroll.addEventListener('click', backToTop);
}

function backToTop() {
    let doc = document.documentElement;
    let left = (doc.clientLeft || 0);
    let top = (doc.clientTop || 0);
    window.scrollTo({
        top: top,
        left: left,
        behavior: 'smooth'
    });
}