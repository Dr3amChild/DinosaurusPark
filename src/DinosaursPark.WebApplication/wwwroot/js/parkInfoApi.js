class ParkInfoApi {   
    async getParkInfo() {
        return this.getOrThrow(`/information/park`);
    }

    async getSpeciesInfo() {
        return this.getOrThrow(`/information/species`);
    }
    
    async getOrThrow(url) {
        const response = await window.fetch(url, {
            method: "GET"
        });

        const responseText = await response.json();
        if(!response.ok) {
            throw new Error(responseText);
        }

        return responseText;
    }
}