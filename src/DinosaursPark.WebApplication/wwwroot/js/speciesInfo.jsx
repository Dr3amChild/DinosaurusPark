class SpeciesInfo extends React.Component {
    render() {
        return (
            <div id="species-list">
                {this.speciesList()}
            </div>
        );
    }

    speciesList() {
        const items = [];
        for (let idx = 0; idx < this.props.info.length; ++idx) {
            items.push(<SpeciesInfoField key={idx} species={this.props.info[idx].speciesName} count={this.props.info[idx].count} />);
        }
        return items;
    }
}

class SpeciesInfoField extends React.Component {
    render() {
        return (
            <div className="col-sm">
                <div className="species-info-header">{this.props.species}</div>
                <div className="species-info-header">{this.props.count}</div>
            </div>
        );
    }
}