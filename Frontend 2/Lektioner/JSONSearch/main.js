var myBookList = {
    "books": [{
            "title": "Javascript introduktion",
            "price": "299"
        },
        {
            "title": "Java",
            "price": "599"
        },
        {
            "title": "C# introduction",
            "price": "599"
        },
        {
            "title": "Java EE first",
            "price": "599"
        },
        {
            "title": "Javascript web api book",
            "price": "599"
        },
        {
            "title": "C++ for beginners",
            "price": "599"
        },
        {
            "title": "Angular introduction",
            "price": "599"
        },
        {
            "title": "React bible",
            "price": "599"
        }
    ]
};

var searchButton = document.querySelector("#searchButton");
searchButton.addEventListener('click', function () {

    let searchVal = document.querySelector("#searchValue").value;
    let result = myBookList.books.filter(b => b.title.includes(searchVal));
    
    let resultList = document.querySelector("#searchResult");

    resultList.innerHTML=' ';

    result.forEach(element => {
        
        let newElement = document.createElement('p');

        let bookText = element.title + ' - ' + element.price;

        let textNode = document.createTextNode(bookText);

        newElement.appendChild(textNode);

        resultList.appendChild(newElement);

    });
});