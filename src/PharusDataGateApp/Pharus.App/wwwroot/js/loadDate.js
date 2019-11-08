function loadDate() {
    if (document.getElementById("fundDatetime").value == "") {
        let date = (formatDate(new Date())).toString();

        document.getElementById("fundDatetime").value = date;
    }
    function formatDate(date) {
        var day = ('0' + date.getDate()).slice(-2);
        var month = ('0' + (date.getMonth() + 1)).slice(-2);
        var year = date.getFullYear();

        return year + '-' + month + '-' + day;
    }
}