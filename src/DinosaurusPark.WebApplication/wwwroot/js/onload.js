window.onload = async () => {
    document.getElementById("generate-btn").addEventListener("click", async () => {
        window.generate(5, 20);
        const result = await window.loadDinosaurs(10, 0);
        window.show(result.items);
    });

    const result = await window.loadDinosaurs(10, 0);
    if (!result || !result.items.length) {
        document.getElementById("no-data-alert").style.display = "block";
    } else {
        show(result.items);
    }
}