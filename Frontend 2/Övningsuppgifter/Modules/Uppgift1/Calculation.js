let calculation = (function () {


    function addition(a, b) {


        return a + b


    }

    function subtraction(a, b) {
        return a - b;


    }

    function division(a, b) {
        return a / b;


    }

    function multiplication(a, b) {
        return a * b;

    }

    return {
        add: addition,
        sub: subtraction,
        div: division,
        mult: multiplication
    };



})();

console.log(calculation.add(5, 10));
console.log(calculation.sub(25, 10));
console.log(calculation.div(5, 10));
console.log(calculation.mult(5, 10));