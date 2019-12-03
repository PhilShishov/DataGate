function loadDate() {
    if (document.getElementById("fundDatetime").value == "") {
        let date = (formatDate(new Date())).toString();

        document.getElementById("fundDatetime").value = date;
    }
    function formatDate(date) {
        let day = ('0' + date.getDate()).slice(-2);
        let month = ('0' + (date.getMonth() + 1)).slice(-2);
        let year = date.getFullYear();

        return year + '-' + month + '-' + day;
    }
}