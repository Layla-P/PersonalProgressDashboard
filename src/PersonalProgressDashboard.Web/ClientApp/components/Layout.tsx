import * as React from 'react';
import { NavMenu } from './NavMenu';
import {MainRoutes} from '../routes';

export interface LayoutProps {
    children?: React.ReactNode;
}

export class Layout extends React.Component<LayoutProps, any> {
    
    constructor(props: any) {
        super(props);
        this.state = { isLoggedIn: false };
    }

    isLoggedInCallback(isLoggedIn:boolean) {
        this.setState({ isLoggedIn: isLoggedIn });
    }

    public render() {
        return <div className='container-fluid'>
            <div className='row'>
                <div className='col-sm-3'>
                    <NavMenu />
                </div>
                <div className='col-sm-9'>
                    <MainRoutes {...this.props} data={{ isLoggedin: this.state.isLoggedIn}}/>
                </div>
            </div>
        </div>;
    }
}

