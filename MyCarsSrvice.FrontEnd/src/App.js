import React, { Component } from 'react';

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { service_detail: [], loading: true };
    }

    componentDidMount() {
        this.getServiceDetails();
    }

    static renderServiceDetalisTable(service_datails) {
        let items = []
        for (let i = 0; i < service_datails.length; ++i) {
            items.push(<div key={i.toString()}>
                <h3>{service_datails[i].serviceType}</h3>
                <p>Data serwisu: {service_datails[i].serviceDate.split("T", 1)} </p>
                <p>Przebieg: {service_datails[i].mileage} </p>
                <p>Opis: {service_datails[i].description} </p>
            </div>)

        }
        return (
            console.log(service_datails),
            <div>
                {items}
            </div>

        );
    }

    render() {
        let contents = this.state.loading
            ? <p>Brak komunikacji z serverem!</p>
            : App.renderServiceDetalisTable(this.state.service_detail);

        return (
            <div>
                <h1 id="tabelLabel" >Service detalis</h1>
                {contents}
            </div>
        );
    }

    async getServiceDetails() {

        const response = await fetch('https://localhost:7221/service/get/1', { method: "GET", headers: { "accept": "*/*" } });
        try {
            const data = await response.json();
            this.setState({ service_detail: data, loading: false });
        }
        catch (error) {
            console.log("error: ", error);
        }

    }
}
