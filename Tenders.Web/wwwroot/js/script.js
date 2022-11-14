function formatPhoneNumber(value) {
    if (!value) return value;
    const phoneNumber = value.replace(/\D/g, '');
    const phoneNumberLength = phoneNumber.length;
    if (phoneNumberLength < 4) return phoneNumber;
    if (phoneNumberLength < 7) {
        return `(${phoneNumber.slice(0, 3)}) ${phoneNumber.slice(3)}`;
    }
    else if (phoneNumberLength === 7) {
        return `+7 (${phoneNumber.slice(0, 3)}) ${phoneNumber.slice(3)}`
    }
    else {
        console.log(phoneNumber)
        return `+7 (${phoneNumber.slice(1, 4)}) ${phoneNumber.slice(4, 7)}-${phoneNumber.slice(7, 11)}`;    
    }
    // console.log(phoneNumber)
    // return `+7 (${phoneNumber.slice(0, 3)}) ${phoneNumber.slice(3, 6)}-${phoneNumber.slice(6, 10)}`;
    
}

function phoneNumberFormatter() {
    const inputField = document.getElementById('phoneNumber');
    inputField.value = formatPhoneNumber(inputField.value);
}
