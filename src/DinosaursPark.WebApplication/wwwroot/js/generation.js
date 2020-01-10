class Generation {
    constructor(speciesCount, dinosaursCount, pageSize) {
        this.speciesCount = speciesCount;
        this.dinosaursCount = dinosaursCount;
        this.api = new DinosaursApi(pageSize);
    }
    
    showForm() {
        const area = document.getElementById("no-data-alert");
        area.style.display = "block";
        ReactDOM.unmountComponentAtNode(area);
        ReactDOM.render(
            React.createElement(GenerationForm,
                {
                    onClick: async () => await this.onGenerateClick(this.api),
                    species: this.speciesCount,
                    dinosaurs: this.dinosaursCount
                }),
            area);
    }

    async onGenerateClick() {
        const speciesCount = parseInt(document.getElementById("species-count-text").value);
        const dinosaursCount = parseInt(document.getElementById("dinosaurs-count-text").value);
        await this.api.generate(speciesCount, dinosaursCount);
        window.location.href = "/"; //todo add redirect
    }
}
