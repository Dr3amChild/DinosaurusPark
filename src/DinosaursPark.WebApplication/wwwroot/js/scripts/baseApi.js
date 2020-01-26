class BaseApi {
    async getInner(url) {
        const response = await window.fetch(url, { method: "GET" });
        const responseText = await response.json();        
        if(!response.ok) {
            throw new Error(responseText);
        }
        
        return responseText;
    }

    async postInner(url, data) {
        const response = await window.fetch(url, { 
            method: "POST",
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify(data)
        });
        return await response.json();
    }


    async deleteInner(url) {
        const response = await window.fetch(url, { method: "DELETE" });       
        if (!response.ok) {
            throw new Error(response);
        }
    }
}
