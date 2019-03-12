var api = (function () {

    async function fetchData(url) {
        //without chaining

        // var promise = await fetch(url);
        // var data = await promise.json();
        // return data;

        //with chaining

        return await fetch(url).then((promise) => {
            return promise.json()
        });

    }
    return {
        fetchdata: fetchData
    }

})();