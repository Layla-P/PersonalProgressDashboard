

import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';
import axios from "axios/index";




interface IRegisterModel {
    email: string;
    username: string;
    password: string;
    confirmPassword: string;
    firstName: string;
    lastName: string;
    isMetric: boolean;
    sex: number;
    age: number;
    heightCm: number;
}


export class Register extends React.Component<RouteComponentProps<{}>, IRegisterModel> {
    val: string;
    constructor() {
        super();
        this.state = { email: "", username: "", password: "", confirmPassword: "", firstName: "", lastName: "", isMetric: true, sex: 0, age: 0, heightCm: 0 };
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleInputChange(event: any): void {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const name = target.name;
        let partialState: any = {};
        partialState[name] = value;
        this.setState(partialState);
    }

    handleSubmit(event: any): any {
        console.log(this.state);
        event.preventDefault();
       
        axios.post('http://localhost:53330/api/registration',
            {
                email: this.state.email,
                password: this.state.password,
                username: this.state.username,
                confirmPassword: this.state.confirmPassword,
                firstName: this.state.firstName,
                lastName: this.state.lastName,
                isMetric: this.state.isMetric,
                sex: this.state.sex,
                age: this.state.age,
                heightCm: this.state.heightCm
            })
            .then(response => {
            console.log("yay!");
            console.log(response);
            localStorage.setItem("token", response.data.token);
        });
    }

    public render() {

        return (
            <div className="container">
                <form onSubmit={(e: any) => (this.handleSubmit(e))}>
                    <div className="form-group">
                        <label>username:</label>
                        <input className="form-control" type="text" name="username" value={this.state.username} onChange={(event: any) => (this.handleInputChange(event))} />
                    </div>
                    <div className="form-group">
                        <label> Email:</label>
                        <input className="form-control" type="text" name="email" value={this.state.email} onChange={(event: any) => (this.handleInputChange(event))} />
                    </div>
                    <div className="form-group">
                        <label> password:</label>
                        <input className="form-control" type="text" name="password" value={this.state.password} onChange={(event: any) => (this.handleInputChange(event))} />
                    </div>
                    <div className="form-group">
                        <label> Confirm password:</label>
                        <input className="form-control" type="text" name="confirmPassword" value={this.state.confirmPassword} onChange={(event: any) => (this.handleInputChange(event))} />

                        <label>firstName: </label>
                        <input className="form-control" type="text" name="firstName" value={this.state.firstName} onChange={(event: any) => (this.handleInputChange(event))} />
                    </div>
                    <div className="form-group">
                        <label> lastName:</label>
                        <input className="form-control" type="text" name="lastName" value={this.state.lastName} onChange={(event: any) => (this.handleInputChange(event))} />
                    </div>
                    <div className="form-group">
                        <label> isMetric:</label>
                        <input className="form-control" type="checkbox" name="isMetric" checked={this.state.isMetric} onChange={(event: any) => (this.handleInputChange(event))} />
                    </div>
                    <div className="form-group">
                        <label> sex:</label>
                        <input className="form-control" type="text" name="sex" value={this.state.sex} onChange={(event: any) => (this.handleInputChange(event))} />
                    </div>
                    <div className="form-group">
                        <label>age:</label>
                        <input className="form-control" type="text" name="age" value={this.state.age} onChange={(event: any) => (this.handleInputChange(event))} />
                    </div>
                    <div className="form-group">
                        <label> heightCm:</label>
                        <input className="form-control" type="text" name="heightCm" value={this.state.heightCm} onChange={(event: any) => (this.handleInputChange(event))} />
                    </div>
                    <button type="submit" className="btn btn-primary">Submit</button>
                </form>
            </div>

        );

    }

}




