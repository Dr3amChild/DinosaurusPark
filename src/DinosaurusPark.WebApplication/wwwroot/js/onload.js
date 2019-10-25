window.onload = async () => {
    const api = new DinosaursApi(10);

    document.getElementById("generate-btn").addEventListener("click", async () => {
        const speciesCount = document.getElementById("species-count-text").value;
        const dinosaursCount = document.getElementById("dinosaurs-count-text").value;
        await api.generate(speciesCount, dinosaursCount);
        const result = await api.getPage(1);
        document.getElementById("no-data-alert").style.display = "none";
        window.show(result);
        setPaging(result, (e) => onPageClick(e, api));
    });

    const result = await api.getPage(1);
    if (!result || !result.items.length) {
        document.getElementById("no-data-alert").style.display = "block";
    } else {
        show(result);
        setPaging(result, (e) => onPageClick(e, api));
    }
}