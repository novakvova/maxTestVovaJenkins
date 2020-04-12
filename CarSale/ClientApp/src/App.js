import React, { Fragment } from 'react';
import { Route } from 'react-router';
import './css/main.css'
import CarList from "./components/CarList/CarList"
import EditProfile from "./components/Profile/EditProfile/EditProfile"
export default () => (
	<Fragment>
		<CarList />
		<EditProfile />
	</Fragment>
);
