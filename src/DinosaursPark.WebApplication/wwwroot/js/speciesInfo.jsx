class SpeciesInfo extends React.Component {
    render() {
        return (
            <table className="table table-bordered">
                <caption>Информация о видах</caption>
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Вид</th>
                        <th>Количество особей</th>
                    </tr>
                </thead>
                <tbody>
                    {this.speciesList()}
                </tbody>
            </table>
        );
    }

    speciesList() {
        const items = [];
        for (let idx = 0; idx < this.props.info.length; ++idx) {
            items.push(<SpeciesInfoField key={idx} idx={idx + 1} species={this.props.info[idx].speciesName} count={this.props.info[idx].count} />);
        }
        return items;
    }
}

class SpeciesInfoField extends React.Component {
    render() {
        return (
            <tr>
                <th>{this.props.idx}</th>
                <td>{this.props.species}</td>
                <td>{this.props.count}</td>
            </tr>
        );
    }
}