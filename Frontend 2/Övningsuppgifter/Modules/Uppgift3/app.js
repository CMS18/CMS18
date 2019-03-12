
getData();

async function getData(){

    let url = 'https://swapi.co/api/films/1/'
    let data = await api.fetchdata(url);

    alert(JSON.stringify(data));

};
