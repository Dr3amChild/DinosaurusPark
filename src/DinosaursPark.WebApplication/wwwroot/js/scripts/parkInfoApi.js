class ParkInfoApi extends BaseApi {   
    async getParkInfo() {
        return this.getInner(`/information/park`);
    }

    async getSpeciesInfo() {
        return this.getInner(`/information/species`);
    }

    async delete() {
        return this.deleteInner(`/information`);
    }    
}