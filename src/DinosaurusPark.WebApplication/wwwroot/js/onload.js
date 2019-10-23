window.onload = async () => {
    document.getElementById("generate-btn").addEventListener("click", async () => {
        const speciesCount = document.getElementById("species-count-text").value;
        const dinosaursCount = document.getElementById("dinosaurs-count-text").value;
        await window.generate(speciesCount, dinosaursCount);
        const result = await window.loadDinosaurs(1, 10);
        document.getElementById("no-data-alert").style.display = "none";
        window.show(result);
        setPaging(result, onPageClick);
    });

    const result = await window.loadDinosaurs(1, 10);
    if (!result || !result.items.length) {
        document.getElementById("no-data-alert").style.display = "block";
    } else {
        show(result);
        setPaging(result, onPageClick);
    }
}