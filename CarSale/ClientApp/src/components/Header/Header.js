import React, { Component, Fragment } from 'react';
import NavbarMenu from "./components/Header/NavbarMenu/NavbarMenu"
import HeaderSearch from "./components/Header/HeaderSearch/HeaderSearch"
class Header extends Component {
   
    render() {
        return (
            <Fragment>
                <NavbarMenu />
                <HeaderSearch />
            </Fragment>
        );
    }
}

export default Header;