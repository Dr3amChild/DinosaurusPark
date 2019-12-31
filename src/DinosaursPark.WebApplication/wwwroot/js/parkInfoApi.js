class ParkInfoApi {   
    async load() {
        const response = await window.fetch(`/information/load`, {
            method: "GET"
        });
        return await response.json();
    }
}