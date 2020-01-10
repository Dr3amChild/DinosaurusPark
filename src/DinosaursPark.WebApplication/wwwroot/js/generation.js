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
        const result = await this.api.getPage(1);
        document.getElementById("no-data-alert").style.display = "none";
        this.show(result);
        this.setPaging(result, (e) => this.onPageClick(e, this.api));
    }

    show(paging) {
        const area = document.getElementById("dinosaurs-area");
        ReactDOM.render(React.createElement(Cards, { items: paging.items }), area);
    }

    setPaging(paging) {
        const pagingArea = document.getElementById("paging-nav");
        ReactDOM.unmountComponentAtNode(pagingArea);
        ReactDOM.render(React.createElement(
            Paging,
            {
                pagesCount: paging.pagesCount,
                activePage: paging.pageNumber,
                onClick: (e) => this.onPageClick(e, this.api)
            }), pagingArea);
    }

    async onPageClick(e, api) {
        const pageNum = e.currentTarget.getAttribute("page-num");
        const result = await api.getPage(pageNum);
        const pages = document.getElementsByClassName("page-item");
        for (let page of pages) {
            page.className = page.getAttribute("page-num") === pageNum ? "page-item active" : "page-item";
        }
        show(result);
    }
}
