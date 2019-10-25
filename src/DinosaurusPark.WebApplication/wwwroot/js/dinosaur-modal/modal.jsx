class DinosaurModal extends React.Component {
    render() {
        return (
            <div className="modal-dialog modal-dialog-centered" role="document">
                <div className="modal-content">
                    <div className="modal-header">
                        <h5 className="modal-title" id="dinosaur-modal-title">{this.props.modalHeader}</h5>
                        <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div className="modal-body">
                        <div className="container">
                            <div className="container">
                                <Photo source={this.props.info.image} />

                                <Row names={[{ key: "name", "title": "Имя:" }, { key: "age", title: "Возраст, лет:" }]} info={this.props.info} />
                                <Row names={[{ key: "gender", "title": "Пол:" }]} info={this.props.info} />
                                <Row names={[{ key: "species", "title": "Вид:" }, { key: "foodType", title: "Тип питания:" }]} info={this.props.info} />
                                <Row names={[{ key: "height", "title": "Рост, см:" }, { key: "weight", title: "Вес, кг:" }]} info={this.props.info} />
                                
                                <Description header="Описание" value={this.props.info.description} />
                            </div>
                        </div>
                    </div>
                    <div className="modal-footer">
                        <button type="button" className="btn btn-secondary" data-dismiss="modal">{this.props.buttonTitle}</button>
                    </div>
                </div>
            </div>
        );
    }
}