let newButton = document.createElement('button');
newButton.appendChild(document.createTextNode('Visa värde'));
document.body.appendChild(newButton);

let mess = {
    "text": "Detta är värdet från web storage"
}
sessionStorage.setItem("message", JSON.stringify(mess));


newButton.addEventListener('click', function () {
    let data = JSON.parse(sessionStorage.getItem("message"));

    alert(data.text);
})