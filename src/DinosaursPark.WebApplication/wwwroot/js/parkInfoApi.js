class ParkInfoApi {   
    async getParkInfo() {
        const response = await window.fetch(`/information/park`, {
            method: "GET"
        });
        return await response.json();
    }

    async getSpeciesInfo() {
        const response = await window.fetch(`/information/species`, {
            method: "GET"
        });
        return await response.json();
    }
}