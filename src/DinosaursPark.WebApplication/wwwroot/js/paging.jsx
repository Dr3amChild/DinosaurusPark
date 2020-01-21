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
        const min = 1;
        const max = this.props.pagesCount;

        const array = this.generateIndicies(max, this.props.activePage, 10);
        if (array[0] > min) {
            this.addPage(1, 1, pages);
            if (array[0] - min > 1)
                this.addPage("min", "...", pages, false);
        }
        
        for (let idx of array) {
            this.addPage(idx, idx, pages);
        }

        if (array[array.length - 1] < max) {
            if (max - array[array.length - 1] > 1)
                this.addPage("max", "...", pages, false);            
            this.addPage(max, max, pages);
        }

        return pages;
    }

    generateIndicies(total, pageNum, max) {
        if (total <= max)
            return Array.from(Array(total), (_, i) => i + 1);

        const result = [];
        let countDown = 1, countUp = 1;
        result.push(pageNum);
        while (result.length < max) {
            if (pageNum - countDown > 0) {
                result.push(pageNum - countDown);
                countDown++;
            }

            if (result.length < max && pageNum + countUp <= total) {
                result.push(pageNum + countUp);
                countUp++;
            }
        }

        return result.sort((f, s) => f - s);
    }

    addPage(idx, title, pages, needOnClick = true) {
        pages.push(<Page key={idx} pageNum={idx} title={title} activePage={this.props.activePage} onClick={needOnClick ? this.props.onClick : null} />);
    }
}

class Page extends React.Component {
    render() {
        return (
            <li className={this.props.pageNum === this.props.activePage ? "page-item active" : "page-item"} onClick={this.props.onClick} page-num={this.props.pageNum} >
                <span className='page-link'>{this.props.title}</span>
            </li>
        );
    }
}