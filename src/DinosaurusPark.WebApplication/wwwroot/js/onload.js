window.onload = () => {
    document.getElementById("generate-btn").addEventListener("click", async () => {
        window.generate(5, 20);
    });

    const result = window.loadDinosaurs(10, 0);
    if (!result) {
        alert("NOOOO!");
    }
}