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

function show(dinosaurs) {
    const area = document.getElementById("dinosaurus-area");

    for (let dinosaur of dinosaurs) {
        const child = document.createElement('div');
        child.innerHTML = `<div>Name: ${dinosaur.name}</div>`;
        area.appendChild(child);
    }
}