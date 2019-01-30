//Skapa eventlistners för varje textarea
document.querySelector("#Description").addEventListener(
    "keyup", function () { countCharacters('#Description', '#counter') });


//Generell funktion för räknare
function countCharacters(source, target) {
    let maxLength = document.querySelector(source).maxLength;
    let length = document.querySelector(source).value.length;
    document.querySelector(target).innerHTML = length + "/" + maxLength;
}