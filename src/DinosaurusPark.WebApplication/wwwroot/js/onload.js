window.onload = async () => {
    document.getElementById("generate-btn").addEventListener("click", async () => {
        window.generate(10, 100);
        const result = await window.loadDinosaurs(1, 10);
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