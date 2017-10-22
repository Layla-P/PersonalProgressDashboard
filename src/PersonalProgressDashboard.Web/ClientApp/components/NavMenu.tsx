import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';

export class NavMenu extends React.Component<any, any> {
    isLoggedIn:boolean = false;
    constructor(props:any) {
        super(props);

        //let loggedin: boolean = false;
        ////todo: check expiry on token
        //if (localStorage !== null && localStorage.getItem("token") !== null) {
        //    if (localStorage.getItem("expiration") !== null)
        //        this.isLoggedIn = true;
        //}
        
    }
   public render() {
        return <div className='main-nav'>
            <div className='navbar navbar-inverse'>
                <div className='navbar-header'>
                    <button type='button' className='navbar-toggle' data-toggle='collapse' data-target='.navbar-collapse'>
                        <span className='sr-only'>Toggle navigation</span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                    </button>
                    <Link className='navbar-brand' to={'/'}>WebApplication1</Link>
                </div>
                <div className='clearfix'></div>
                <div className='navbar-collapse collapse'>
                    <ul className='nav navbar-nav'>
                        <li>
                            <NavLink to={'/'} exact activeClassName='active'>
                                <span className='glyphicon glyphicon-home'></span> Home
                            </NavLink>
                        </li>
                        
                        <li>
                            <NavLink to={'/login'} activeClassName='active'>
                                <span className='glyphicon glyphicon-th-list'></span> Login
                            </NavLink>
                        </li>
                       
                        <li>
                            <NavLink to={'/register'} activeClassName='active'>
                                <span className='glyphicon glyphicon-th-list'></span> Register
                            </NavLink>
                            </li>
                       
                            <li >
                                <NavLink to={'/goals'} activeClassName='active'>
                                    <span className='glyphicon glyphicon-th-list'></span> My Goals
                            </NavLink>
                            </li>
                    </ul>
                </div>
            </div>
        </div>;
    }
}
