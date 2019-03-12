
//Lösning som görs direkt med Javascrip och XMLHttpRequest
//OBS DETTA ÄR DET GAMLA SÄTTET. NI SKALL ANVÄNDA FETCH!!!

function getdata(url)
{
    let myrequest = new XMLHttpRequest();

    myrequest.onreadystatechange = function() {
    	if (myrequest.readyState == XMLHttpRequest.DONE) {    		
            myCallbackfunction(myrequest.responseText);
    	}
	}
    myrequest.open('GET',url , true);
	myrequest.send(null);
}

function myCallbackfunction(response)
{
    let todoItem = JSON.parse(response);
    let newElement = document.createElement('p');
    let text = document.createTextNode(todoItem.title);
    newElement.appendChild(text);

    document.body.appendChild(newElement);
}

//Anropar med urlen till web api:et
getdata('https://jsonplaceholder.typicode.com/todos/1');
