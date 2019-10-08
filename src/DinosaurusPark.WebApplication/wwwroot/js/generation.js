(function() {
    document.getElementById("generate-btn").addEventListener("click", async () => {
        const response = await window.fetch("/generation/create", {
            method: "POST",
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify({ speciesCount: 5, dinosaursCount: 20 })
        });
        return await response.json();
    });
})();