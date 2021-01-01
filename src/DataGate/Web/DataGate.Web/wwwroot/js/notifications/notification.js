'use strict'

const NOTIFICATION_SOCKETS = {
    SEND: 'SendNotification',
    COUNT: 'NotificationCount',
    JOIN_ADMIN: 'JoinAdmin',
}

const HTML_NOTIFICATION = {
    BADGE: 'notification-badge',
};

let hubConnect = new signalR.HubConnectionBuilder()
    .withUrl('/notificationHub')
    .build();

var badge = document.getElementById(HTML_NOTIFICATION.BADGE);

hubConnect.start()
    .then(() => {
        console.log('Server Notification: Connected');
        hubConnect.invoke(NOTIFICATION_SOCKETS.COUNT).then((count) => {
            if (count > 0) {

                badge.classList.add("display-count");
                badge.setAttribute('data-count', count);
            }

            hubConnect.invoke(NOTIFICATION_SOCKETS.JOIN_ADMIN);
        })
    }).catch(function (err) {
        return console.error(err.toString());
    });

hubConnect.on(NOTIFICATION_SOCKETS.SEND, function (count) {
    if (count > 0) {
        badge.classList.add("display-count");
        badge.setAttribute('data-count', count);
    } else {
        badge.classList.remove("display-count");
    }
})
