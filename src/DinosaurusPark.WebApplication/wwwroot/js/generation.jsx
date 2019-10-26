class GenerationForm extends React.Component {
    render() {
        const items = [];
        items.push(<h5 className="card-title" key="1">Динозавров пока нет. Но вы можете их сгенерировать.</h5>);
        items.push(<FormGroup key="2" id="species-count-text" title="Количество видов:" text={this.props.species} placeholder="Введите значение" />);
        items.push(<FormGroup key="3" id="dinosaurs-count-text" title="Количество динозавров:" text={this.props.dinosaurs} placeholder="Введите значение" />);
        items.push(<button type="button" key="4" className="btn btn-info" onClick={this.props.onClick}>Сгенерировать</button>);
        return items;
    }
}

class FormGroup extends React.Component {
    render() {
        return (
            <div className="form-group">
                <label className="form-label">{this.props.title}</label>
                <input id={this.props.id} type="text" className="form-control" placeholder={this.props.placeholder} value={this.props.text} />            
            </div>
        );
    }
}