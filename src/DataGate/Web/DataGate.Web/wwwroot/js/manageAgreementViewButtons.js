function manageAgreementViewButtons() {

    const fundAgr = document.getElementById('allFundAgreements')
    const subfundAgr = document.getElementById('allSubFundAgreements')
    const shareclassAgr = document.getElementById('allShareClassAgreements')

    const fundBtn = document.getElementById('btn-show-funds');
    const subfundBtn = document.getElementById('btn-show-subfunds');
    const shareclassBtn = document.getElementById('btn-show-shareclasses');

    fundBtn.addEventListener('click', showFundAgr);
    subfundBtn.addEventListener('click', showSubFundAgr);
    shareclassBtn.addEventListener('click', showShareClassAgr);

    function showFundAgr() {
        fundAgr.classList.remove('d-none');
        subfundAgr.classList.add('d-none');
        shareclassAgr.classList.add('d-none');
    }

    function showSubFundAgr() {
        subfundAgr.classList.remove('d-none');
        shareclassAgr.classList.add('d-none');
        fundAgr.classList.add('d-none');
    }

    function showShareClassAgr() {
        shareclassAgr.classList.remove('d-none');
        subfundAgr.classList.add('d-none');
        fundAgr.classList.add('d-none');
    }
}