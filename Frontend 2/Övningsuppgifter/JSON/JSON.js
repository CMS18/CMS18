/**
|--------------------------------------------------
| FRÅGA 1
|--------------------------------------------------
*/

var person = {
    "fornamn": "Lisa",
    "efternamn": "Lind",
    "adress": {
        "gata": "Storgatan 3",
        "postort": "Södertälje",
        "postnr": "11122"
    },
    "kurser": ["Javascript1", "Javascript2", "Webbdesign"]
}

console.log(person.fornamn + ' ' + person.efternamn)

/**
|--------------------------------------------------
| FRÅGA 2
|--------------------------------------------------
*/

// FOR LOOP

for (let index = 0; index < person.kurser.length; index++) {
    console.log(person.kurser[index]);
    
}

// FOREACH

person.kurser.forEach(element => {
    console.log(element)
});


/**
|--------------------------------------------------
| FRÅGA 3
|--------------------------------------------------
*/

console.log(person.adress.gata + ' ' + person.adress.postnr + ' ' + person.adress.postort)
