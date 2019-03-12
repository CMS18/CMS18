/**
|--------------------------------------------------
| JSON
|--------------------------------------------------
*/

let person = {
    "name": "Lisa",
    "email": "lisa@gmail.com"
};

console.log(person.name);

let personString = '{"name":"Kalle","email":"kalle@gmail.com"}';
let person2 = JSON.parse(personString);

console.log(person2.name);

console.log(JSON.stringify(person2));


let person3 = {
    "name": "Lisa",
    "email": "lisa@gmail.com",
    "language": ["Swedish", "English", "French"]
};

console.log(person3.language[0]);
console.log(person3.language[1]);

for (let lang of person3.language) {
    console.log(lang)
}

/**
|--------------------------------------------------
| ARRAY OF OBJECT
|--------------------------------------------------
*/

let personList =
    [
        { "name": "kalle", "email": "kalle@gmail.com" },
        { "name": "lisa", "email": "lista@gmail.com" }
    ];

let personList2 = {
    "date": "2019-03-06",
    "persons": [{
            "name": "kalle",
            "email": "kalle@gmail.com"
        },
        {
            "name": "lisa",
            "email": "lista@gmail.com"
        }
    ]
};

for (let person of personList2.persons) {
    console.log(person.name + '- ' + person.email)
}