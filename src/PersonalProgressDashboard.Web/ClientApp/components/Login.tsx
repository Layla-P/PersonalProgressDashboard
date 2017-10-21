

import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';
import axios from "axios/index";




interface ILoginModel {
    email: string;
    password: string;
    rememberme: boolean;
}


export class Login extends React.Component<RouteComponentProps<{}>, ILoginModel> {
    val: string;
    constructor() {
        super();
        this.state = { email: "", password: "", rememberme: false };

        this.handleSubmit = this.handleSubmit.bind(this);
    }

    emailSet(event: any): void {
        this.setState({ email: event.target.value });
    }
    passwordSet(event: any): void {
        this.setState({ password: event.target.value });
    }
    rememberMeSet(event: any): void {
        this.setState({ rememberme: event.target.value });
    }
  
    handleSubmit(event: any): any {
        console.log(this.state);
        event.preventDefault();
        axios({
            method: "POST",
            //url: 'http://personal-progress-dashboard-api.azurewebsites.net/api/login',
           url:'http://localhost:53330/api/login',
            data: {
                email: this.state.email,
                password: this.state.password,
                rememberme: this.state.rememberme
            }
        }).then(response => {
            console.log("yay!");
            console.log(response);
            localStorage.setItem("token", response.data.token);
        });
    }

    public render() {

        return (
            <form onSubmit={(e:any)=>(this.handleSubmit(e))}>
                <label>
                    Email:
                            <input type="text" value={this.state.email} onChange={(event: any) => (this.emailSet(event))} />
                </label>
                <label>
                    password:
                            <input type="text" value={this.state.password} onChange={(event: any) => (this.passwordSet(event))} />
                </label>
                <label>
                    remember Me:
                            <input type="checkbox" checked={this.state.rememberme} onChange={(event: any) => (this.rememberMeSet(event))} />
                </label>
                <input type="submit" value="Submit" />
            </form>

        );

    }

}




