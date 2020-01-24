class DinosaursApi {
    constructor(pageSize) {
        this.pageSize = pageSize;
    }

    async generate(speciesCount, dinosaursCount) {
        const response = await window.fetch("/generation/create", {
            method: "POST",
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify({ speciesCount, dinosaursCount })
        });
        return await response.json();
    }

    async getById(id) {
        const response = await window.fetch(`/get?id=${id}`, {
            method: "GET"
        });
        return await response.json();
    }

    async getPage(pageNumber) {
        const response = await window.fetch(`/all?pageSize=${this.pageSize}&pageNumber=${pageNumber}`, {
            method: "GET"
        });
        return await response.json();
    }

    async delete() {
        await window.fetch(`/`, { method: "DELETE" });       
    }
}