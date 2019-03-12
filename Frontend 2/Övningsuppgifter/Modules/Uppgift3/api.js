var api = (function () {

    async function fetchData(url) {

        return await fetch(url).then((promise) => {
            return promise.json()
        });

    }
    return {
        fetchdata: fetchData
    }

})();