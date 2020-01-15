function getDerivatives() {
    const deriv = document.getElementById('derivatives');

    const derivMarket = document.getElementById('derivMarket');
    const derivPurpose = document.getElementById('derivPurpose');

    if (deriv.value == 'Yes') {
        derivMarket.removeAttribute('hidden');
        derivPurpose.removeAttribute('hidden');
    } else {
        derivMarket.setAttribute('hidden', true);
        derivPurpose.setAttribute('hidden', true);
    }

    deriv.addEventListener('change', openDeriv);

    function openDeriv() {
        if (deriv.options[deriv.selectedIndex].text === 'Yes') {
            derivMarket.removeAttribute('hidden');
            derivPurpose.removeAttribute('hidden');
        } else {
            derivMarket.setAttribute('hidden', true);
            derivPurpose.setAttribute('hidden', true);
        }
    }
}