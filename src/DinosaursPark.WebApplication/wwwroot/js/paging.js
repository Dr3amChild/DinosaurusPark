class Paging {
    constructor(api) {
        this.api = api;
    }
    
    show(paging) {
        const area = document.getElementById("dinosaurs-area");
        ReactDOM.render(React.createElement(Cards, { items: paging.items }), area);
    }

    setPaging(paging) {
        const pagingArea = document.getElementById("paging-nav");
        ReactDOM.unmountComponentAtNode(pagingArea);
        ReactDOM.render(React.createElement(
            Pages,
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
        this.show(result);
    }
}