class DinosaursApi extends BaseApi {
    constructor(pageSize) {
        this.pageSize = pageSize;
    }

    async generate(speciesCount, dinosaursCount) {        
        return this.postInner("/generation/create", { speciesCount, dinosaursCount });
    }

    async getById(id) {
        return await this.getInner(`/get?id=${id}`);
    }

    async getPage(pageNumber) {
        return await this.getInner(`/all?pageSize=${this.pageSize}&pageNumber=${pageNumber}`);
    }

    async delete() {        
        await this.deleteInner(`/`); 
    }
}