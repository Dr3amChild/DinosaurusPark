class ParkInfoApi extends BaseApi {
    constructor(pageSize) {
        super();
        this.pageSize = pageSize;
    }

    async getParkInfo() {
        return this.getInner(`/information/park`);
    }

    async getSpeciesInfo(pageNumber) {
        return this.getInner(`/information/species?pageSize=${this.pageSize}&pageNumber=${pageNumber}`);
    }

    async delete() {
        return this.deleteInner(`/information`);
    }
}