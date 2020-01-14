class ParkInfo extends React.Component {
    render() {
        return (
            <div>
                <table className="table table-bordered">
                    <caption>Информация о парке</caption>
                    <tbody>
                        <InfoTr keyName="name" title="Название парка" info={this.props.info} />
                        <InfoTr keyName="address" title="Расположение" info={this.props.info} />
                        <InfoTr keyName="dinosaursCount" title="Динозавров" info={this.props.info} />
                        <InfoTr keyName="speciesCount" title="Видов" info={this.props.info} />
                    </tbody>
                </table>
                <button className="btn btn-info" onClick={this.props.onSpeciesInfoClick}>Загрузить</button>
            </div>
        );
    }
}

class InfoTr extends React.Component {
    render() {
        return (
            <tr className="col-sm">
               <th>{this.props.title}</th>
               <td>{this.props.info[this.props.keyName]}</td>
            </tr>
        );
    }
}