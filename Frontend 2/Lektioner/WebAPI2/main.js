
//Lösning som görs via jQuery(som använder XMLHttpRequest)
//OBS DETTA ÄR DET GAMLA SÄTTET. NI SKALL ANVÄNDA FETCH!!!

$.get('https://jsonplaceholder.typicode.com/todos/1', function(response){

    myCallbackFunction(response);
})

function myCallbackFunction(response)
{
    let newElement = document.createElement('p');
    let text = document.createTextNode(response.title);
    newElement.appendChild(text);

    document.body.appendChild(newElement);
}