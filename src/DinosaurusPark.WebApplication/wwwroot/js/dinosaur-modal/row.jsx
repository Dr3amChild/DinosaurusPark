class Row extends React.Component {
    render() {
        return (
            <div className="row">
                {this.createItems()}
            </div>
        );
    }

    createItems() {
        const items = [];
        for (let name of this.props.names) {
            items.push(<DinosaurField header={name.title} value={this.props.info[name.key]}/>);
        }
        return items;
    }
}