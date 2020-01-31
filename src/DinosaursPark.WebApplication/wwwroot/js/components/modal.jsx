class Modal extends React.Component {
    render() {
        return (
            <div className="modal-dialog modal-dialog-centered" role="document">
                <div className="modal-content">
                    <Header header={this.props.header} />
                    <Body content={this.props.content} />                    
                    <Footer buttonTitle={this.props.buttonTitle} />
                </div>
            </div>
        );
    }
}

class ConfirmModal extends React.Component {
    render() {
        return (
            <div className="modal-dialog modal-dialog-centered" role="document">
                <div className="modal-content">
                    <Header header={this.props.header} />
                    <Body content={this.props.content} />                    
                    <ConfirmFooter 
                        okBtnTitle={this.props.okBtnTitle} 
                        okBtnClass={this.props.okBtnClass}
                        callback={this.props.callback} />
                </div>
            </div>
        );
    }
}

class Header extends React.Component {
    render() {
        return (
            <div className="modal-header">
                <h5 className="modal-title">{this.props.header}</h5>
                <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
        );
    }
}

class Body extends React.Component {
    render() {
        return (
            <div className="modal-body">
                <div className="container">
                    {this.props.content}
                </div>
            </div>
        );
    }
}

class Footer extends React.Component {
    render() {
        return (
            <div className="modal-footer">
                <button type="button" className="btn btn-secondary" data-dismiss="modal">{this.props.buttonTitle}</button>
            </div>
        );
    }
}

class ConfirmFooter extends React.Component {
    render() {
        return (
            <div className="modal-footer">
                <button type="button" className={`btn ${this.props.okBtnClass}`} onClick={this.props.callback}>{this.props.okBtnTitle}</button>
                <button type="button" className="btn btn-secondary" data-dismiss="modal">Отменить</button>
            </div>
        );
    }
}