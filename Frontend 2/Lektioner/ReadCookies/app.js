init();

async function init() {


    let url = 'https://swapi.co/api/films/1/';
    let data = await api.fetchdata(url);

    utilities.setcookie("todo", JSON.stringify(data), 2)

    document.querySelector("#visa").addEventListener('click', function () {

        let value = utilities.readcookie("todo");
        alert(value);

    });
}