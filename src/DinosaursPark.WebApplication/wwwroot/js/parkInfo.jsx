class ParkInfo extends React.Component {
    render() {
        return (
            <div>
                <table className="table table-bordered">
                    <caption>Информация о парке</caption>
                    <tbody>
                        <InfoTr title="Название" value={this.props.info.name} />
                        <InfoTr title="Расположение" value={this.props.info.address} />
                        <InfoTr title="Динозавров" value={this.props.info.dinosaursCount} />
                        <InfoTr title="Видов" value={this.props.info.speciesCount} />
                        <InfoTr title="Площадь, км²" value={this.props.info.area.toFixed(2)} />
                        <InfoTr title="Плотность населения, динозавров/км²" value={this.props.info.density.toFixed(2)} />
                    </tbody>
                </table>
                <button className="btn btn-info" onClick={this.props.onSpeciesInfoClick}>Загрузить данные о видах</button>
                <button id="delete-park-btn" className="btn btn-danger" onClick={this.showModal.bind(this)}>Уничтожить парк</button>
            </div>
        );
    }

    showModal() {
        const area = document.getElementById("delete-modal");
        ReactDOM.render(
            <ConfirmationModal
                title="Удаление"
                text="Вы действительно хотите закрыть этот парк и усыпить всех динозавров?"
                okBtnClass="btn-danger"
                okBtnTitle="Удалить"
                callback={this.props.onDeleteParkClick} />,
            area);
        $("#delete-modal").modal();
    }
}

class InfoTr extends React.Component {
    render() {
        return (
            <tr className="col-sm">
               <th>{this.props.title}</th>
               <td>{this.props.value}</td>
            </tr>
        );
    }
}