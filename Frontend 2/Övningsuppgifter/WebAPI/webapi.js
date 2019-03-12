const url = "https://swapi.co/api/";

getAllData()

createlist('films', '')

async function getData(type, input) {
    //Tar emot svaret från anropet 
    let res = await fetchData(url + type + "?search=" + input);
    return (res);

}   

//Generell funktion som anropar ett web api med get och returnerar JSON
async function fetchData(url) {

    //Skickar anropet till webbservern och väntar på svar
    //Svaret kommer och man tar ut json datat
    let promise = await fetch(url).then(res => res.json());

    //Returnera json från funktionen
    return promise;

}

async function getAllData(){
    
}

async function createlist(type, input, ) {
    let res = await getData(type, input);
    let results = res.results;
    let sorted = results.sort(compare);

    let ul = document.createElement('ul');

    for (let result of sorted) {
        let li = document.createElement('li');

        let node = document.createTextNode(result.title + ' - ' + result.director + ' | ' + result.release_date);

        li.appendChild(node);
        ul.appendChild(li);
    }

    document.body.appendChild(ul);
}

function compare(a, b) {
    if (a.release_date < b.release_date)
        return -1;
    if (a.release_date > b.release_date)
        return 1;
    return 0;
}