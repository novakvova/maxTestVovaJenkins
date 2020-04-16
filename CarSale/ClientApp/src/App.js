import React, {Fragment} from 'react';
import { Route } from 'react-router';
import './css/main.css'
import CarList from "./components/CarList/CarList"
import Header from "./components/Header/Header"

export default () => (
    <Fragment>
        <Header />
        <CarList/>
    </Fragment>
);
