class Pages extends React.Component {
    render() {
        return (
            <ul id="paging-list" className="pagination pagination-lg">
                {this.createPages()}
            </ul>
        );
    }

    createPages() {
        const pages = [];        
        for (let idx = 1; idx <= this.props.pagesCount; ++idx) {
            pages.push(<Page key={idx} pageNum={idx} activePage={this.props.activePage} onClick={this.props.onClick} />);
        }
        return pages;
    }
}

class Page extends React.Component {
    render() {
        return (
            <li className={this.props.pageNum === this.props.activePage ? "page-item active" : "page-item"} onClick={this.props.onClick} page-num={this.props.pageNum} >
                <span className='page-link'>{this.props.pageNum}</span>
            </li>
        );
    }
}