import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Goals } from './components/Goals';
import { Login } from './components/Login';
import { Register } from './components/Register';
import { RouteComponentProps } from 'react-router';

export class MainRoutes extends React.Component<any, any> {
    constructor(props:any) {
        super(props);
    }
    public render() {
        return <Layout>
            <Route exact path='/' component={Home}/>
            <Route path='/goals' component={Goals}/>
            <Route path='/Login' component={Login} render={(props) => (
                <Login {...props} isLogged={this.props.isLoggedInCallback}/>)}/>
            <Route path='/Register' component={Register}/>
        </Layout>;
    }
}

//export const MainRoutes = (props: any) => {
    
//    return <Layout>
//               <Route exact path='/' component={Home}/>
//               <Route path='/goals' component={Goals}/>
//               <Route path='/Login' component={Login} render={(props) => (
//            <Login {...props} isLogged={this.props.isLoggedInCallback} />)}/>
//               <Route path='/Register' component={Register}/>
//           </Layout>;
//}