import React, {Fragment} from 'react';
import { Route } from 'react-router';
import './css/main.css'
import CarList from "./components/CarList/CarList"
import About from "./components/About/About"

export default () => (
    <Fragment>
        <CarList />
        <About/>
    </Fragment>
);
