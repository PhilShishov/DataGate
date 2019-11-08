function getDerivatives() {
    const deriv = document.getElementById('derivatives');

    const derivMarket = document.getElementById('derivMarket');
    const derivMarketLbl = document.getElementById('derivMarketLabel');

    const derivPurpose = document.getElementById('derivPurpose');
    const derivPurposeLbl = document.getElementById('derivPurposeLabel');

    if (deriv.options[deriv.selectedIndex].text === 'Yes') {
        derivMarket.removeAttribute('hidden');
        derivMarketLbl.removeAttribute('hidden');
        derivPurpose.removeAttribute('hidden');
        derivPurposeLbl.removeAttribute('hidden');
    }
    else {
        derivMarket.setAttribute('hidden', true);
        derivMarketLbl.setAttribute('hidden', true);
        derivPurpose.setAttribute('hidden', true);
        derivPurposeLbl.setAttribute('hidden', true);
    }
}