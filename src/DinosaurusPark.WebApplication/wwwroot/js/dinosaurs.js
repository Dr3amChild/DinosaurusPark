async function generate(speciesCount, dinosaursCount) {
    const response = await window.fetch("/generation/create", {
        method: "POST",
        headers: {
            'Content-Type': "application/json"
        },
        body: JSON.stringify({ speciesCount, dinosaursCount })
    });
    return await response.json();
}

async function loadDinosaurs(count, offset) {
    const response = await window.fetch(`/all?offset=${offset}&count=${count}`, {
        method: "GET"
    });
    return await response.json();
}