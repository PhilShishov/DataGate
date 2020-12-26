'use strict'

let hubConnect = new signalR.HubConnectionBuilder()
    .withUrl('/notificationHub')
    .build();

hubConnect.start()
    .then(() => {
        console.log('Server Notification: Connected');
        hubConnect.invoke('GetUserNotificationCount').then((count) => {
            if (count > 0) {
                document.getElementById("notification-badge").classList.add("display-count");
                document.getElementById('notification-badge').setAttribute('data-count', count);
            }
        })
    }).catch(function (err) {
        return console.error(err.toString());
    });

hubConnect.on('SendNotification', function (count) {
    if (count > 0) {
        document.getElementById("notification-badge").classList.add("display-count");
        document.getElementById('notification-badge').setAttribute('data-count', count);
    } else {
        document.getElementById("notification-badge").classList.remove("display-count");
    }
})
