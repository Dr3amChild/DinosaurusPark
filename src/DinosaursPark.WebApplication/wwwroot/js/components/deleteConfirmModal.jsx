class DeleteConfirmModal extends React.Component {
    render() {
        return <ConfirmModal
                    header={this.props.header}
                    content={<p>{this.props.text}</p>}
                    okBtnClass={this.props.okBtnClass}
                    callback={this.props.callback}
                    okBtnTitle={this.props.okBtnTitle} />
    }
}