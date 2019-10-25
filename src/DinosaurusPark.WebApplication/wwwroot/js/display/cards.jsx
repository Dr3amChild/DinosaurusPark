class Cards extends React.Component {
    render() {
        const cards = [];
        for (let item of this.props.items) {
            cards.push(<Card key={item.id} info={item} />);
        }
        return cards;
    }
}