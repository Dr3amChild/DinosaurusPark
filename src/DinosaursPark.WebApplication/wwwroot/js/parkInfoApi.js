class ParkInfoApi {   
    async getParkInfo() {
        return this.getInner(`/information/park`);
    }

    async getSpeciesInfo() {
        return this.getInner(`/information/species`);
    }

    async delete() {
        return this.deleteInner(`/information`);
    }

    async getInner(url) {
        const response = await window.fetch(url, {
            method: "GET"
        });

        const responseText = await response.json();        
        if(!response.ok) {
            throw new Error(responseText);
        }
        
        return responseText;
    }

    async deleteInner(url) {
        const response = await window.fetch(url, { method: "DELETE" });
       
        if (!response.ok) {
            throw new Error(response);
        }
    }
}