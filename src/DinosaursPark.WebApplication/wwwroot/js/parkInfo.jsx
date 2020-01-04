class ParkInfo extends React.Component {
    render() {
        return (
            <div className="container">
                <InfoField keyName="name" title="Название парка:" info={this.props.info} />
                <InfoField keyName="address" title="Расположение:" info={this.props.info} />
                <InfoField keyName="dinosaursCount" title="Динозавров в парке:" info={this.props.info} />
                <InfoField keyName="speciesCount" title="Видов:" info={this.props.info} />
            </div>
        );
    }
}

class InfoField extends React.Component {
    render() {
        console.log(this.props);
        return (
            <div className="col-sm">
                <div className="info-header">{this.props.title}</div>
                <p>{this.props.info[this.props.keyName]}</p>
            </div>
        );
    }
}