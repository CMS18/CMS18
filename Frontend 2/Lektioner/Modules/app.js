getData();

async function getData() {
    let url = "http://data.fixer.io/api/latest?access_key=7183d8d3353b93913956a97d1a62d230";

    let result = await api.fetchData(url);

    alert(JSON.stringify(result));
}

async function insertData() {
    let person = {
        "name": "kalle",
        "email": "kalle@gmail.com"
    };

    await api.postData(url, person);
}