import React, { Fragment } from 'react';
import { Route } from 'react-router';
import './css/main.css'
import CarList from "./components/CarList/CarList"
import About from "./components/About/About"
import EditProfile from "./components/Profile/EditProfile/EditProfile"
import ShowProfile from "./components/Profile/ShowProfile/ShowProfile"

export default () => (
	<Fragment>
		<CarList />
   <About/>
		<EditProfile />
		<ShowProfile />
	</Fragment>
);
