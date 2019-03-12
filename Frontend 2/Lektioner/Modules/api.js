var api = (function () {


    async function localfetchData(url) {

        let promise = await fetch(url).then(res => res.json());
        return promise;

    }

    async function localpostData(url, data) {
        await fetch(url, {
            method: 'POST',
            body: JSON.stringify(data),
            headers: {
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': 'application/json'
            }
        })
    }

    return {
        fetchData: localfetchData,
        postData: localpostData,
    };

})();