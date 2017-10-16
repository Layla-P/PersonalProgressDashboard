import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';
import axios from "axios/index";




interface IResponse {
    value: string;
}

interface HTMLInputEvent extends Event {
    target: HTMLInputElement & EventTarget;
}

export class MyForm extends React.Component<RouteComponentProps<{}>, IResponse> {
    isSubmitted: boolean = false;
    val: string;
    constructor() {
        super();
        this.state = { value: "" };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(): void {
        let el = document.getElementById('name') as HTMLInputElement;
        console.log('el ' + el.value);
        this.setState({ value: el.value });

        console.log('val of val ' + this.state.value);
    }

    handleSubmit(): any {

        axios({
            method: 'post',
            url: '/api/Form',
            data: {
                nameText: this.state.value
            }
        }).then(response => {
            this.isSubmitted = true;
            this.setState({ value: response.data.value });
        });
    }

    public render() {

        if (!this.isSubmitted) {
            return (

                <div>
                    <input id="name" type="text" value={this.state.value} onChange={this.handleChange} />
                    <button onClick={this.handleSubmit}>click me</button>
                </div>
            );
        } else {
            return (
                <div>
                    <h1>{this.state.value}</h1>
                </div>
            );
        }
    }

}
