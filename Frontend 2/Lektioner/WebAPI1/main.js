getData();

async function getData()
{
    let url = "https://swapi.co/api/films/1";

    //Tar emot svaret från anropet 
    let result = await fetchData(url);

    //alert(JSON.stringify(result));

    //Läser ut data och visar svaret på webbsidan
    let newElement = document.createElement('p');

    let text = result.title + '-' + result.director;
    
    let textnode = document.createTextNode(text);

    newElement.appendChild(textnode);

    document.body.appendChild(newElement);


}

//Generell funktion som anropar ett web api med get
//och returnerar JSON
async function fetchData(url)
{
    //Skickar anropet till webbservern och väntar på svar
    let promise = await fetch(url);

    //Svaret kommer och man tar ut json datat
    let data = await promise.json();

    //Returnera json från funktionen
    return data;

}

