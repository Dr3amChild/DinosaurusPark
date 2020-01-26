class ConfirmationModal extends React.Component {    
    render() {
        return <div className="modal-dialog modal-dialog-centered" role="document">
                   <div className="modal-content">
                       <div className="modal-header">
                           <h5 className="modal-title">{this.props.title}</h5>
                           <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                               <span aria-hidden="true">&times;</span>
                           </button>
                       </div>
                       <div className="modal-body">
                           <p>{this.props.text}</p>
                       </div>
                       <div className="modal-footer">
                           <button type="button" className={`btn ${this.props.okBtnClass}`} onClick={this.props.callback}>{this.props.okBtnTitle}</button>
                           <button type="button" className="btn btn-secondary" data-dismiss="modal">Отменить</button>
                       </div>
                   </div>
               </div>;
    }    
}