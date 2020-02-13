class Paging {
    constructor(api, pagingAreaId, callback) {
        this.api = api;
        this.paginAreaId = pagingAreaId;
        this.showDataCallback = callback;
    }
    
    render(paging, large = false) {
        const pagingArea = document.getElementById(this.paginAreaId);
        ReactDOM.unmountComponentAtNode(pagingArea);
        ReactDOM.render(React.createElement(
            Pages,
            {
                pagesCount: paging.pagesCount,
                activePage: paging.pageNumber,
                large,
                onClick: (e) => this.onPageClick(e, paging, large)
            }), pagingArea);
    }
     
    async onPageClick(e, paging, large) {
        const pageNum = e.currentTarget.getAttribute("page-num");
        const pages = document.getElementsByClassName("page-item");
        for (let page of pages) {
            page.className = page.getAttribute("page-num") === pageNum ? "page-item active" : "page-item";
        }
        this.showDataCallback(pageNum);
        paging.pageNumber = parseInt(pageNum);
        this.render(paging, large);
    }
}