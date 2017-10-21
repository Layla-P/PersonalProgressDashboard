import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { MyForm } from './components/Form';
import { MyGoals } from './components/Goals';
import { Login } from './components/Login';
import { Register } from './components/Register';

export const routes = <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/counter' component={Counter} />
    <Route path='/fetchdata' component={FetchData} />
    <Route path='/form' component={MyForm} />
    <Route path='/goals' component={MyGoals} />
    <Route path='/Login' component={Login} />
    <Route path='/register' component={Register} />
</Layout>;
