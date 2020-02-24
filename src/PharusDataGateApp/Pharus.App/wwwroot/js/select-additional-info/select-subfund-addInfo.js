// ________________________________________________________
//
// Select menu for fund additional information -
// subentities, timeline changes, all documents
// Get selected value and keep select option open

$('#subFundAdditionalInfSelect option').each(function () {
    if (this.selected) {
        const dropdownvalue = $("#subFundAdditionalInfSelect option:selected").val();
        if (dropdownvalue == 'ShareClasses') {
            $("#subEntities").removeClass('d-none');
            $("#timelineChanges").addClass('d-none');
            $("#allDocuments").addClass('d-none');
            $("#allAgreements").addClass('d-none');
        } else if (dropdownvalue == 'TimelineChanges') {
            $("#timelineChanges").removeClass('d-none');
            $("#subEntities").addClass('d-none');
            $("#allDocuments").addClass('d-none');
            $("#allAgreements").addClass('d-none');
        } else if (dropdownvalue == 'AllDocuments') {
            $("#allDocuments").removeClass('d-none');
            $("#timelineChanges").addClass('d-none');
            $("#subEntities").addClass('d-none');
            $("#allAgreements").addClass('d-none');
        } else if (dropdownvalue == 'AllAgreements') {
            $("#allAgreements").removeClass('d-none');
            $("#timelineChanges").addClass('d-none');
            $("#subEntities").addClass('d-none');
            $("#allDocuments").addClass('d-none');
        } else {
            $("#subEntities").addClass('d-none');
            $("#timelineChanges").addClass('d-none');
            $("#allDocuments").addClass('d-none');
            $("#allAgreements").addClass('d-none');
        }
    }
});

// ________________________________________________________
//
// Select menu for fund additional information -
// subentities, timeline changes, all documents -
// On change event for selected value

$("#subFundAdditionalInfSelect").on('change', function () {
    const dropdownvalue = $("#subFundAdditionalInfSelect option:selected").val();
    if (dropdownvalue == 'ShareClasses') {
        $("#subEntities").removeClass('d-none');
        $("#timelineChanges").addClass('d-none');;
        $("#allDocuments").addClass('d-none');
        $("#allAgreements").addClass('d-none');
    } else if (dropdownvalue == 'TimelineChanges') {
        $("#timelineChanges").removeClass('d-none');
        $("#subEntities").addClass('d-none');
        $("#allDocuments").addClass('d-none');
        $("#allAgreements").addClass('d-none');
    } else if (dropdownvalue == 'AllDocuments') {
        $("#allDocuments").removeClass('d-none');
        $("#timelineChanges").addClass('d-none');
        $("#subEntities").addClass('d-none');
        $("#allAgreements").addClass('d-none');
    } else if (dropdownvalue == 'AllAgreements') {
        $("#allAgreements").removeClass('d-none');
        $("#timelineChanges").addClass('d-none');
        $("#subEntities").addClass('d-none');
        $("#allDocuments").addClass('d-none');
    } else {
        $("#subEntities").addClass('d-none');
        $("#timelineChanges").addClass('d-none');
        $("#allDocuments").addClass('d-none');
        $("#allAgreements").addClass('d-none');
    }
});