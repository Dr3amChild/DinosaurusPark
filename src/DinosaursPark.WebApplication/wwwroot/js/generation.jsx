class GenerationForm extends React.Component {
    constructor() {
        super();
        this.errorClassName = "validation-error";
        this.validator = new FormValidator(this.errorClassName);
        this.onGenerateClick = this.onGenerateClick.bind(this);
    }

    render() {
        const items = [];
        items.push(<h5 className="card-title" key="1">Динозавров пока нет. Но вы можете их сгенерировать.</h5>);
        items.push(<FormGroup
                        key="2"
                        id="species-count-text"
                        min="1"
                        max="100"
                        title="Количество видов:"
                        text={this.props.species}
                        errorClass={this.errorClassName}
            message={`Поле может содержать только целые числа от 1 до 100`}
                        placeholder="Введите значение" />);
        items.push(<FormGroup
                        key="3"
                        id="dinosaurs-count-text"
                        min="1"
                        max="1000"
                        title="Количество динозавров:"
                        text={this.props.dinosaurs}
                        errorClass={this.errorClassName}
                        placeholder="Введите значение" />);
        items.push(<button type="button" key="4" className="btn btn-info" onClick={this.onGenerateClick}>Сгенерировать</button>);
        return items;
    }

    onGenerateClick() {
        const inputs = [];
        inputs.push(document.getElementById("species-count-text"));
        inputs.push(document.getElementById("dinosaurs-count-text"));
        if (this.validator.validateInputs(inputs)) {
            this.props.onClick();
        }
    }
}

class FormGroup extends React.Component {
    render() {
        return (
            <div className="form-group">
                <label className="form-label">{this.props.title}</label>
                <input
                    id={this.props.id}
                    type="text"
                    className="form-control"
                    message={`Поле может содержать только целые числа от 1 до 1000`}
                    onChange={this.onChange.bind(this)}
                    placeholder={this.props.placeholder}
                    defaultValue={this.props.text}
                    min={this.props.min}
                    max={this.props.max} />            
            </div>
        );
    }

    onChange(e) {
        e.currentTarget.classList.remove(this.props.errorClass);
    }
}